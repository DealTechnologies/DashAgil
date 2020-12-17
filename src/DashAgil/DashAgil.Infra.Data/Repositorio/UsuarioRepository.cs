using Dapper;
using DashAgil.Entidades;
using DashAgil.Entidades.DTO;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class UsuarioRepository : BaseRepository<dynamic>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context)
        {

        }

        public async Task<Usuario> ObterAsync(string email, string password) =>
            await _context.Connection.QueryFirstOrDefaultAsync<Usuario>("select * from Usuarios where Email = @Email and Password = @Password", new { email, password });

        public async Task<IEnumerable<UsuarioDTO>> ObterAcessosAsync(Guid clienteId)
        {
            var usuarioDictionary = new Dictionary<Guid, UsuarioDTO>();
            var provedoresDictionary = new Dictionary<int, ProvedoresDTO>();
            var clientesDictionary = new Dictionary<int, ClientesDTO>();
            var squadsDictionary = new Dictionary<long, SquadsDTO>();

            var result = await _context.Connection.QueryAsync<UsuarioDTO, ProvedoresDTO, ClientesDTO, SquadsDTO, UsuarioDTO>(@"
                select
	                U.Id,
	                U.Nome,

                    P.Id as ProvedorDivisor,
	                P.Id as Id,
	                P.Descricao,

                    C.Id as ClienteDivisor,
	                C.Id as Id,
	                C.Nome,
                    
                    S.Id as SquadDivisor,
                    S.Id,
                    S.Nome,
                    S.ProjetoId,
                    S.Status
                from 
	                UsuarioSquads US
	                inner join Usuarios U on US.UsuarioId = U.Id
                    inner join Squads S on US.SquadId = S.Id
	                inner join Clientes C on US.ClienteId = C.Id
	                inner join Provedores P on C.ProvedorId = P.Id
                where 
	                U.Id = @Id",
                 (usuario, provedor, cliente, squad) =>
                 {
                     if (!usuarioDictionary.TryGetValue(usuario.Id, out var usuarioEntry))
                     {
                         usuarioEntry = usuario;
                         usuario.Provedores = new List<ProvedoresDTO>();
                         usuarioDictionary.Add(usuario.Id, usuarioEntry);
                     }

                     if (!provedoresDictionary.TryGetValue(provedor.Id, out var provedorEntry))
                     {
                         provedorEntry = provedor;
                         provedor.Clientes = new List<ClientesDTO>();
                         provedoresDictionary.Add(provedor.Id, provedorEntry);
                         usuarioEntry.Provedores.Add(provedor);
                     }

                     if (!clientesDictionary.TryGetValue(cliente.Id, out var clienteEntry))
                     {
                         clienteEntry = cliente;
                         cliente.Squads = new List<SquadsDTO>();
                         clientesDictionary.Add(cliente.Id, clienteEntry);
                         provedorEntry.Clientes.Add(cliente);
                     }

                     clienteEntry.Squads.Add(squad);
                     return usuarioEntry;
                 },
                 new { Id = clienteId },
                 splitOn: "ProvedorDivisor, ClienteDivisor, SquadDivisor");

            return result.Distinct().ToList();
        }
    }
}
