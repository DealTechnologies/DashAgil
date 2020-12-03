using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using DashAgil.Integrador.Jira.Commands.Output;
using DashAgil.Integrador.Jira.Repositorio;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Jira.Handlers
{
    public class IntegradorJiraHandler : Notifiable, ICommandHandler<IntegracaoInicialCommand>
    {
        private readonly IBoardRepositorio _boardRepositorio;

        public IntegradorJiraHandler(IBoardRepositorio boardRepositorio)
        {
            _boardRepositorio = boardRepositorio;
        }
        public async Task<ICommandResult> Handle(IntegracaoInicialCommand command)
        {
            if (!command.EhValido())
                return new IntegradorJiraCommandResult(false, "Não foi possível efetuar a integração", Notifications);

            _boardRepositorio.PreencherAcesso(command.Token, command.Url);

            var result = await _boardRepositorio.Obter();

            return new IntegradorJiraCommandResult(true, "Integração efetuada com sucesso", result);
        }
    }
}
