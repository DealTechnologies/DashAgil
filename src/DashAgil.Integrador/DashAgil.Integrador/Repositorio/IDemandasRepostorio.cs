using DashAgil.Integrador.Entidades;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IDemandasRepostorio : ICRUD<Demandas>
    {
        Task<long> Inserir(Demandas entity);
        Task<Demandas> ConsultarPorExternalId(string externalId);
    }
}
