using DashAgil.Entidades.DashAgil;
using DashAgil.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashAgil.Entidades
{
    public class Sprints
    {
        public Sprints() { }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        
        public SprintBurndownResult Burndown(IEnumerable<dynamic> demandas, string sprintId)
        {
            var dadosSprint = demandas.FirstOrDefault();

            if (dadosSprint == null)
                return null;

            DateTime dataInicioSprint = dadosSprint.SprintDataInicio.Date;
            DateTime dataFimSprint = dadosSprint.SprintDataFim.Date;

            var sprint = new SprintBurndownResult
            {
                Id = int.Parse(sprintId),
                Nome = dadosSprint.SprintNome,
                DataInicio = dataInicioSprint,
                DataFim = dataFimSprint
            };

            while (dataInicioSprint <= dataFimSprint)
            {
                if (dataInicioSprint.DayOfWeek != DayOfWeek.Saturday &&
                    dataInicioSprint.DayOfWeek != DayOfWeek.Sunday)
                {
                    var estoriasSprint = demandas
                    .GroupBy(x => new { x.SprintNome, x.SprintDataInicio, x.SprintDataFim })
                    .Select(group => new DemandaHistoricoResult
                    {
                        Dia = dataInicioSprint,
                        PontosTotalDia = group.Select(x => new { x.Id, x.Pontos }).Distinct().Sum(x => x.Pontos),//total pontos sprint
                        PontosConcluidosDia = group.Where(x =>
                            int.Parse(x.StatusDeXPara) >= (int)EDemandaStatusDexPara.DesenvolvimentoConcluido &&
                            x.DataModificacao <= dataInicioSprint.Date.AddHours(23.9999))
                            .Select(x => new { x.Id, x.Pontos }).Distinct().Sum(x => x.Pontos) //pontos baixados de hoje ate o inicio do sprint
                    });

                    sprint.AdicionarDemandasHistoricos(estoriasSprint.FirstOrDefault());
                }
                dataInicioSprint = dataInicioSprint.AddDays(1);
            }

            return sprint;
        }
    }
}
