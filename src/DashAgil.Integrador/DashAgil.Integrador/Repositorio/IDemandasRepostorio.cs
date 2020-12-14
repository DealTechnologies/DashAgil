using DashAgil.Integrador.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IDemandasRepostorio : ICRUD<Demandas>
    {
        Task<long> Inserir(Demandas entity);
    }
}
