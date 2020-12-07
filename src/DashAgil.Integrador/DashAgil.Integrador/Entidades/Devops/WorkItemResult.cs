using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades.Devops
{
    public partial class WorkItemResult
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("fields")]
        public WorkItemResultFields Fields { get; set; }

        [JsonProperty("_links")]
        public WorkItemResultLinks Links { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class WorkItemResultFields
    {
        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public SystemAssignedToClass SystemAssignedTo { get; set; }

        [JsonProperty("System.CreatedDate")]
        public string SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public SystemAssignedToClass SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public string SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public SystemAssignedToClass SystemChangedBy { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public string MicrosoftVstsCommonStateChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.ActivatedDate")]
        public string MicrosoftVstsCommonActivatedDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.ActivatedBy")]
        public string MicrosoftVstsCommonActivatedBy { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public long MicrosoftVstsCommonPriority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.ValueArea")]
        public string MicrosoftVstsCommonValueArea { get; set; }

        [JsonProperty("System.Tags")]
        public string SystemTags { get; set; }
    }

    public partial class SystemAssignedToClass
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("_links")]
        public SystemAssignedToLinks Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }

    public partial class SystemAssignedToLinks
    {
        [JsonProperty("avatar")]
        public HtmlClass Avatar { get; set; }
    }

    public partial class HtmlClass
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class WorkItemResultLinks
    {
        [JsonProperty("self")]
        public HtmlClass Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public HtmlClass WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions")]
        public HtmlClass WorkItemRevisions { get; set; }

        [JsonProperty("workItemHistory")]
        public HtmlClass WorkItemHistory { get; set; }

        [JsonProperty("html")]
        public HtmlClass Html { get; set; }

        [JsonProperty("workItemType")]
        public HtmlClass WorkItemType { get; set; }

        [JsonProperty("fields")]
        public HtmlClass Fields { get; set; }
    }
}
