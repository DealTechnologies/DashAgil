using Newtonsoft.Json;

namespace DashAgil.Integrador.Entidades.Devops
{
    public class SprintResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("finishDate")]
        public string FinishDate { get; set; }

        [JsonProperty("timeFrame")]
        public string TimeFrame { get; set; }
    }
}
