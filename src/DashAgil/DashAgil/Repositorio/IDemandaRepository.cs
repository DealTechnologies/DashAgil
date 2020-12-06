using DashAgil.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IDemandaRepository : IRepository<Demanda>
    {
        Task<IEnumerable<Demanda>> GetAll(string clienteId, int tipo);
        Task<IEnumerable<Demanda>> GetDemandas(string idCliente, int tipo);
        Task<IEnumerable<dynamic>> GetFeaturesEstorias(string clienteId, string squadId);
        //Task<IEnumerable<DemandasEstagio>> GetTotalDemandasPorEstagio(string idCliente);
        //Task<IEnumerable<DemandasSquad>> GetTotalDemandasPorSquad(string clienteId);
    }
}
