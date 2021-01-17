using System.Threading.Tasks;

namespace DashAgil.Infra.Comum
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        Task<ICommandResult> Handle(T command);
    }
}
