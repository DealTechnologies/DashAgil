using DashAgil.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Queries
{
    public class DemandaSprintQueryResult
    {
        public Guid Id { get; set; }
        public long? SquadId { get; set; }
        public EDemandaTipo Tipo { get; set; }
        public string Descricao { get; set; }
        public int? Pontos { get; set; }
        public string SprintNome { get; set; }
        public DateTime SprintDataInicio { get; set; }
        public DateTime SprintDataFim { get; set; }
        public Guid IdHistorico { get; set; }
        public DateTime DataModificacao { get; set; }
        public int StatusDeXPara { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
