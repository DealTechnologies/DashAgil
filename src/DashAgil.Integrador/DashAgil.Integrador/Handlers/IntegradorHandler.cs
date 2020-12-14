using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Commands.Output;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Queries;
using DashAgil.Integrador.Repositorio;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Handlers
{
    public class IntegradorHandler : ICommandHandler<SalvarEstoriaCommand>,
                                     ICommandHandler<IntegracaoInicialDevopsCommand>,
                                     ICommandHandler<AtualizarTiposWorkItensCommand>,
                                     ICommandHandler<ObterWorkItensSumarizadoCommand>
    {
        private readonly IAzureDevopsRepository repository;
        private readonly IAzureDevopsQueries _query;
        private readonly IProjetoRepositorio _projeoRepo;
        private readonly IOrganizacoesRepositorio _orgRepo;
        private readonly IDemandasRepostorio _demandasRepo;
        private readonly ISquadRepositorio _squadRepo;
        private readonly ISprintRepositorio _sprintRepo;

        public IntegradorHandler(IAzureDevopsRepository repository, IAzureDevopsQueries query, IOrganizacoesRepositorio orgRepo,
                                 IDemandasRepostorio demandasRepo, ISquadRepositorio squadRepo, ISprintRepositorio sprintRepo)
        {
            this.repository = repository;
            _query = query;
            _orgRepo = orgRepo;
            _demandasRepo = demandasRepo;
            _squadRepo = squadRepo;
            _sprintRepo = sprintRepo;
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

            if (organizacao != null)
                return new IntegradorCommandResult(false, "Essa organização ja foi integrada!", null);

            var projetosDevops = await _query.ObterProjetos(command.Organizacao, command.Token);

            if (projetosDevops is null || !projetosDevops.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar a base de projetos", null);


            var organizcaoId = await _orgRepo.Inserir(new Organizacoes
            {
                ClienteId = command.ClienteId,
                DataCadastro = DateTime.Now,
                DataModificacao = DateTime.Now,
                Nome = command.Organizacao
            });

            projetosDevops.Value.ForEach(async x => await _projeoRepo.Inserir(new Projeto
            {
                Descricao = x.Description,
                DataModificacao = Convert.ToDateTime(x.LastUpdateTime),
                ExternalId = x.Id,
                Nome = x.Name,
                OrganizacaoId = organizcaoId
            }));

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
            var organizacao = _orgRepo.ObterPorNome(command.Organizacao);

            if (organizacao == null)
                return new IntegradorCommandResult(false, "Organização não localizada", command);

            var workItensQuery = await _query.ConsultarPorQuery(command.Organizacao, command.Token);

            workItensQuery.WorkItems.ForEach(async res =>
            {
                var stringResult = await _query.GetWorkItemByURL(res.Url, command.Organizacao, command.Token);

                if (stringResult != null)
                {
                    stringResult.Replace("System.", string.Empty);
                    stringResult.Replace("Microsoft.VSTS.Common.", string.Empty);
                    stringResult.Replace("Microsoft.VSTS.Scheduling.", string.Empty);


                    var workIten = JsonConvert.DeserializeObject<WorkItemResult>(stringResult);
                    var projeto = await GerenciarProjeto(workIten, organizacao.Id);
                    var squad = await GerenciarSquad(workIten, projeto.Id);
                    var sprint = await GerenciarSprint(workIten , projeto.Id);

                    var demanda = Demandas.PreencherDemandaDevops(workIten, projeto.Id, squad.Id, sprint.Id);

                    _demandasRepo.Insert(demanda);
                }

            });
             

            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", null);
        }

        private async Task<Sprint> GerenciarSprint(WorkItemResult workIten, long projetoId)
        {
            var nomesprint = workIten.Fields.SystemIterationPath.Split("\\")[^1].Trim();
            var sprint = await _sprintRepo.Obter(nomesprint);

            if (sprint is null)
            {
                sprint = Sprint.PreencherSprints(nomesprint, projetoId);
                await _sprintRepo.Inserir(sprint); 
            }

            return sprint;
        }


        private async Task<Squad> GerenciarSquad(WorkItemResult workIten, long projetoId)
        {
            var nomesquad = workIten.Fields.SystemAreaPath.Split('-')[^1].Trim();
            var squad = await _squadRepo.ObterPorNome(nomesquad);

            if (squad is null)
            {
                squad = Squad.PreencherInsercao(nomesquad, projetoId);
                await _squadRepo.Inserir(squad);
            }

            return squad;
        }


        private async Task<Projeto> GerenciarProjeto(WorkItemResult workIten, long organizacaoId)
        {
            var nomeProjeto = workIten.Fields.SystemTeamProject.Trim();
            var projeto = await _projeoRepo.ObterPorNome(nomeProjeto);

            if (projeto is null)
            {
                projeto = Projeto.PreencherProjeto(organizacaoId, nomeProjeto);
                await _projeoRepo.Inserir(projeto);
            }

            return projeto;
        }

        public void teste()
        {
            repository.test();
        }
    }
}
