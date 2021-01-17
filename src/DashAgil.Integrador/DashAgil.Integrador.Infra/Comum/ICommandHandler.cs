using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Comum
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        Task<ICommandResult> Handle(T command);
    }
}
