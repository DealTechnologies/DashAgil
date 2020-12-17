﻿using DashAgil.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IDemandaRepository : IRepository<Demandas>
    {
        Task<IEnumerable<Demandas>> GetAll(string clienteId, int tipo, string squadId = "");
        Task<IEnumerable<Demandas>> GetDemandas(string idCliente, int tipo);
        Task<IEnumerable<dynamic>> GetFeaturesEstorias(string clienteId, string squadId);
        Task<IEnumerable<dynamic>> GetEstoriasHistorico(string projetoId, string squadId, string sprintId);
        Task<IEnumerable<Demandas>> GetDemandasSprint(string clienteId, int tipo, string squadId);
        //Task<IEnumerable<DemandasEstagio>> GetTotalDemandasPorEstagio(string idCliente);
        //Task<IEnumerable<DemandasSquad>> GetTotalDemandasPorSquad(string clienteId);
    }
}
