using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Queries
{
    public class ProjectQueryResult
    {
        [JsonProperty("projectId")]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string ProjectName { get; set; }

        [JsonProperty("projectKey")]
        public string Key { get; set; }

        [JsonProperty("projectTypeKey")]
        public string TypeKey { get; set; }

        [JsonProperty("avatarURI")]
        public string AvatarUrl { get; set; }
    }
}
