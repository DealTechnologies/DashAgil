using Newtonsoft.Json;
using System;

namespace DashAgil.Entidades.DashAgil
{
    public class FeaturesEstagioResult
    {
        public Guid FeatureId { get; set; }
        public string FeatureDescricao { get; set; }
        [JsonProperty("statusDescricao")]
        public string StatusDeXPara { get; set; }
        public long Quantidade { get; set; }
        public double Percentual { get; set; }
    }
}
