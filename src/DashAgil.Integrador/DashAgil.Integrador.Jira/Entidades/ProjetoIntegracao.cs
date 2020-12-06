using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Entidades
{
    public class ProjetoIntegracao
    {
        public int ProjetoId { get; set; }

        public int ProjetotoIntegracaoId { get; set; }

        public int? ProjetoOrigemId { get; set; }

        public int ProvedorId { get; set; }

        public string UrlOrigem { get; set; }
    }
}
