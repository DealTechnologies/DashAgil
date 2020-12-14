using DashAgil.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface ISquadRepository : IRepository<Squads>
    {
        Task<IEnumerable<Squads>> GetAllAtivosByCliente(string clienteId);
    }
}