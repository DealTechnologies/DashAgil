using System;
using System.Collections.Generic;

namespace DashAgil.Entidades.DashAgil
{
    public class SprintBurndownResult
    {
        public SprintBurndownResult()
        {
            _demandasHistoricos = new List<DemandaHistoricoResult>();
        }

        private readonly IList<DemandaHistoricoResult> _demandasHistoricos;
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<DemandaHistoricoResult> DemandasHistoricos { get; set; }

        public void AdicionarDemandasHistoricos(DemandaHistoricoResult demandaHistorico)
        {
            _demandasHistoricos.Add(demandaHistorico);
            DemandasHistoricos = (List<DemandaHistoricoResult>)_demandasHistoricos;
        }

    }
}
