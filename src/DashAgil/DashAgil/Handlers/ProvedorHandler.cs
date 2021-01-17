using DashAgil.Commands.Output;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class ProvedorHandler
    {
        protected readonly IProvedorRepository _repository;
        public ProvedorHandler(IProvedorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle()
        {
            var provedores = await _repository.GetAllAtivos();
            
            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", provedores);
        }        
    }
}
