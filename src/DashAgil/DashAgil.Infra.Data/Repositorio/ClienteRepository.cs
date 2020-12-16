using Dapper;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class ClienteRepository : BaseRepository<Clientes>, IClienteRepository
    {
        public ClienteRepository(DataContext context): base(context)
        {
        }

        public async Task<IEnumerable<Clientes>> GetClientesByProvedor(string provedorId)
        {
            return await _context.Connection.QueryAsync<Clientes>(Queries.ClienteQueries.GetAllByProvedor, new { ProvedorId = provedorId });
        }
    }
}
