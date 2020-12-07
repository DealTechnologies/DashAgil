using DashAgil.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace DashAgil.Entidades
{
    public class Demanda
    {
        public Demanda() { }
        public Demanda(Guid id, string externalId, int clienteId, Squad squad, int tipo, Guid demandaPaiId, string responsavel, DateTime dataInicio, DateTime dataModificacao, 
            DateTime dataFim, int pontos, string tags, int prioridade, int horasEstimadas, int horasRestantes, int horasUtilizadas, int risco, string comentario, int status)
        {
            Id = id;
            ExternalId = externalId;
            ClienteId = clienteId;
            Squad = squad;
            Tipo = (EDemandaTipo)tipo;
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
            Status = (EDemandaStatus)status;
        }

        public dynamic TotalEstoriasPorEstagio(IEnumerable<dynamic> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => new { x.StatusDeXPara })
                .Select(group => new
                {
                    StatusDeXPara = group.Key.StatusDeXPara,
                    Quantidade = group.Count()
                });

            return estoriasGroup;
        }

        public dynamic TotalEstoriasPorSquad(IEnumerable<dynamic> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => x.Squad.Nome)
                .Select(group => new
                {
                    NomeSquad = group.Key,
                    Quantidade = group.Count()
                });

            return estoriasGroup;
        }

        public long TotalGeralEstorias(IEnumerable<dynamic> demandas) => demandas.Count();

        public dynamic TotalEstoriasPorFeature(IEnumerable<dynamic> demandasFeatues)
        {
            var totalPorFeature = demandasFeatues
                .GroupBy(x => x.FeatureId)
                .Select(group => new
                {
                    FeatureId = group.Key,
                    Quantidade = group.Count()
                });

            var featuresGroup = demandasFeatues
                .GroupBy(x => new { x.FeatureId, x.FeatureDescricao, x.StatusDeXPara })
                .Select(group => new
                {
                    FeatureId = group.Key.FeatureId,
                    FeatureDescricao = group.Key.FeatureDescricao,
                    StatusDeXPara = group.Key.StatusDeXPara,
                    Quantidade = group.Count(),
                    Percentual = Math.Round(Convert.ToDouble(group.Count()) / Convert.ToDouble(totalPorFeature.Where(x => x.FeatureId == group.Key.FeatureId).Select(x => x.Quantidade).FirstOrDefault()) * 100.0, 2)
                });

            return featuresGroup;
        }

        public double PercentualFeaturesHomologacao(IEnumerable<dynamic> demandasFeatues)
        {
            var totalEstorias = demandasFeatues.Count();

            var totalEstoriasHomologacao = demandasFeatues
                .GroupBy(x => new { x.StatusDeXPara })
                .Select(group => new
                {
                    StatusDeXPara = group.Key.StatusDeXPara,
                    Quantidade = group.Count()
                })
                .Where(c => c.StatusDeXPara == ((int)EDemandaStatusDexPara.Homologacao).ToString())
                .Count();

            var totalEstoriasAux = Convert.ToDouble(totalEstorias);
            var totalEstoriasHomologacaoAux = Convert.ToDouble(totalEstoriasHomologacao);
            return Math.Round((totalEstoriasHomologacaoAux / totalEstoriasAux * 100.0), 2);
        }

        public dynamic EvolucaoSquad(IEnumerable<dynamic> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => x.Squad.Nome)
                .Select(group => new
                {
                    NomeSquad = group.Key,
                    EvolucaoAnterior = group.Where(x => x.DataInicio <= DateTime.Today.AddDays(-7)).Count(),
                    EvolucaoAtual = group.Count()
                });

            return estoriasGroup;
        }

        //public dynamic Burndown(IEnumerable<dynamic> demandas, string sprintId)
        //{
        //    var sprint = demandas
        //        .Where(x => x.SprintId == sprintId)
        //        .Select(group => new
        //        {
        //            SprintNome = group.SprintNome,
        //            SprintDataInicio = group.SprintDataInicio,
        //            SprintDataFim = group.SprintDataFim
        //        }).FirstOrDefault();

        //    DateTime dataInicioSprint = sprint.SprintDataInicio.Date();
        //    DateTime dataFimSprint = sprint.SprintDataFim.Date();
        //    dynamic retorno = new ExpandoObject();
        //    retorno.SprintNome = sprint.SprintNome;
        //    retorno.SprintDataInicio = dataInicioSprint;
        //    retorno.SprintDataFim = dataFimSprint;
                        
        //    while (dataInicioSprint <= dataFimSprint)
        //    {
        //        var estoriasSprint = demandas
        //        .Where(x => x.SprintId == sprintId)
        //        .GroupBy(x => new { x.SprintNome, x.SprintDataInicio, x.SprintDataFim })
        //        .Select(group => new
        //        {
        //            Data = dataInicioSprint,
        //            PontosTotalDia = group.Count(),//total pontos sprint
        //            PontosConcluidosDia = group.Where(x => x.StatusDeXPara == (int)EDemandaStatusDexPara.DesenvolvimentoConcluido).Sum(x => x.Pontos) //pontos baixados nesse dia
        //        });
                
        //        dataInicioSprint.AddDays(1);
        //    }
            
        //    return estoriasSprint;
        //}

        public EDemandaStatusDexPara ConverterEstoriasStatus(EDemandaStatus status)
        {
            EDemandaStatusDexPara statusDeXPara = EDemandaStatusDexPara.Remanescente;    
            switch (status)
            {
                case EDemandaStatus.Backlog:
                case EDemandaStatus.Priorizado:
                case EDemandaStatus.AnaliseViabilidade:
                case EDemandaStatus.Especificacao:
                case EDemandaStatus.BacklogDesenvolvimento:
                    statusDeXPara = EDemandaStatusDexPara.Remanescente;
                    break;

                case EDemandaStatus.Desenvolvimento:
                    statusDeXPara = EDemandaStatusDexPara.EmAndamento;
                    break;

                case EDemandaStatus.GC:
                case EDemandaStatus.PacoteLiberado:
                    statusDeXPara = EDemandaStatusDexPara.DesenvolvimentoConcluido;
                    break;

                case EDemandaStatus.Homologacao:
                    statusDeXPara = EDemandaStatusDexPara.Homologacao;
                    break;

                case EDemandaStatus.FilaProducao:
                    statusDeXPara = EDemandaStatusDexPara.Homologado;
                    break;

                case EDemandaStatus.Concluido:
                case EDemandaStatus.PromoverMain:
                    statusDeXPara = EDemandaStatusDexPara.Concluido;
                    break;
            }

            return statusDeXPara;
        }

        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public int ClienteId { get; set; }
        public Squad Squad { get; set; }
        public EDemandaTipo Tipo { get; set; }
        public Guid DemandaPaiId { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataModificacao { get; set; }
        public DateTime DataFim { get; set; }
        public int Pontos { get; set; }
        public string Tags { get; set; }
        public int Prioridade { get; set; }
        public int HorasEstimadas { get; set; }
        public int HorasRestantes { get; set; }
        public int HorasUtilizadas { get; set; }
        public int Risco { get; set; }
        public string Comentario { get; set; }
        public EDemandaStatus Status { get; set; }
        public EDemandaStatusDexPara StatusDeXPara { get; set; }
    }
}
