using System;

namespace DashAgil.Entidades.DTO
{
    public class FeatureDTO
    {
        public Guid FeatureId { get; set; }

        public string FeatureDescricao { get; set; }

        public double Remanescente { get; set; }

        public double EmAndamento { get; set; }

        public double DesenvolvimentoConcluido { get; set; }

        public double Homologacao { get; set; }

        public double Homologado { get; set; }

        public double Concluido { get; set; }
    }
}
