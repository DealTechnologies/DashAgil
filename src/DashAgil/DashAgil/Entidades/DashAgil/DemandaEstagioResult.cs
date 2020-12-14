using Newtonsoft.Json;

namespace DashAgil.Entidades.DashAgil
{
    public class DemandaEstagioResult
    {
        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("statusDescricao")]
        public string StatusDeXPara { get; set; }
    }
}
