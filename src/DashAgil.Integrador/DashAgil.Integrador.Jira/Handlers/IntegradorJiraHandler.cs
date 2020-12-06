using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using DashAgil.Integrador.Jira.Commands.Output;
using DashAgil.Integrador.Jira.Repositorio;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Jira.Handlers
{
    public class IntegradorJiraHandler : Notifiable, ICommandHandler<IntegracaoInicialCommand>
    {
        private readonly IBoardRepositorio _boardRepositorio;
        private readonly IBacklogRepositorio _backlogRepositorio;

        public IntegradorJiraHandler(IBoardRepositorio boardRepositorio, IBacklogRepositorio backlogRepositorio)
        {
            _boardRepositorio = boardRepositorio;
            _backlogRepositorio = backlogRepositorio;
        }
        public async Task<ICommandResult> Handle(IntegracaoInicialCommand command)
        {
            if (!command.EhValido())
                return new IntegradorJiraCommandResult(false, "Não foi possível efetuar a integração", Notifications);

            _boardRepositorio.PreencherAcesso(command.Token, command.Url);

            var boradResult = await _boardRepositorio.Obter();

            if(boradResult == null || !boradResult.Boards.Any())
                return new IntegradorJiraCommandResult(false, "Não foram encontrados projetos para o endereço informado", null);

            _backlogRepositorio.PreencherAcesso(command.Token, command.Url);

            foreach (var item in boradResult.Boards)
            {
                var backlog = await _backlogRepositorio.Obter(item.Id);
            }

            return new IntegradorJiraCommandResult(true, "Integração efetuada com sucesso", boradResult);
        }
    }
}
