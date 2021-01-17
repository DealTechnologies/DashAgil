using Dapper;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class ProvedorRepository : BaseRepository<Provedores>, IProvedorRepository
    {
        public ProvedorRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Provedores>> GetAllAtivos()
        {
            return await _context.Connection.QueryAsync<Provedores>(Queries.ProvedorQueries.GetAllAtivos);
        }
    }
}
