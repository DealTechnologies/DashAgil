using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Queries
{
    public class SprintBurndown
    {
        public SprintBurndown()
        {
            DemandasHistoricos = new List<DemandasHistoricos>();
        }
        public string Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Nome { get; set; }
        public List<DemandasHistoricos> DemandasHistoricos { get; set; }
    }
}
