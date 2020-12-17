using DashAgil.Commands.Input.Cliente;
using DashAgil.Commands.Output;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class ClienteHandler : ICommandHandler<ObterClientesPorProvedorCommand>
    {
        protected readonly IClienteRepository _repository;
        public ClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterClientesPorProvedorCommand command)
        {
            var Clientes = await _repository.GetClientesByProvedor(command.IdProvedor, command.IdUsuario);
            
            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", Clientes);
        }        
    }
}
