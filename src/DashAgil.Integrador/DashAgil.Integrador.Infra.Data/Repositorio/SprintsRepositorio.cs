using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class SprintsRepositorio : ISprintsRepositorio
    {
        private readonly DataContext _context;

        public SprintsRepositorio(DataContext context)
        {
            _context = context;
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Sprint>> Get()
        {
            return await _context.Connection.QueryAsync<Sprint>(Queries.SprintsQueries.Select);
        }

        public async Task<Sprint> GetByID(string id)
        {
            return await _context.Connection.QueryFirstAsync(Queries.SprintsQueries.SelectById, new { Id = id });
        }

        public async void Insert(Sprint entity)
        {
            await _context.Connection.ExecuteAsync(Queries.SprintsQueries.Insert, new
            {
                entity.ExternalId,
                entity.DataConclusao,
                entity.DataFim,
                entity.DataInicio,
                entity.Descricao,
                entity.Nome, 
                entity.Status
            });
        }

        public async void Update(Sprint entity)
        {
            await _context.Connection.ExecuteAsync(Queries.SprintsQueries.Update, new
            {
                entity.Id,
                entity.ExternalId,
                entity.DataConclusao,
                entity.DataFim,
                entity.DataInicio,
                entity.Descricao,
                entity.Nome,  
                entity.Status
            });
        }
    }
}
