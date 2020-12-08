using DashAgil.Entidades.DashAgil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashAgil.Entidades
{
    public class Squad
    {
        public Squad() { }
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public long SubSquadId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Status { get; set; }
        
        public List<SquadEvolucaoResult> EvolucaoSquad(IEnumerable<dynamic> demandas)
        {
            var estoriasGroup = demandas
                .GroupBy(x => x.Squad.Nome)
                .Select(group => new SquadEvolucaoResult
                {
                    SquadNome = group.Key,
                    EvolucaoAnterior = group.Where(x => x.DataInicio <= DateTime.Today.AddDays(-7)).Count(),
                    EvolucaoAtual = group.Count()
                });

            return estoriasGroup.ToList();
        }
    }    
}
