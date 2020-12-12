using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using DashAgil.Integrador.Jira.Commands.Output;
using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Queries.Sprints;
using DashAgil.Integrador.Jira.Repositorio;
using DashAgil.Integrador.Repositorio;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Handlers
{
    public class IntegradorJiraHandler : Notifiable, ICommandHandler<IntegracaoInicialJiraCommand>
    {
        private readonly IBoardRepositorio _boardRepositorio;
        private readonly IIssuegRepositorio _issueRepositorio;
        private readonly IProjetoRepositorio _projetoRepositorio;
        private readonly IProjetoIntegracaoRepositorio _projetoIntegracaoRepositorio;
        private readonly ISprintRepositorio _sprintRepositorio;
        private readonly IDemandasRepostorio _demandasRepostory;
        private readonly ISquadRepositorio _squadRepositorio;

        public IntegradorJiraHandler(IBoardRepositorio boardRepositorio, IIssuegRepositorio issueRepositorio, IProjetoRepositorio projetoRepositorio, IProjetoIntegracaoRepositorio projetoIntegracaoRepositorio, ISprintRepositorio sprintRepositorio, IDemandasRepostorio demandasRepostory, ISquadRepositorio squadRepositorio)
        {
            _boardRepositorio = boardRepositorio;
            _issueRepositorio = issueRepositorio;
            _projetoRepositorio = projetoRepositorio;
            _projetoIntegracaoRepositorio = projetoIntegracaoRepositorio;
            _sprintRepositorio = sprintRepositorio;
            _demandasRepostory = demandasRepostory;
            _squadRepositorio = squadRepositorio;
        }

        public async Task<ICommandResult> Handle(IntegracaoInicialJiraCommand command)
        {
            if (!command.EhValido())
                return new IntegradorJiraCommandResult(false, "Não foi possível efetuar a integração", Notifications);

            _boardRepositorio.PreencherAcesso(command.Token, command.Url);
            var boardResult = await _boardRepositorio.Obter();

            if (boardResult == null || !boardResult.Boards.Any())
                return new IntegradorJiraCommandResult(false, "Não foram encontrados projetos para o endereço informado", null);
            
            foreach (var item in boardResult.Boards)
            {
                var projetoId = await InserirProjeto(item, command.OrganizacaoId);

                var sprints = await InserirSprints(command, item.Id, projetoId);

                var squadId = await _squadRepositorio.Inserir(Squad.PreencherInsercao(item.Name, projetoId));

                await InserirDemandas(command, sprints, item.Id, squadId);
            }

            return new IntegradorJiraCommandResult(true, "Integração efetuada com sucesso", boardResult);
        }

        private async Task<long> InserirProjeto(BoardQueryResult board, long organizacaoId)
        {
           var projeto = Projeto.PreencherInsercao(board, organizacaoId);
           var projetoId = await _projetoRepositorio.Inserir(projeto);

           var projetoIntegracao = ProjetoIntegracao.PreencherInsercao(board, projetoId);
            await _projetoIntegracaoRepositorio.Inserir(projetoIntegracao);

            return projetoId;
        }

        private async Task<List<Sprint>> InserirSprints(IntegracaoInicialJiraCommand command, int boardId, long projetoId)
        {
             _sprintRepositorio.PreencherAcesso(command.Token, command.Url);
            var sprintsJira = await _sprintRepositorio.ObterSprintsJira(boardId);

            var sprints =  Sprint.PreencherSprints(sprintsJira, projetoId);

            foreach (var item in sprints)
            {
                await _sprintRepositorio.Inserir(item);
            }

            var result = await _sprintRepositorio.Obter(projetoId);

            return result;

        }


        private async Task InserirDemandas(IntegracaoInicialJiraCommand command, List<Sprint> sprints, int boardId, long squadId)
        {
            _issueRepositorio.PreencherAcesso(command.Token, command.Url);

            var issues = await _issueRepositorio.Obter(boardId);

            var demandas = Demandas.PreencherDemandasJira(issues, sprints, sprints.First().ProjetoId, squadId);

            foreach (var item in demandas)
            {
                await _demandasRepostory.Inserir(item);
            }

        }
    }
}
