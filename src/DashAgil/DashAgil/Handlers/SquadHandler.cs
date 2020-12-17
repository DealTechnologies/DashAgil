using DashAgil.Commands.Input.Squad;
using DashAgil.Commands.Output;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class SquadHandler : ICommandHandler<ObterSquadsPorClienteCommand>
    {
        protected readonly ISquadRepository _repository;
        public SquadHandler(ISquadRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterSquadsPorClienteCommand command)
        {
            var Squades = await _repository.GetAllAtivosByCliente(command.IdCliente, command.IdUsuario);
            
            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", Squades);
        }        
    }
}
