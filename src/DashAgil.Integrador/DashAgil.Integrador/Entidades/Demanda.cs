
using System;

namespace DashAgil.Integrador.Entidades
{
    public class Demanda : EntidadeDashAgil
    {
        public int ExternalId { get; set; }
        public int ClienteId { get; set; }
        public int SquadId { get; set; }
        public int TipoId { get; set; }
        public string DemandaPaiId { get; set; }
        public string ResponsavelId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataFim { get; set; }
        public int? Pontos { get; set; }
        public string Tags { get; set; }
        public int? Prioridade { get; set; }
        public int? HorasEstimadas { get; set; }
        public int? HorasUtilizadas { get; set; }
        public int? Risco { get; set; }
        public string Comentario { get; set; }
        public int? Status { get; set; }
    }
}
