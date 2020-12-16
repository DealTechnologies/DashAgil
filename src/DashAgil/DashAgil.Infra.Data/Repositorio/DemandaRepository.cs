using Dapper;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class DemandaRepository : BaseRepository<Demandas>, IDemandaRepository
    {
        public DemandaRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Demandas>> GetAll(string clienteId, int tipo, int squadId = 0)
        {
            return await _context.Connection.QueryAsync<Demandas>(Queries.DemandaQueries.GetAll, new { ClienteId = clienteId, Tipo = tipo, SquadId = squadId });
        }

        public async Task<IEnumerable<Demandas>> GetDemandas(string clienteId, int tipo)
        {
            return await _context.Connection.QueryAsync<Demandas, Squads, Demandas>(Queries.DemandaQueries.GetDemandas,
                (demanda, squad) =>
                {
                    demanda.Squad = squad;
                    return demanda;
                },
                new { ClienteId = clienteId, Tipo = tipo },
                splitOn: "SquadId, IdSquad");
        }

        public async Task<IEnumerable<dynamic>> GetFeaturesEstorias(string clienteId, string squadId)
        {
            return await _context.Connection.QueryAsync<dynamic>(Queries.DemandaQueries.GetFeaturesEstorias, new { ClienteId = clienteId, SquadId = squadId, @TipoEstoria = EDemandaTipo.UserStory, @TipoFeature = EDemandaTipo.Feature });
        }

        public async Task<IEnumerable<dynamic>> GetEstoriasHistorico(string clienteId, string squadId, string sprintId)
        {
            return await _context.Connection.QueryAsync<dynamic>(Queries.DemandaQueries.GetEstoriasHistorico, 
                new { 
                    ClienteId = clienteId, 
                    SquadId = squadId, 
                    SprintId = sprintId,
                    TipoDemanda = EDemandaTipo.UserStory });
        }

        //public async Task<IEnumerable<DemandasEstagio>> GetTotalDemandasPorEstagio(string ProjetoId)
        //{
        //    var query = "SELECT count(*) as Quantidade, Status FROM Demandas WHERE ProjetoId = @ProjetoId and Tipo = 3 GROUP BY Status";

        //    return await _context.Connection.QueryAsync<DemandasEstagio>(query, new { ProjetoId = ProjetoId });
        //}

        //public async Task<IEnumerable<DemandasSquad>> GetTotalDemandasPorSquad(string ProjetoId)
        //{
        //    var query = "SELECT count(*) as Quantidade, s.Nome as NomeSquad FROM Demandas d INNER JOIN Squads s on d.SquadId = s.Id WHERE d.ProjetoId = @ProjetoId and d.Tipo = 3 GROUP BY s.Nome";

        //    return await _context.Connection.QueryAsync<DemandasSquad>(query, new { ProjetoId = ProjetoId });
        //}
    }
}
