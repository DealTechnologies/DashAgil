using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using DashAgil.Integrador.Jira.Commands.Output;
using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Repositorio;
using DashAgil.Integrador.Repositorio;
using Flunt.Notifications;
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

        public IntegradorJiraHandler(IBoardRepositorio boardRepositorio, IIssuegRepositorio issueRepositorio, IProjetoRepositorio projetoRepositorio, IProjetoIntegracaoRepositorio projetoIntegracaoRepositorio)
        {
            _boardRepositorio = boardRepositorio;
            _issueRepositorio = issueRepositorio;
            _projetoRepositorio = projetoRepositorio;
            _projetoIntegracaoRepositorio = projetoIntegracaoRepositorio;
        }

        public async Task<ICommandResult> Handle(IntegracaoInicialJiraCommand command)
        {
            if (!command.EhValido())
                return new IntegradorJiraCommandResult(false, "Não foi possível efetuar a integração", Notifications);

            _boardRepositorio.PreencherAcesso(command.Token, command.Url);

            var boardResult = await _boardRepositorio.Obter();

            if (boardResult == null || !boardResult.Boards.Any())
                return new IntegradorJiraCommandResult(false, "Não foram encontrados projetos para o endereço informado", null);

            _issueRepositorio.PreencherAcesso(command.Token, command.Url);

            var issues = await _issueRepositorio.Obter(6);
            //foreach (var item in boardResult.Boards)
            //{
            //    var projetoId = await InserirProjeto(item, command.OrganizacaoId);

            //    var backlog = await _backlogRepositorio.Obter(item.Id);
            //}

            return new IntegradorJiraCommandResult(true, "Integração efetuada com sucesso", boardResult);
        }

        public async Task<long> InserirProjeto(BoardQueryResult board, long organizacaoId)
        {
           var projeto = Projeto.PreencherInsercao(board, organizacaoId);
           var projetoId = await _projetoRepositorio.Inserir(projeto);

           var projetoIntegracao = ProjetoIntegracao.PreencherInsercao(board, projetoId);
            await _projetoIntegracaoRepositorio.Inserir(projetoIntegracao);

            return projetoId;
        }
    }
}
