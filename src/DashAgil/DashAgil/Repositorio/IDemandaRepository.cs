using DashAgil.Entidades;
using DashAgil.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IDemandaRepository : IRepository<Demandas>
    {
        Task<IEnumerable<Demandas>> GetAll(string clienteId, int tipo, string usuarioId, string squadId = "");
        Task<IEnumerable<Demandas>> GetDemandas(string idCliente, int tipo, string usuarioId);
        Task<IEnumerable<dynamic>> GetFeaturesEstorias(string clienteId, string squadId, string usuarioId);
        Task<IEnumerable<DemandaSprintQueryResult>> GetEstoriasHistorico(string projetoId, string squadId, string sprintId, string usuarioId);
        Task<IEnumerable<Demandas>> GetDemandasSprint(string clienteId, int tipo, string squadId, string usuarioId);
        //Task<IEnumerable<DemandasEstagio>> GetTotalDemandasPorEstagio(string idCliente);
        //Task<IEnumerable<DemandasSquad>> GetTotalDemandasPorSquad(string clienteId);
    }
}
