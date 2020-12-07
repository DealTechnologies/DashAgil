using DashAgil.Integrador.Enums;
using DashAgil.Integrador.Jira.Queries.Sprints;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades
{
    public class Sprint
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public long ProjetoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataConclusao { get; set; }

        public StatusSprint Status { get; set; }


        public static List<Sprint> PreencherSprints(SprintPaginateQueryResult sprintJira, long projetoId)
        {
            var sprints = new List<Sprint>();

            foreach (var item in sprintJira.Values)
            {
                var sprint = new Sprint()
                {
                    ExternalId = item.Id.ToString(),
                    ProjetoId = projetoId,
                    Nome = item.Name,
                    Descricao = item.Goal,
                    DataInicio = item.StartDate,
                    DataFim = item.EndDate,
                    DataConclusao = item.CompleteDate,
                    Status = ValidarStatus(item.State)
                };

                sprints.Add(sprint);
            }

            return sprints;
        }

        private static StatusSprint ValidarStatus(string status)
        {
            switch (status.ToLower())
            {
                case "new":
                    return StatusSprint.Futura;
                case "active":
                    return StatusSprint.Ativa;
                case "closed":
                    return StatusSprint.Concluida;
                case "cancel":
                    return StatusSprint.Cancelada;
                default:
                    return StatusSprint.Erro;
            }

        }




    }


}
