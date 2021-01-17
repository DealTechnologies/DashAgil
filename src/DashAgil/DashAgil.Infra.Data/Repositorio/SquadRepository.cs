using Dapper;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class SquadRepository : BaseRepository<Squads>, ISquadRepository
    {
        public SquadRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Squads>> GetAllAtivosByCliente(string clienteId, string usuarioId)
        {
            return await _context.Connection.QueryAsync<Squads>(Queries.SquadQueries.GetAllAtivosByCliente, new { ClienteId = clienteId, UsuarioId = usuarioId });
        }
    }
}
