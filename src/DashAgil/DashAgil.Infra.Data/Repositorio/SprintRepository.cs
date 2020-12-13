using Dapper;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class SprintRepository : BaseRepository<Sprints>, ISprintRepository
    {
        public SprintRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Sprints>> GetAllByCliente(string clienteId)
        {
            return await _context.Connection.QueryAsync<Sprints>(Queries.SprintQueries.GetAllByCliente, new { ClienteId = clienteId });
        }
    }
}
