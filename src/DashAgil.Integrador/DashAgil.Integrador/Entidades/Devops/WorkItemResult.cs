using Newtonsoft.Json;
using System;

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
        [JsonProperty("AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("State")]
        public string SystemState { get; set; }

        [JsonProperty("Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("AssignedTo")]
        public MicrosoftVstsCommonClosedBy SystemAssignedTo { get; set; }

        [JsonProperty("CreatedDate")]
        public string SystemCreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        public MicrosoftVstsCommonClosedBy SystemCreatedBy { get; set; }

        [JsonProperty("ChangedDate")]
        public string SystemChangedDate { get; set; }
        [JsonProperty("History")]
        public string SystemHistory { get; set; }

        [JsonProperty("ChangedBy")]
        public MicrosoftVstsCommonClosedBy SystemChangedBy { get; set; }

        [JsonProperty("CommentCount")]
        public long SystemCommentCount { get; set; }

        [JsonProperty("Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("StateChangeDate")]
        public string MicrosoftVstsCommonStateChangeDate { get; set; }

        [JsonProperty("ClosedDate")]
        public string MicrosoftVstsCommonClosedDate { get; set; }

        [JsonProperty("ClosedBy")]
        public MicrosoftVstsCommonClosedBy MicrosoftVstsCommonClosedBy { get; set; }

        [JsonProperty("ActivatedDate")]
        public string ActivatedDate { get; set; }

        [JsonProperty("OriginalEstimate")]
        public int OriginalEstimate { get; set; }

        [JsonProperty("RemainingWork")]
        public int RemainingWork { get; set; }

        [JsonProperty("Priority")]
        public long MicrosoftVstsCommonPriority { get; set; }
    }

    public partial class MicrosoftVstsCommonClosedBy
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("_links")]
        public MicrosoftVstsCommonClosedByLinks Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }

    public partial class MicrosoftVstsCommonClosedByLinks
    {
        [JsonProperty("avatar")]
        public HtmlClass Avatar { get; set; }
    }

    public partial class HtmlClass
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class WorkItemResultLinks
    {
        [JsonProperty("self")]
        public HtmlClass Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public HtmlClass WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions")]
        public HtmlClass WorkItemRevisions { get; set; }

        [JsonProperty("workItemComments")]
        public HtmlClass WorkItemComments { get; set; }

        [JsonProperty("html")]
        public HtmlClass Html { get; set; }

        [JsonProperty("workItemType")]
        public HtmlClass WorkItemType { get; set; }

        [JsonProperty("fields")]
        public HtmlClass Fields { get; set; }
    }
}
