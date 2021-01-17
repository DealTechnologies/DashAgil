using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Queries
{
    public class BoardPaginateQueryResult
    {
        public int MaxResults { get; set; }

        [JsonProperty("startAt")]
        public int Page { get; set; }

        public int Total { get; set; }

        public bool IsLast { get; set; }

        [JsonProperty("values")]
        public List<BoardQueryResult> Boards { get; set; }
    }
}
