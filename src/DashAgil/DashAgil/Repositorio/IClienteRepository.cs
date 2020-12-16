using DashAgil.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IClienteRepository : IRepository<Clientes>
    {
        Task<IEnumerable<Clientes>> GetClientesByProvedor(string provedorId);
    }
}