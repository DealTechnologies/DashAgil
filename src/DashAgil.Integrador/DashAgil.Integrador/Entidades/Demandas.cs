
using DashAgil.Integrador.Jira.Queries.Issues;
using System;
using System.Collections.Generic;

namespace DashAgil.Integrador.Entidades
{
    public class Demandas : EntidadeDashAgil
    {
        public string ExternalId { get; set; }
        public long SprintId { get; set; }
        public long ProjetoId { get; set; }
        public long SquadId { get; set; }
        public int Tipo { get; set; }
        public string DemandaPaiId { get; set; }
        public string Responsavel { get; set; }
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
        public string Descricao { get; set; }


        public static List<Demandas> PreencherDemandasJira(IssuesPaginateQueryResult issue)
        {
            var demandas = new List<Demandas>();

            foreach (var item in issue.Issues)
            {
                var demanda = new Demandas()
                {
                    ExternalId = item.Id
                };


            }


            return demandas;

        }

    }

}
