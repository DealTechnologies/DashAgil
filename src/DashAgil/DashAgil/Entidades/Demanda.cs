using DashAgil.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DashAgil.Entidades
{
    public class Demanda
    {
        public Demanda() { }
        public Demanda(string id, string externalId, int clienteId, Squad squad, int tipo, string demandaPaiId, string responsavel, DateTime dataInicio, DateTime dataModificacao, 
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

        public dynamic TotalEstoriasPorEstagio(IEnumerable<Demanda> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => x.Status)
                .Select(group => new
                {
                    Status = group.Key,
                    Quantidade = group.Count()
                });

            return estoriasGroup;
        }

        public dynamic TotalEstoriasPorSquad(IEnumerable<Demanda> demandas)
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

        public long TotalGeralEstorias(IEnumerable<Demanda> demandas) => demandas.Count();

        public string Id { get; set; }
        public string ExternalId { get; set; }
        public int ClienteId { get; set; }
        public Squad Squad { get; set; }
        public EDemandaTipo Tipo { get; set; }
        public string DemandaPaiId { get; set; }
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
    }
}
