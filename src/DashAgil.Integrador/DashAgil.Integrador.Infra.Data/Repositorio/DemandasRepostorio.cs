using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class DemandasRepostorio : IDemandasRepostorio
    {
        private readonly DataContext _context;

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

        //Demandas
    }
}
