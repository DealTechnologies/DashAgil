﻿using Newtonsoft.Json;

namespace DashAgil.Integrador.Entidades.Devops
{
    public class WorkItensTypeResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
