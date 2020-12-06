﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades
{
    public class Projeto
    {
        public int Id { get; set; }
        public int? ExternalId { get; set; }
        public int OrganizacaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataExclusao { get; set; }

    }
}
