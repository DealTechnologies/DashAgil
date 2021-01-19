using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Queries
{
    public class DemandasHistoricos
    {
        public DateTime Dia { get; set; }
        public int VelocidadeIdeal { get; set; }
        public int VelocidadeSprint { get; set; }
        public int PontosTotalDia { get; set; }
        public int PontosConcluidosDia { get; set; }
    }
}
