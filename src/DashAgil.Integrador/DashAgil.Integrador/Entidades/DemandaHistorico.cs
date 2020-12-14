using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades
{
    public class DemandaHistorico
    {
        public DemandaHistorico(string externalId = null, long? sprintId = null, long? projetoId = null, long? squadId = null, long? tipo = null, Guid? demandaPaiId = null, string responsavel = null, DateTime? dataInicio = null,
            DateTime? dataModificacao = null, DateTime? dataFim = null, int? pontos = null, string tags = null, int? prioridade = null, int? horasEstimadas = null, int? horasRestantes = null,
            int? horasUtilizadas = null, int? risco = null, string comentario = null, int? status = null)
        {
            ExternalId = externalId;
            SprintId = sprintId;
            ProjetoId = projetoId;
            SquadId = squadId;
            Tipo = tipo;
            DemandaPaiId = demandaPaiId;
            Responsavel = responsavel;
            DataInicio = dataInicio;
            DataModificacao = dataModificacao;
            DataFim = dataFim;
            Pontos = pontos;
            Tags = tags;
            Prioridade = prioridade;
            HorasEstimadas = horasEstimadas;
            HorasRestantes = horasRestantes;
            HorasUtilizadas = horasUtilizadas;
            Risco = risco;
            Comentario = comentario;
            Status = status;
        }

        public DemandaHistorico()
        {

        }

        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public long? SprintId { get; set; }
        public long? ProjetoId { get; set; }
        public long? SquadId { get; set; }
        public long? Tipo { get; set; }
        public Guid? DemandaPaiId { get; set; }
        public string Responsavel { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataFim { get; set; }
        public long? Pontos { get; set; }
        public string Tags { get; set; }
        public int? Prioridade { get; set; }
        public int? HorasEstimadas { get; set; }
        public int? HorasRestantes { get; set; }
        public int? HorasUtilizadas { get; set; }
        public int? Risco { get; set; }
        public string Comentario { get; set; }
        public int? Status { get; set; }

    }
}
