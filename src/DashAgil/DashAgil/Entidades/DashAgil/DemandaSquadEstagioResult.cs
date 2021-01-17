using Newtonsoft.Json;

namespace DashAgil.Entidades.DashAgil
{
    public class DemandaSquadEstagioResult
    {
        public int Quantidade { get; set; }

        public string SquadNome { get; set; }
        [JsonProperty("statusDescricao")]
        public string StatusDeXPara { get; set; }        
    }
}
