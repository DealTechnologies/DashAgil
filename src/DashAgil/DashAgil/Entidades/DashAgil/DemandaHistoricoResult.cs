using System;

namespace DashAgil.Entidades
{
    public class DemandaHistoricoResult
    {
        public DateTime Dia { get; set; }
        public double PontosTotalDia { get; set; }
        public double PontosConcluidosDia { get; set; }
        public double VelocidadeIdeal { get; set; }
        public double VelocidadeSprint { get; set; }
    }
}
