using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Queries
{
    public class BoardQueryResult
    {
        public int Id { get; set; }

        [JsonProperty("self")]
        public string Url { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        [JsonProperty("location")]
        public ProjectQueryResult Project { get; set; }
    }
}
