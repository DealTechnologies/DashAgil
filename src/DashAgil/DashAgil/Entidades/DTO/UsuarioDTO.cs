using System;
using System.Collections.Generic;

namespace DashAgil.Entidades.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public List<ProvedoresDTO> Provedores { get; set; }
    }
}
