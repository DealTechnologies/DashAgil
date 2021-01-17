using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Entidades;
using DashAgil.Infra.Comum;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class DashAgilHandler : ICommandHandler<SalvarEstoriaCommand>
    {
        public async Task<ICommandResult> Handle(SalvarEstoriaCommand command)
        {
            //var estoria = new Demanda(command.Nome, command.Descricao);

            //salvar
            var result = true;

            await Task.CompletedTask;

            return new DashAgilCommandResult(true, "sucess", result);
        }
    }
}
