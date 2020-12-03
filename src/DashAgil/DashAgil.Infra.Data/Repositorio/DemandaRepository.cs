using Dapper;
using DashAgil.Entidades;
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

        public async Task<IEnumerable<Demanda>> GetAll(string clienteId, int tipo)
        {
            var query = "SELECT * FROM Demandas WHERE ClienteId = @ClienteId and Tipo = @Tipo";

            return await _context.Connection.QueryAsync<Demanda>(query, new { ClienteId = clienteId, Tipo = tipo });
        }

        public async Task<IEnumerable<Demanda>> GetDemandas(string clienteId, int tipo)
        {
            var query = "SELECT d.*, s.Nome FROM Demandas d INNER JOIN Squads s on d.SquadId = s.Id WHERE d.ClienteId = @ClienteId and d.Tipo = @Tipo";

            return _context.Connection.Query<Demanda, Squad, Demanda>(query,
                (demanda, squad) =>
                {
                    demanda.Squad = squad;
                    return demanda;
                },
                new { ClienteId = clienteId, Tipo = tipo },
                splitOn: "SquadId");
        }

        public async Task<IEnumerable<dynamic>> GetFeaturesEstorias(string clienteId)
        {
            var query = @"SELECT features.Id, features., estorias.*
                          FROM Demandas features
                               INNER JOIN Demandas estorias on features.Id = estorias.DemandaPaiId and estorias.Tipo = 3
                          WHERE features.ClienteId = 1
                                and features.Tipo = 2 
                                and features.ClienteId = @ClienteId";

            return await _context.Connection.QueryAsync<dynamic>(query, new { ClienteId = clienteId });
        }

        //public async Task<IEnumerable<DemandasEstagio>> GetTotalDemandasPorEstagio(string clienteId)
        //{
        //    var query = "SELECT count(*) as Quantidade, Status FROM Demandas WHERE ClienteId = @ClienteId and Tipo = 3 GROUP BY Status";

        //    return await _context.Connection.QueryAsync<DemandasEstagio>(query, new { ClienteId = clienteId });
        //}

        //public async Task<IEnumerable<DemandasSquad>> GetTotalDemandasPorSquad(string clienteId)
        //{
        //    var query = "SELECT count(*) as Quantidade, s.Nome as NomeSquad FROM Demandas d INNER JOIN Squads s on d.SquadId = s.Id WHERE d.ClienteId = @ClienteId and d.Tipo = 3 GROUP BY s.Nome";

        //    return await _context.Connection.QueryAsync<DemandasSquad>(query, new { ClienteId = clienteId });
        //}
    }
}
