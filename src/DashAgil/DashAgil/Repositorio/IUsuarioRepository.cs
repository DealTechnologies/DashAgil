using DashAgil.Entidades;
using DashAgil.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterAsync(string email, string password);

        Task<IEnumerable<UsuarioDTO>> ObterAcessosAsync(Guid clienteId);
    }
}
