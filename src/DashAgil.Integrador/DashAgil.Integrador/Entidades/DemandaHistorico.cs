using DashAgil.Integrador.Entidades.Devops;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsInt(string value)
        {
            try
            {
                Convert.ToInt32(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<DemandaHistorico> PreencherDemandaHistoricoDevops(IList<WorkItemHistoric> historico, string externalId, long projetoId, long? sprintId, long squadId )
        {
            try
            {
                return historico.ToList().ConvertAll(s => new DemandaHistorico
                {
                    ExternalId = externalId,
                    Pontos = (s.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue) is null ? 0 :
                                    !IsInt(s.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue) ?  0:  Convert.ToInt32(s.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue),
                    Prioridade = (s.Fields?.MicrosoftVstsSchedulingStoryPoints?.NewValue) is null ? 0:
                                !IsInt(s.Fields?.MicrosoftVstsCommonPriority?.NewValue) ? 0 :  Convert.ToInt32(s.Fields?.MicrosoftVstsCommonPriority?.NewValue),
                    ProjetoId = projetoId,
                    DataModificacao = string.IsNullOrEmpty(s.Fields?.SystemChangedDate?.NewValue) ? DataModificacao : DateTime.Parse(s.Fields?.SystemChangedDate?.NewValue),
                    HorasEstimadas = string.IsNullOrEmpty(s.Fields?.OriginalEstimate?.NewValue) ? 0 : Convert.ToInt32(s.Fields?.OriginalEstimate?.NewValue.Split(".")[0]),
                    HorasUtilizadas = string.IsNullOrEmpty(s.Fields?.CompletedWork?.NewValue) ? 0 : Convert.ToInt32(s.Fields?.CompletedWork?.NewValue.Split(".")[0]),
                    DataInicio = DateTime.Parse(historico.FirstOrDefault(x => x.Fields?.SystemCreatedDate?.NewValue != null).Fields?.SystemCreatedDate?.NewValue),
                    DataFim = string.IsNullOrEmpty(s.Fields?.MicrosoftVstsSchedulingFinishDate?.NewValue) ? DataFim : DateTime.Parse(s.Fields?.MicrosoftVstsSchedulingFinishDate?.NewValue),
                    SprintId = sprintId,
                    DemandaPaiId = null,
                    Responsavel = s.Fields?.SystemAssignedTo?.NewValue?.DisplayName,
                    SquadId = squadId,
                    Status = Demandas.ObterStatusDemanda(s.Fields?.SystemState?.NewValue),
                    Tipo = Demandas.ObterTipoWorkItemDevops(s.Fields?.SystemWorkItemType?.NewValue ?? s.Fields?.SystemWorkItemType?.OldValue),
                }); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid Id { get; set; } = Guid.NewGuid();
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
