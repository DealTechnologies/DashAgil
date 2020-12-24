using DashAgil.Commands.Input.Sprint;
using DashAgil.Commands.Output;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class SprintHandler : ICommandHandler<ObterSprintsPorClienteCommand>
    {
        protected readonly ISprintRepository _repository;
        public SprintHandler(ISprintRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterSprintsPorClienteCommand command)
        {
            var Sprintes = await _repository.GetAllByCliente(command.IdCliente, command.IdUsuario);
            
            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", Sprintes);
        }        
    }
}
