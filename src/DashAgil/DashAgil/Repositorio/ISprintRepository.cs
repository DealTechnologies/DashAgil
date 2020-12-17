using DashAgil.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface ISprintRepository : IRepository<Sprints>
    {
        Task<IEnumerable<Sprints>> GetAllByCliente(string clienteId, string usuarioId);
    }
}