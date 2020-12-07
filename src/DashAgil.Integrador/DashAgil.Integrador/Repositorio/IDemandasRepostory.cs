using DashAgil.Integrador.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IDemandasRepostory
    {
        Task<IEnumerable<Demandas>> Get();
        Task<Demandas> GetByID(string id);
        void Delete(string id);
        void Update(Demandas demanda);
        void Insert(Demandas demanda);
    }
}
