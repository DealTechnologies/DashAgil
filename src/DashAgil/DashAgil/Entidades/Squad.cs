using System;

namespace DashAgil.Entidades
{
    public class Squad
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public long SubSquadId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Status { get; set; }
    }
}
