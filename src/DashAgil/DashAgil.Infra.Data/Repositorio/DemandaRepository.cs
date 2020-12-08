using Dapper;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class DemandaRepository : BaseRepository<Demanda>, IDemandaRepository
    {
        public DemandaRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Demanda>> GetAll(string projetoId, int tipo, int squadId = 0)
        {
            return await _context.Connection.QueryAsync<Demanda>(Queries.DemandaQueries.GetAll, new { ProjetoId = projetoId, Tipo = tipo, SquadId = squadId });
        }

        public async Task<IEnumerable<Demanda>> GetDemandas(string projetoId, int tipo)
        {
            return _context.Connection.Query<Demanda, Squad, Demanda>(Queries.DemandaQueries.GetDemandas,
                (demanda, squad) =>
                {
                    demanda.Squad = squad;
                    return demanda;
                },
                new { ProjetoId = projetoId, Tipo = tipo },
                splitOn: "SquadId, Id");
        }

        public async Task<IEnumerable<dynamic>> GetFeaturesEstorias(string projetoId, string squadId)
        {
            return await _context.Connection.QueryAsync<dynamic>(Queries.DemandaQueries.GetFeaturesEstorias, new { ProjetoId = projetoId, SquadId = squadId, @TipoEstoria = EDemandaTipo.UserStory, @TipoFeature = EDemandaTipo.Feature });
        }

        public async Task<IEnumerable<dynamic>> GetEstoriasHistorico(string projetoId, string squadId, string sprintId)
        {
            return await _context.Connection.QueryAsync<dynamic>(Queries.DemandaQueries.GetEstoriasHistorico, 
                new { ProjetoId = projetoId, 
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
