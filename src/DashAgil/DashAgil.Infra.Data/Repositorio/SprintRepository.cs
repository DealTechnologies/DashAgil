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
        public SprintRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sprints>> GetAllBySuqad(int squadId)
        {
            return await _context.Connection.QueryAsync<Sprints>(Queries.SprintQueries.GetAllBySquadId, new { SquadId = squadId });
        }

        public async Task<Sprints> GetSprintById(long sprintId)
            => await _context.Connection.QueryFirstOrDefaultAsync<Sprints>(Queries.SprintQueries.SprintById, new { sprintId });
    }
}
