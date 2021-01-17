using DashAgil.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IProvedorRepository : IRepository<Provedores>
    {
        Task<IEnumerable<Provedores>> GetAllAtivos();
    }
}