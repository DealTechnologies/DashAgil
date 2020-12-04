using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DashAgil.Integrador.Entidades.Devops
{
    public class QueryResult
    {
        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        [JsonProperty("queryResultType")]
        public string QueryResultType { get; set; }

        [JsonProperty("asOf")]
        public string AsOf { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("sortColumns")]
        public List<SortColumn> SortColumns { get; set; }

        [JsonProperty("workItems")]
        public List<WorkItem> WorkItems { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class SortColumn
    {
        [JsonProperty("field")]
        public Column Field { get; set; }

        [JsonProperty("descending")]
        public bool Descending { get; set; }
    }

    public partial class WorkItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
