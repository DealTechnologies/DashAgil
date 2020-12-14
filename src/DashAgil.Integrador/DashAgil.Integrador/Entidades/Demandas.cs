
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
        public long SprintId { get; set; }
        public long ProjetoId { get; set; }
        public long? SquadId { get; set; }
        public long? Tipo { get; set; }
        public string DemandaPaiId { get; set; }
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

        public static Demandas PreencherDemandaDevops(WorkItemResult workItens, long projetoId, long squadId, long sprintId)
        {
            return   new Demandas
            {
                ProjetoId = projetoId,
                ExternalId = workItens.Id.ToString(),
                DataInicio = Convert.ToDateTime(workItens.Fields.ActivatedDate),
                Descricao = workItens.Fields.SystemTitle,
                Comentario = workItens.Fields.SystemHistory,
                DataModificacao = Convert.ToDateTime(workItens.Fields.SystemChangedDate),
                DataCadastro = Convert.ToDateTime(workItens.Fields.SystemCreatedDate), 
                HorasEstimadas = workItens.Fields.OriginalEstimate,
                HorasUtilizadas = workItens.Fields.RemainingWork,
                Tipo = ObterTipoWorkItemDevops(workItens.Fields.SystemWorkItemType),
                HorasRestantes = workItens.Fields.RemainingWork,
                Prioridade = (int)workItens.Fields.MicrosoftVstsCommonPriority,
                Status = ObterStatusDemanda(workItens.Fields.SystemState),
                Responsavel = workItens.Fields.SystemAssignedTo.DisplayName,
                SquadId = squadId,
                SprintId = sprintId
            }; 
        }

        public static int? ObterStatusDemanda(string state)
            => state switch
            {
                "Backlog" => 1,
                "Priorizado" => 2,
                "AnaliseViabilidade" => 3,
                "Especificacao" => 4,
                "BacklogDesenvolvimento" => 5,
                "Desenvolvimento" => 6,
                "GC" => 7,
                "PacoteLiberado" => 8,
                "Homologacao" => 9,
                "FilaProducao" => 10,
                "Concluido" => 11,
                "PromoverMain" => 12,
                _ => null
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
        public static List<Demandas> PreencherDemandasJira(IssuesPaginateQueryResult issue, List<Sprint> sprints, long projetoId)
        {
            var demandas = new List<Demandas>();

            foreach (var item in issue.Issues)
            {
                var demanda = new Demandas()
                {
                    Id = Guid.NewGuid(),
                    ExternalId = item.Id,
                    SprintId = 1,
                    ProjetoId = projetoId,
                    Tipo = 1,
                    SquadId = 1, //JIRA NÃO TRAZ
                    DemandaPaiId = "",
                    Responsavel = item?.Fields?.Assignee?.DisplayName,
                    Pontos = item?.Fields?.StoryPoints,
                    Prioridade = PreencherPrioridade(item?.Fields?.Priority.Name),
                    HorasEstimadas = null, //JIRA TRABALHA COM STRING QUE PODE SER CONVERTIDO EM MINUTOS
                    HorasUtilizadas = null, //JIRA TRABALHA COM STRING QUE PODE SER CONVERTIDO EM MINUTOS
                    Comentario = item?.Fields?.Description,
                    Status = 1 // INSERIR STATUS CORRETO
                };

                PreencherDataJira(item, demanda);

                demandas.Add(demanda);
            }

            return demandas;

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

    }

}
