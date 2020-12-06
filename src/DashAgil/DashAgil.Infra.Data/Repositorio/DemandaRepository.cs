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

        public async Task<IEnumerable<Demanda>> GetAll(string projetoId, int tipo)
        {
            var query = @"SELECT d.Id, d.SquadId, d.Tipo, d.DataInicio, d.DataModificacao, d.DataFim, d.Pontos, d.Status, d.Descricao, v.status_novo_num as StatusDeXPara
                           FROM Demandas d 
                                INNER JOIN v_estoria_status_dexpara v on d.status = v.status_num
                          WHERE d.ProjetoId = @ProjetoId 
                                and d.Tipo = @Tipo";

            return await _context.Connection.QueryAsync<Demanda>(query, new { ProjetoId = projetoId, Tipo = tipo });
        }

        public async Task<IEnumerable<Demanda>> GetDemandas(string projetoId, int tipo)
        {
            var query = @"SELECT d.Id, d.SquadId, d.Tipo, d.DataInicio, d.DataModificacao, d.DataFim, d.Pontos, d.Status, d.Descricao, v.status_novo_num as StatusDeXPara,
                                 s.Id, s.Nome   
                           FROM Demandas d 
                                INNER JOIN Squads s on d.SquadId = s.Id
                                INNER JOIN v_estoria_status_dexpara v on d.status = v.status_num
                          WHERE d.ProjetoId = @ProjetoId 
                                and d.Tipo = @Tipo";

            return _context.Connection.Query<Demanda, Squad, Demanda>(query,
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
            var query = @"SELECT features.id as FeatureId, features.descricao as FeatureDescricao, 
                                 estorias.Id, estorias.SquadId, estorias.Tipo, estorias.DataInicio, estorias.DataModificacao, estorias.DataFim, 
                                 estorias.Pontos, estorias.Status, v.status_novo_num as StatusDeXPara, estorias.Descricao
                          FROM Demandas features
                               INNER JOIN Demandas estorias on features.Id = estorias.DemandaPaiId and estorias.Tipo = @TipoEstoria
                               INNER JOIN v_estoria_status_dexpara v on estorias.status = v.status_num
                          WHERE features.ProjetoId = @ProjetoId
                                and features.Tipo = @TipoFeature
                                and features.SquadId = @SquadId";

            return await _context.Connection.QueryAsync<dynamic>(query, new { ProjetoId = projetoId, SquadId = squadId, @TipoEstoria = EDemandaTipo.UserStory, @TipoFeature = EDemandaTipo.Feature });
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
