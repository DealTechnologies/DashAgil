using DashAgil.Email.Entidades.DTO;
using DashAgil.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Email.Repositorio
{
    public interface IEmailRepositorio
    {
        Task<IEnumerable<Emails>> ListarAsync();

        Task<Emails> ObterAsync(Guid id);

        Task<EmailStatusDTO> ObterCountAsync();

        Task AdicionarAsync(Emails emails);

        Task AtualizarAsync(Emails emails);
    }
}
