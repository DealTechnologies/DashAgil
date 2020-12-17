using System;

namespace DashAgil.Integrador.Entidades
{
    public class Organizacoes
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
    }
}
