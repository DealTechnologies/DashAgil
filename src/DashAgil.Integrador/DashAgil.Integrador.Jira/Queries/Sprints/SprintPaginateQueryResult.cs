using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DashAgil.Integrador.Jira.Queries.Sprints
{

    public partial class SprintPaginateQueryResult
    {
        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("isLast")]
        public bool IsLast { get; set; }

        [JsonProperty("values")]
        public Value[] Values { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("completeDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CompleteDate { get; set; }

        [JsonProperty("originBoardId")]
        public long OriginBoardId { get; set; }

        [JsonProperty("goal")]
        public string Goal { get; set; }
    }
}
