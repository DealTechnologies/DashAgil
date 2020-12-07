using System;

namespace DashAgil.Integrador.Entidades
{
    public class Sprints
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public long ProjetId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int Status { get; set; }
    }
}
