using Newtonsoft.Json;
using System.Collections.Generic;

namespace DashAgil.Integrador.Entidades.Devops
{
    public class DevopsResult<T> where T: class
    {
        [JsonProperty("count")] 
        public long Count { get; set; }
        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}
