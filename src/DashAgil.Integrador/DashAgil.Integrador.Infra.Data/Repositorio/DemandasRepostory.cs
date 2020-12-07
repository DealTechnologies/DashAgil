using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class DemandasRepostory : IDemandasRepostory
    {
        private readonly  DataContext _context;

        public DemandasRepostory(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Demandas>> Get()
        {
            return await _context.Connection.QueryAsync<Demandas>(Queries.DemandasQueries.Select);
        }

        public async Task<Demandas> GetByID(string id)
        {
            return await _context.Connection.QueryFirstAsync(Queries.DemandasQueries.SelectById, new { id });
        }

        public async void Delete(string id)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Delete, new { id });
        }

        public async void Update(Demandas demanda)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Update, new
            {
                demanda.Comentario,
                demanda.DataCadastro,
                demanda.DataFim,
                demanda.DataInicio,
                demanda.DataModificacao,
                demanda.DemandaPaiId,
                demanda.Descricao,
                demanda.ExternalId,
                demanda.HorasEstimadas,
                demanda.HorasUtilizadas,
                demanda.Id,
                demanda.Pontos,
                demanda.Prioridade,
                demanda.ProjetoId,
                demanda.Responsavel,
                demanda.Risco,
                demanda.SprintId,
                demanda.SquadId,
                demanda.Status,
                demanda.Tags,
                demanda.Tipo
            });
        }

        public async void Insert(Demandas demanda)
        {
            await _context.Connection.ExecuteAsync(Queries.DemandasQueries.Insert, new
            {
                demanda.Comentario,
                demanda.DataCadastro,
                demanda.DataFim,
                demanda.DataInicio,
                demanda.DataModificacao,
                demanda.DemandaPaiId,
                demanda.Descricao,
                demanda.ExternalId,
                demanda.HorasEstimadas,
                demanda.HorasRestantes,
                demanda.HorasUtilizadas,
                demanda.Id,
                demanda.Pontos,
                demanda.Prioridade,
                demanda.ProjetoId,
                demanda.Responsavel,
                demanda.Risco,
                demanda.SprintId,
                demanda.SquadId,
                demanda.Status,
                demanda.Tags,
                demanda.Tipo
            });
        }

        //Demandas
    }
}
