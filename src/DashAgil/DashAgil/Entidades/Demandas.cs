using DashAgil.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;
using DashAgil.Entidades.DashAgil;
using System.Collections.Specialized;
using DashAgil.Entidades.DTO;

namespace DashAgil.Entidades
{
    public class Demandas
    {
        public Demandas() { }
        public Demandas(Guid id, string externalId, int clienteId, Squads squad, int tipo, Guid demandaPaiId, string responsavel, DateTime dataInicio, DateTime dataModificacao,
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
                .Select(group => new DemandaEstagioResult
                {
                    StatusDeXPara = ((EDemandaStatusDexPara)group.Key.StatusDeXPara).ToString(),
                    Quantidade = group.Count(x => x.Status > 0)
                });

            var retorno = new ListDictionary();
            foreach (var estoria in estoriasGroup)
            {
                retorno.Add(estoria.StatusDeXPara, estoria.Quantidade);
            }

            return retorno;
        }

        public List<DemandaSquadResult> TotalEstoriasPorSquad(IEnumerable<Demandas> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => x.Squad.Nome)
                .Select(group => new DemandaSquadResult
                {
                    SquadNome = group.Key,
                    Quantidade = group.Count()
                }).ToList();

            estoriasGroup.ForEach(x => x.SquadId = demandas.FirstOrDefault(y => y.Squad.Nome.Equals(x.SquadNome)).SquadId);

            return estoriasGroup.ToList();
        }

        public long TotalGeralEstorias(IEnumerable<dynamic> demandas) => demandas.Count();

        public List<FeatureDTO> TotalEstoriasPorFeature(IEnumerable<dynamic> demandasFeatues)
        {
            var totalPorFeature = demandasFeatues
                .GroupBy(x => x.FeatureId)
                .Select(group => new
                {
                    FeatureId = group.Key,
                    Quantidade = group.Count()
                });

            //var featuresGroup = demandasFeatues
            //    .GroupBy(x => new { x.FeatureId, x.FeatureDescricao, x.StatusDeXPara })
            //    .Select(group => new FeaturesEstagioResult
            //    {
            //        FeatureId = group.Key.FeatureId,
            //        FeatureDescricao = group.Key.FeatureDescricao,
            //        StatusDeXPara = ((EDemandaStatusDexPara)group.Key.StatusDeXPara).ToString(),
            //        Quantidade = group.Count(),
            //        Percentual = Math.Round(Convert.ToDouble(group.Count()) / Convert.ToDouble(totalPorFeature.Where(x => x.FeatureId == group.Key.FeatureId).Select(x => x.Quantidade).FirstOrDefault()) * 100.0, 2)
            //    });

            var resultCollection = new List<FeatureDTO>();
            var features = demandasFeatues.GroupBy(o => new { o.FeatureId, o.FeatureDescricao, o.StatusDeXPara }).Select(o => o).ToList();

            foreach (var stories in features)
            {
                var result = new FeatureDTO
                {
                    FeatureId = stories.Key.FeatureId,
                    FeatureDescricao = stories.Key.FeatureDescricao
                };

                foreach (var story in stories)
                {
                    var valueFeature = totalPorFeature.FirstOrDefault(x => x.FeatureId == story.FeatureId);
                    var quantidade = valueFeature?.Quantidade ?? 0;
                    var value = Math.Round(Convert.ToDouble(stories.Count()) / Convert.ToDouble(quantidade) * 100.0, 2);

                    switch (story.StatusDeXPara)
                    {
                        case (int)EDemandaStatusDexPara.Remanescente:
                            result.Remanescente = value;
                            break;
                        case (int)EDemandaStatusDexPara.EmAndamento:
                            result.EmAndamento = value;
                            break;
                        case (int)EDemandaStatusDexPara.DesenvolvimentoConcluido:
                            result.DesenvolvimentoConcluido = value;
                            break;
                        case (int)EDemandaStatusDexPara.Homologacao:
                            result.Homologacao = value;
                            break;
                        case (int)EDemandaStatusDexPara.Homologado:
                            result.Homologado = value;
                            break;
                        case (int)EDemandaStatusDexPara.Concluido:
                            result.Concluido = value;
                            break;
                    }
                }

                resultCollection.Add(result);
            }

            return resultCollection?.GroupBy(o => new { o.FeatureId, o.FeatureDescricao }).Select(o => new FeatureDTO
            {
                FeatureId = o.Key.FeatureId,
                FeatureDescricao = o.Key.FeatureDescricao,
                Remanescente = o.Sum(x => x.Remanescente),
                EmAndamento = o.Sum(x => x.EmAndamento),
                DesenvolvimentoConcluido = o.Sum(x => x.DesenvolvimentoConcluido),
                Homologacao = o.Sum(x => x.Homologacao),
                Homologado = o.Sum(x => x.Homologado),
                Concluido = o.Sum(x => x.Concluido)
            })?.ToList();
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
                .Where(c => c.StatusDeXPara == (int)EDemandaStatusDexPara.Homologacao)
                .Count();

            var totalEstoriasAux = Convert.ToDouble(totalEstorias);
            var totalEstoriasHomologacaoAux = Convert.ToDouble(totalEstoriasHomologacao);
            if (totalEstoriasAux > 0)
            {
                return Math.Round((totalEstoriasHomologacaoAux / totalEstoriasAux * 100.0), 2);
            }
            else
            {
                return 0;
            }
        }

        public double PercentualFeaturesConcluisao(IEnumerable<dynamic> demandasFeatues)
        {
            var totalEstorias = demandasFeatues.Count();

            var totalEstoriasConclusao = demandasFeatues
                .GroupBy(x => new { x.StatusDeXPara })
                .Select(group => new
                {
                    StatusDeXPara = group.Key.StatusDeXPara,
                    Quantidade = group.Count()
                })
                .Where(c => c.StatusDeXPara == (int)EDemandaStatusDexPara.Concluido)
                .Count();

            var totalEstoriasAux = Convert.ToDouble(totalEstorias);
            var totalEstoriasConclusaoAux = Convert.ToDouble(totalEstoriasConclusao);
            if (totalEstoriasAux > 0)
            {
                return Math.Round((totalEstoriasConclusaoAux / totalEstoriasAux * 100.0), 2);
            }
            else
            {
                return 0;
            }
        }

        public List<DemandasResult> TratamentoListaEstorias(IEnumerable<dynamic> estorias)
        {
            var listaEstorias = estorias
                .Select(x => new DemandasResult
                {
                    Id = x.ExternalId,
                    Tipo = ((EDemandaTipo)x.Tipo).GetDisplayName(),
                    Descricao = x.Descricao,
                    Status = ((EDemandaStatusDexPara)x.StatusDeXPara).GetDisplayName()
                });

            return listaEstorias.ToList();
        }

        public List<DemandaSquadEstagioResult> TotalEstoriasPorEstagioSquad(IEnumerable<dynamic> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => new { x.Squad.Nome, x.StatusDeXPara })
                .Select(group => new DemandaSquadEstagioResult
                {
                    SquadNome = group.Key.Nome,
                    StatusDeXPara = ((EDemandaStatusDexPara)group.Key.StatusDeXPara).GetDisplayName(),
                    Quantidade = group.Count()
                });

            return estoriasGroup.ToList();
        }

        public dynamic VelocidadePorSquad(IEnumerable<dynamic> demandas)
        {
            var estoriasSprint = demandas
                .GroupBy(x => new { x.Sprint.Nome })
                .Select(group => new
                {
                    Sprint = group.Key.Nome,
                    TotalPontos = group.Where(x => (int)x.StatusDeXPara >= (int)EDemandaStatusDexPara.DesenvolvimentoConcluido)
                    .Select(x => new { x.Id, x.Pontos }).Distinct().Sum(x => x.Pontos)
                });

            var retorno = new ListDictionary();
            foreach (var estoria in estoriasSprint)
            {
                retorno.Add(estoria.Sprint, estoria.TotalPontos);
            }

            return retorno;
        }

        //public List<dynamic> GerarCFD(IEnumerable<Demanda> demandas)
        //{
        //    var estoriasGroup = demandas
        //        .GroupBy(x => new { x.DataModificacao.Month, x.DataModificacao.Year })
        //        .Select(group => new 
        //        {
        //            Data = Convert.ToDateTime("01/" + group.Key.Month + 1 + "/" + group.Key.Year).AddDays(-1),
        //            Quantidade = group.Count()
        //        });

        //    return estoriasGroup.ToList();
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
        public string Descricao { get; set; }
        public string ExternalId { get; set; }
        public long? SquadId { get; set; }
        public int ClienteId { get; set; }
        public Squads Squad { get; set; }
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
        public Sprints Sprint { get; set; }
    }
}
