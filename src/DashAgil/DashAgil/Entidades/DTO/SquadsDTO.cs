using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Entidades.DTO
{
    public class SquadsDTO
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public int ProjetoId { get; set; }

        public bool Status { get; set; }
    }
}
