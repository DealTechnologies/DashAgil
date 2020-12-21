using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class DemandasRepostorio : IDemandasRepostorio
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();

        public DemandasRepostorio(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Demandas>> Get()
        {
            return await _context.Connection.QueryAsync<Demandas>(Queries.DemandasQueries.Select);
        }

        public async Task<Demandas> GetByID(string id)
        {
            return await _context.Connection.QueryFirstAsync(Queries.DemandasQueries.SelectById, new { Id = id });
        }

        public async void Delete(string id)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Delete, new { Id = id });
        }

        public async void Update(Demandas entity)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Update, new
            {
                entity.Comentario,
                entity.DataCadastro,
                entity.DataFim,
                entity.DataInicio,
                entity.DataModificacao,
                entity.DemandaPaiId,
                entity.Descricao,
                entity.ExternalId,
                entity.HorasEstimadas,
                entity.HorasUtilizadas,
                entity.Id,
                entity.Pontos,
                entity.Prioridade,
                entity.ProjetoId,
                entity.Responsavel,
                entity.Risco,
                entity.SprintId,
                entity.SquadId,
                entity.Status,
                entity.Tags,
                entity.Tipo
            });
        }

        public async void Insert(Demandas entity)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Insert, new
            {
                entity.Id,
                entity.HorasEstimadas,
                entity.ExternalId,
                entity.Comentario,
                entity.DataCadastro,
                entity.DataFim,
                entity.DataInicio,
                entity.DataModificacao,
                entity.DemandaHistorico,
                entity.DemandaPaiId,
                entity.DemandaPaiIntegracaoId,
                entity.Descricao,
                entity.HorasRestantes,
                entity.HorasUtilizadas,
                entity.Pontos,
                entity.Prioridade,
                entity.ProjetoId,
                entity.Responsavel,
                entity.Risco,
                entity.SprintId,
                entity.SquadId,
                entity.Status,
                entity.Tags,
                entity.Tipo
            });
        }

        public async Task<long> Inserir(Demandas entity)
        {
            _param.Add("@Comentario", entity.Comentario);
            _param.Add("@DataCadastro", entity.DataCadastro);
            _param.Add("@DataFim", entity.DataFim);
            _param.Add("@DataInicio", entity.DataInicio);
            _param.Add("@DataModificacao", entity.DataModificacao);
            _param.Add("@DemandaPaiId", entity.DemandaPaiId);
            _param.Add("@Descricao", entity.Descricao);
            _param.Add("@ExternalId", entity.ExternalId);
            _param.Add("@HorasEstimadas", entity.HorasEstimadas);
            _param.Add("@HorasRestantes", entity.HorasRestantes);
            _param.Add("@HorasUtilizadas", entity.HorasUtilizadas);
            _param.Add("@Pontos", entity.Pontos);
            _param.Add("@Prioridade", entity.Prioridade);
            _param.Add("@ProjetoId", entity.ProjetoId);
            _param.Add("@Responsavel", entity.Responsavel);
            _param.Add("@Risco", entity.Risco);
            _param.Add("@SprintId", entity.SprintId);
            _param.Add("@Risco", entity.Risco);
            _param.Add("@SquadId", entity.SquadId);
            _param.Add("@Status", entity.Status);
            _param.Add("@Tags", entity.Tags);
            _param.Add("@Tipo", entity.Tipo);
            _param.Add("@Id", entity.Id, DbType.Guid);
            _param.Add("@Descricao", entity.Descricao);

            var result = await _context.Connection.ExecuteScalarAsync<long>(Queries.DemandasQueries.Insert, _param);

            return result;
        }

        public async Task<Demandas> ConsultarPorExternalId(string externalId)
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<Demandas>("select * from Demandas where ExternalId = @externalId ", new { externalId });
        }

        //Demandas
    }
}
