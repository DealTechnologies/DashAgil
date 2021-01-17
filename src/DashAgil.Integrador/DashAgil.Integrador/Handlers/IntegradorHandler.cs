using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Commands.Output;
using DashAgil.Integrador.DevOps.Commands.Output;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Enums;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Queries;
using DashAgil.Integrador.Repositorio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Handlers
{
    public class IntegradorHandler : ICommandHandler<SalvarEstoriaCommand>,
                                     ICommandHandler<IntegracaoInicialDevopsCommand>,
                                     ICommandHandler<AtualizarTiposWorkItensCommand>,
                                     ICommandHandler<ObterWorkItensSumarizadoCommand>,
                                     ICommandHandler<AtualizarSprintsCommand>
    {
        private readonly IAzureDevopsRepository repository;
        private readonly IAzureDevopsQueries _query;
        private readonly IProjetoRepositorio _projetoRepo;
        private readonly IOrganizacoesRepositorio _orgRepo;
        private readonly IDemandasRepostorio _demandasRepo;
        private readonly ISquadRepositorio _squadRepo;
        private readonly ISprintRepositorio _sprintRepo;
        private readonly IDemandaHistoricoRepositorio _historicoRepo;

        public IntegradorHandler(IAzureDevopsRepository repository, IAzureDevopsQueries query, IOrganizacoesRepositorio orgRepo,
                                 IDemandasRepostorio demandasRepo, ISquadRepositorio squadRepo, ISprintRepositorio sprintRepo,
                                 IProjetoRepositorio projetoRepo, IDemandaHistoricoRepositorio historicoRepo)
        {
            this.repository = repository;
            _query = query;
            _orgRepo = orgRepo;
            _historicoRepo = historicoRepo;
            _demandasRepo = demandasRepo;
            _squadRepo = squadRepo;
            _sprintRepo = sprintRepo;
            _projetoRepo = projetoRepo;
        }

        public async Task<ICommandResult> Handle(SalvarEstoriaCommand command)
        {
            var estoria = new Estoria(command.Nome, command.Descricao);

            //salvar
            var result = true;

            await Task.CompletedTask;

            return new IntegradorCommandResult(true, "sucess", result);
        }

        public async Task<ICommandResult> Handle(IntegracaoInicialDevopsCommand command)
        {
            var organizacao = await _orgRepo.ObterPorNome(command.Organizacao);

            var projetosDevops = await _query.ObterProjetos(command.Organizacao, command.Token);

            if (projetosDevops is null || !projetosDevops.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar a base de projetos", null);

            if (organizacao is null)
            {
                organizacao.Id = await _orgRepo.Inserir(new Organizacoes
                {
                    ClienteId = command.ClienteId,
                    DataCriacao = DateTime.Now,
                    DataModificacao = DateTime.Now,
                    Nome = command.Organizacao,
                    Descricao = command.Organizacao
                });
            }

            //projetosDevops.Value.ForEach(x => _projetoRepo.Inserir(new Projeto
            //{
            //    Descricao = x.Description,
            //    DataModificacao = Convert.ToDateTime(x.LastUpdateTime),
            //    ExternalId = x.Id,
            //    Nome = x.Name,
            //    OrganizacaoId = organizacao.Id,
            //    DataCriacao = DateTime.Now
            //}));

            var handleItens = await Handle(new ObterWorkItensSumarizadoCommand { Organizacao = command.Organizacao, Token = command.Token });

            if (!handleItens.Success)
                return handleItens;

            return new IntegradorCommandResult(true, "AzureDevops sincronizado com sucesso", null);
        }

        public async Task<ICommandResult> Handle(AtualizarTiposWorkItensCommand command)
        {
            string token = "";
            var tipos = await _query.ObterWorkItensTypes(command.Organizacao, command.Time, command.Projeto, token);

            if (tipos is null || !tipos.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar os tipos de work itens", null);

            var tiposWorkItens = tipos.Value.ToList().Select(x => new TiposWorkItensDevops
            {
                Nome = x.Name,
                Url = x.Url,
                WorkItemTypeId = x.Id

            }).ToList();

            repository.SalvarTiposWorkItens(tiposWorkItens);

            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", tiposWorkItens);
        }

        public async Task<ICommandResult> Handle(ObterWorkItensSumarizadoCommand command)
        {
            var organizacao = await _orgRepo.ObterPorNome(command.Organizacao);

            if (organizacao == null)
                return new IntegradorCommandResult(false, "Organização não localizada", command);

            foreach (var tipo in Enum.GetValues(typeof(EQueryWorkItemType)).Cast<EQueryWorkItemType>())
            {
                var workItensQuery = await _query.ConsultarPorQuery(command.Organizacao, command.Token, tipo);

                if (workItensQuery != null)
                {
                    foreach (var res in workItensQuery.WorkItems)
                    {
                        var stringResult = await _query.GetWorkItemByURL(res.Url, command.Organizacao, command.Token);

                        if (stringResult != null)
                        {
                            WorkItemResult workIten = TratarWorkItem(stringResult);

                            var projeto = await GerenciarProjeto(workIten, organizacao.Id);
                            var squad = await GerenciarSquad(workIten, projeto.Id);
                            var sprint = await GerenciarSprint(workIten, projeto, command.Organizacao, squad.Nome, command.Token, squad.Id);

                            var workItenDesc = await _query.ObterWorkItemPorId(command.Organizacao, projeto.Nome, command.Token, workIten.Id);

                            if (!string.IsNullOrEmpty(workItenDesc))
                            {
                                workIten = TratarWorkItem(workItenDesc);

                                var demanda = Demandas.PreencherDemandaDevops(workIten, projeto.Id, squad.Id, sprint?.Id);
                                await TratarHistorico(command, workIten, projeto, squad, sprint, demanda);

                                var historicoResult = await TratarHistorico(command, workIten, projeto, squad, sprint, demanda);
                                demanda.DemandaPaiId = historicoResult.DemandaPai?.Id;
                                demanda.Pontos = historicoResult.StoryPoint;
                                _demandasRepo.Insert(demanda);
                            }
                        }

                    };
                }
            };


            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", null);
        }

        private static WorkItemResult TratarWorkItem(string stringResult)
        {
            stringResult = stringResult.Replace("System.", string.Empty)
                                       .Replace("Microsoft.VSTS.Common.", string.Empty)
                                       .Replace("Microsoft.VSTS.Scheduling.", string.Empty);

            return JsonConvert.DeserializeObject<WorkItemResult>(stringResult);
        }

        private async Task<TratamentoHistoricoResult> TratarHistorico(ObterWorkItensSumarizadoCommand command, WorkItemResult workIten, Projeto projeto, Squad squad, Sprint sprint, Demandas demanda)
        {
            var historicoList = await TratarWorkItemHistorico(workIten.Links.WorkItemUpdates.Href.AbsoluteUri, command.Organizacao, command.Token);

            if (historicoList is null)
                return new TratamentoHistoricoResult(null, 0);

            string idPai = null;

            if (historicoList.FirstOrDefault(s => s.Relations != null)?.Relations?.Added
                                     .FirstOrDefault(x => x.Url?.AbsoluteUri != null) != null)
                idPai = historicoList.FirstOrDefault(s => s.Relations != null).Relations.Added
                                     .FirstOrDefault(x => x.Url?.AbsoluteUri != null).Url.AbsoluteUri.Split("/")[^1];

            var demandaPai = await _demandasRepo.ConsultarPorExternalId(idPai);

            int? storyPoint = null;

            if (historicoList.LastOrDefault(x => x.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue != null) != null)
                storyPoint = Convert.ToInt32(historicoList.LastOrDefault(x => x.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue != null)
                                                             ?.Fields.MicrosoftVstsSchedulingStoryPoints?.NewValue.Split(".")[0]);

            if (demandaPai is null)
                return new TratamentoHistoricoResult(null, storyPoint);

            foreach (var historico in new DemandaHistorico().PreencherDemandaHistoricoDevops(historicoList, demanda.ExternalId, projeto.Id, sprint?.Id, squad.Id))
            {
                historico.DemandaPaiId = demandaPai.Id;
                await _historicoRepo.Inserir(historico);
            };

            return new TratamentoHistoricoResult(demandaPai, storyPoint);
        }

        private async Task<List<WorkItemHistoric>> TratarWorkItemHistorico(string url, string organizacao, string token)
        {
            string content = await _query.GetWorkItemHistoric(url, organizacao, token);

            if (content is null)
                return null;

            content = content.Replace("System.", string.Empty)
                           .Replace("Microsoft.VSTS.Common.", string.Empty)
                           .Replace("BRSA.", string.Empty)
                           .Replace("WEF_EF55015B19924144B8B5E8E7C247058C_Kanban.", string.Empty)
                           .Replace("WEF_F2B9FD539AF54BDEAE8A5BFB85454AFF_Kanban.", string.Empty)
                           .Replace("Microsoft.VSTS.Scheduling.", string.Empty);

            return JsonConvert.DeserializeObject<DevopsResult<WorkItemHistoric>>(content).Value;
        }

        private async Task<Sprint> GerenciarSprint(WorkItemResult workIten, Projeto projeto, string organizacao, string squad, string token, long squadId)
        {
            var nomesprint = workIten.Fields.SystemIterationPath.Split("\\")[^1].Trim();
            nomesprint = nomesprint.Contains("Sprint") ? nomesprint : "Sprint BackLog";
            var sprint = await _sprintRepo.Obter(nomesprint, projeto.Id, squadId);

            if (sprint is null)
            {
                var sprintResult = await _query.ObterSprints(organizacao, projeto.Nome, token, squad);
                var filtro = sprintResult.Value.FirstOrDefault(x => x.Name.ToLower() == nomesprint.ToLower());

                if (filtro is null)
                    return null;

                sprint = Sprint.PreencherSprints(nomesprint, projeto.Id, squadId);
                sprint = AtualizarDadosSprint(filtro, sprint);
                sprint.Id = (int)await _sprintRepo.Inserir(sprint);
            }

            return sprint;
        }


        private async Task<Squad> GerenciarSquad(WorkItemResult workIten, long projetoId)
        {
            var nomesquad = workIten.Fields.SystemAreaPath.Split("\\")[^1].Trim();
            var squad = await _squadRepo.ObterPorNome(nomesquad);

            if (squad is null)
            {
                squad = Squad.PreencherInsercao(nomesquad, projetoId);
                squad.Id = (int)await _squadRepo.Inserir(squad);
            }

            return squad;
        }


        private async Task<Projeto> GerenciarProjeto(WorkItemResult workIten, long organizacaoId)
        {
            var nomeProjeto = workIten.Fields.SystemTeamProject.Trim();
            var projeto = await _projetoRepo.ObterPorNome(nomeProjeto);

            if (projeto is null)
            {
                projeto = Projeto.PreencherProjeto(organizacaoId, nomeProjeto);
                projeto.Id = (int)await _projetoRepo.Inserir(projeto);
            }

            return projeto;
        }

        public void teste()
        {
            repository.test();
        }

        public async Task<ICommandResult> Handle(AtualizarSprintsCommand command)
        {
            var organizacao = await _orgRepo.ObterPorID(command.OrganizacaoId);

            if (organizacao is null)
                return new IntegradorCommandResult(false, "falha ao obter organização por Id", null);

            var projetos = await _projetoRepo.ObterProjetoPorOrganizacaoId(command.OrganizacaoId);

            foreach (var projeto in projetos)
            {
                var squads = await _squadRepo.ObterPorProjetoId(projeto.Id);

                foreach (var squad in squads)
                {
                    var sprintsResult = await _query.ObterSprints(organizacao.Nome, projeto.Nome, command.Token, squad.Nome);

                    if (sprintsResult is null || sprintsResult.Count < 1)
                        continue;

                    foreach (var sprint in sprintsResult.Value)
                    {
                        var sprintEmBanco = await _sprintRepo.Obter(sprint.Name, projeto.Id, squad.Id);

                        if (sprintEmBanco != null)
                        {
                            if (!string.IsNullOrEmpty(sprint.Attributes.StartDate) && !string.IsNullOrEmpty(sprint.Attributes.FinishDate))
                            {
                                sprintEmBanco = AtualizarDadosSprint(sprint, sprintEmBanco);
                                _sprintRepo.Atualizar(sprintEmBanco);
                            }
                        }
                    };
                }
            };

            return new IntegradorCommandResult(true, "Sprints atualizadas com sucesso!", null);
        }

        private Sprint AtualizarDadosSprint(SprintResult sprint, Sprint sprintEmBanco)
        {
            sprintEmBanco.DataInicio = Convert.ToDateTime(sprint.Attributes.StartDate);
            sprintEmBanco.DataFim = Convert.ToDateTime(sprint.Attributes.FinishDate);
            sprintEmBanco.DataConclusao = Convert.ToDateTime(sprint.Attributes.FinishDate);
            sprintEmBanco.Status = ObterStatus(sprint.Attributes.TimeFrame);

            return sprintEmBanco;
        }

        private StatusSprint ObterStatus(string timeFrame)
            => timeFrame switch
            {
                "past" => StatusSprint.Concluida,
                "current" => StatusSprint.Ativa,
                _ => StatusSprint.Futura
            };
    }
}
