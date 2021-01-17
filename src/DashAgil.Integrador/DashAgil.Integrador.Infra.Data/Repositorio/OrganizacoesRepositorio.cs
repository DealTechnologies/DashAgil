using Dapper;
using Dapper.Contrib.Extensions;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class OrganizacoesRepositorio : IOrganizacoesRepositorio
    {
        private readonly DataContext _context;

        public OrganizacoesRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<long> Inserir(Organizacoes org)
        => await _context.Connection.InsertAsync(org);

        public async Task<Organizacoes> ObterPorID(long id)
        => await _context.Connection.QueryFirstOrDefaultAsync<Organizacoes>("select * from Organizacoes where Id = @id", new { id });

        public async Task<Organizacoes> ObterPorNome(string nome)
        => await _context.Connection.QueryFirstOrDefaultAsync<Organizacoes>("select * from Organizacoes where Nome = @nome", new { nome });
    }
}
