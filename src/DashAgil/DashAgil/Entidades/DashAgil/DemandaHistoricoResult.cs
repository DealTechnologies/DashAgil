using System;

namespace DashAgil.Entidades
{
    public class DemandaHistoricoResult
    {
        public DateTime Dia { get; set; }
        public int PontosTotalDia { get; set; }
        public int PontosConcluidosDia { get; set; }
        public double VelocidadeIdeal { get; set; }
        public double VelocidadeSprint { get; set; }
    }
}
