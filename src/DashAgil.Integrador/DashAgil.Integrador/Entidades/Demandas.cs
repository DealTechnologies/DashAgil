
using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Jira.Queries.Issues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashAgil.Integrador.Entidades
{
    public class Demandas : EntidadeDashAgil
    {
        public string ExternalId { get; set; }
        public long? SprintId { get; set; }
        public long ProjetoId { get; set; }
        public long? SquadId { get; set; }
        public long? Tipo { get; set; }
        public Guid? DemandaPaiId { get; set; }
        public string DemandaPaiIntegracaoId { get; set; }
        public string Responsavel { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataFim { get; set; }
        public long? Pontos { get; set; }
        public string Tags { get; set; }
        public int? Prioridade { get; set; }
        public int? HorasEstimadas { get; set; }
        public int? HorasUtilizadas { get; set; }
        public int? HorasRestantes { get; set; }
        public int? Risco { get; set; }
        public string Comentario { get; set; }
        public int? Status { get; set; }
        public string Descricao { get; set; }
        public DemandaHistorico DemandaHistorico { get; set; }


        public static Demandas PreencherDemandaDevops(WorkItemResult workItens, long projetoId, long squadId, long sprintId)
        {
            return new Demandas
            {
                ProjetoId = projetoId,
                ExternalId = workItens.Id.ToString(),
                DataInicio = string.IsNullOrEmpty(workItens.Fields.ActivatedDate) ? DateTime.Now : Convert.ToDateTime(workItens.Fields.ActivatedDate),
                DataFim = string.IsNullOrEmpty(workItens.Fields.MicrosoftVstsCommonClosedDate) ? DateTime.Now : Convert.ToDateTime(workItens.Fields.MicrosoftVstsCommonClosedDate),
                Descricao = workItens.Fields.SystemTitle,
                Comentario = workItens.Fields.SystemHistory,
                DataModificacao = Convert.ToDateTime(workItens.Fields.SystemChangedDate),
                DataCadastro = Convert.ToDateTime(workItens.Fields.SystemCreatedDate),
                HorasEstimadas = string.IsNullOrEmpty(workItens.Fields.OriginalEstimate) ? 0 : Convert.ToInt32(workItens.Fields.OriginalEstimate.Split('.')[0]),
                HorasUtilizadas = string.IsNullOrEmpty(workItens.Fields.CompletedWork) ? 0 : Convert.ToInt32(workItens.Fields.CompletedWork.Split('.')[0]),
                Tipo = ObterTipoWorkItemDevops(workItens.Fields.SystemWorkItemType),
                HorasRestantes = string.IsNullOrEmpty(workItens.Fields.RemainingWork) ? 0 : Convert.ToInt32(workItens.Fields.RemainingWork.Split('.')[0]),
                Prioridade = workItens.Fields.MicrosoftVstsCommonPriority > 0 ? (int)workItens.Fields.MicrosoftVstsCommonPriority : 0,
                Responsavel = workItens.Fields?.SystemAssignedTo?.DisplayName,
                SquadId = squadId,
                SprintId = sprintId,
                Status = ObterStatusDemanda(workItens.Fields.SystemState)
            };
        }

        public static int? ObterStatusDemanda(string state)
            => state switch
            {
                "Em Backlog" => 1,
                "Priorizado" => 2,
                "Analise de Viabilidade" => 3,
                "Especificação" => 4,
                "Backlog Desenvolvimento" => 5,
                "Em Desenvolvimento" => 6,
                "Em GC" => 7,
                "Pacote Liberado" => 8,
                "Em Homologação" => 9,
                "Fila de Produção" => 10,
                "Concluído" => 11,
                "Closed" => 11,
                "PromoverMain" => 12,
                _ => 1
            };
        public static int ObterTipoWorkItemDevops(string tipo)
            => tipo switch
            {
                "Epic" => 1,
                "Feature" => 2,
                "User Story" => 3,
                "Task" => 4,
                "Bug" => 5,
                _ => 0,
            }; 

        public static List<Demandas> PreencherDemandasJira(IssuesPaginateQueryResult issue, List<Sprint> sprints, long projetoId, long squadId)

        {
            var demandas = new List<Demandas>();

            foreach (var item in issue.Issues)
            {
                var demanda = new Demandas()
                {
                    Id = Guid.NewGuid(),
                    ExternalId = item.Id,
                    Descricao = item.Fields.Summary,
                    SprintId = PreencherSprint(item, sprints),
                    ProjetoId = projetoId,
                    Tipo = PreencherTipo(Convert.ToInt64(item.Fields.Issuetype.Id)),
                    SquadId = squadId,
                    DemandaPaiId = null,
                    Responsavel = item?.Fields?.Assignee?.DisplayName,
                    Pontos = item?.Fields?.StoryPoints,
                    Prioridade = PreencherPrioridade(item?.Fields?.Priority.Name),
                    HorasEstimadas = null, //JIRA TRABALHA COM STRING QUE PODE SER CONVERTIDO EM MINUTOS
                    HorasUtilizadas = null, //JIRA TRABALHA COM STRING QUE PODE SER CONVERTIDO EM MINUTOS
                    Comentario = item?.Fields?.Description,
                    Status = PreencherStatus(Convert.ToInt64(item.Fields.Status.Id),1) // INSERIR STATUS CORRETO
                };

                PreencherDataJira(item, demanda);
                demanda.DemandaHistorico = PreencherDemandaHistoricoJira(demanda);
                if (demanda.Tipo == 4)
                   demanda.DemandaPaiIntegracaoId = PreencherPai(item);





                demandas.Add(demanda);
            }

            PreencherIdsPai(demandas);

            return demandas;

        }

        private static DemandaHistorico PreencherDemandaHistoricoJira(Demandas demanda)
        {
            return new DemandaHistorico()
            {
                Id = demanda.Id,
                ExternalId = demanda.ExternalId,
                SprintId = demanda.SprintId,
                ProjetoId = demanda.ProjetoId,
                SquadId = demanda.SquadId,
                Tipo = demanda.Tipo,
                DemandaPaiId = demanda.DemandaPaiId,
                Responsavel = demanda.Responsavel,
                DataInicio = demanda.DataInicio,
                DataModificacao = demanda.DataModificacao,
                DataFim = demanda.DataFim,
                Pontos = demanda.Pontos,
                Tags = demanda.Tags,
                Prioridade = demanda.Prioridade,
                HorasEstimadas = demanda.HorasEstimadas,
                HorasRestantes = demanda.HorasRestantes,
                HorasUtilizadas = demanda.HorasUtilizadas,
                Risco = demanda.Risco,
                Comentario = demanda.Comentario,
                Status = demanda.Status
            };

        }

        private static void PreencherDataJira(Issue issue, Demandas demanda)
        {
            demanda.DataInicio = Convert.ToDateTime(issue.Fields.Created);

            if (issue?.Fields?.Updated != null)
                demanda.DataModificacao = Convert.ToDateTime(issue.Fields.Updated);

            if (issue?.Fields?.Status?.Name != null && issue?.Fields?.Status?.Name == "Concluído")
                demanda.DataFim = Convert.ToDateTime(issue.Fields.Updated);
        }

        private static int? PreencherPrioridade(string prioridade)
        {
            if (prioridade == null)
                return null;

            switch (prioridade.ToLower())
            {
                case "lowest":
                    return 1;
                case "low":
                    return 2;
                case "medium":
                    return 3;
                case "high":
                    return 4;
                case "highest":
                    return 5;
                default:
                    return null;
            }
        }

        private static long? PreencherTipo(long tipo)
        {
            switch (tipo)
            {
                case 10009:
                    return 3;
                case 10015:
                    return 7;
                case 10000:
                    return 1;
                case 10013:
                    return 4;
                case 10014:
                    return 4;
                default:
                    return 0;
            }
        }

        private static int? PreencherStatus(long statusId, long sprintId)
        {
            switch (statusId)
            {
                case 3:
                    return 6;// "Em andamento"
                case 10006:
                    if(sprintId == 0) // Backlog Desenvolvimento
                        return 1; // Backlog 
                    return 5; // Backlog Desenvolvimento
                case 10007:
                    return 11; // Concluído
                default:
                    return 0;
            }
        }

        private static long? PreencherSprint(Issue issue, List<Sprint> sprints)
        {
            if(issue?.Fields?.ClosedSprints != null)
            {
               var sprint = issue.Fields.ClosedSprints.ToList().LastOrDefault();

                if(sprint != null)
                {
                    return sprints.FirstOrDefault(x => x.ExternalId == sprint.Id.ToString()).Id;
                }

            }
            else if (issue?.Fields?.Sprint != null)
            {
                    return sprints.FirstOrDefault(x => x.ExternalId == issue.Fields.Sprint.Id.ToString()).Id;
            }

            return null;
        }

        public static string PreencherPai(Issue issue)
        {
                return issue?.Fields?.Parent?.Id;
        }

        public static void PreencherIdsPai(List<Demandas> demandas)
        {

            foreach (var item in demandas.Where(x => x.DemandaPaiIntegracaoId != null))
            {
                item.DemandaPaiId = demandas.FirstOrDefault(y => y.ExternalId == item.DemandaPaiIntegracaoId).Id;
            }

        }

    }

}
