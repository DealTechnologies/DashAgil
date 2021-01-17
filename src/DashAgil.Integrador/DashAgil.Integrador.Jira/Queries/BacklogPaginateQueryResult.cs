using System;
using Newtonsoft.Json;


namespace DashAgil.Integrador.Jira.Queries
{
    public partial class BacklogPaginateQueryResult
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("issues")]
        public IssueQueryResult[] Issues { get; set; }
    }

    public partial class IssueQueryResult
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("fields")]
        public IssueFields Fields { get; set; }
    }

    public partial class IssueFields
    {
        [JsonProperty("statuscategorychangedate")]
        public string Statuscategorychangedate { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }

        [JsonProperty("timespent")]
        public object Timespent { get; set; }

        [JsonProperty("sprint")]
        public object Sprint { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("fixVersions")]
        public object[] FixVersions { get; set; }

        [JsonProperty("aggregatetimespent")]
        public object Aggregatetimespent { get; set; }

        [JsonProperty("resolution")]
        public object Resolution { get; set; }

        [JsonProperty("resolutiondate")]
        public object Resolutiondate { get; set; }

        [JsonProperty("workratio")]
        public long Workratio { get; set; }

        [JsonProperty("issuerestriction")]
        public Issuerestriction Issuerestriction { get; set; }

        [JsonProperty("watches")]
        public Watches Watches { get; set; }

        [JsonProperty("lastViewed")]
        public string LastViewed { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("customfield_10020")]
        public object Customfield10020 { get; set; }

        [JsonProperty("customfield_10021")]
        public object Customfield10021 { get; set; }

        [JsonProperty("epic")]
        public object Epic { get; set; }

        [JsonProperty("customfield_10022")]
        public object Customfield10022 { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("customfield_10023")]
        public object Customfield10023 { get; set; }

        [JsonProperty("customfield_10024")]
        public object Customfield10024 { get; set; }

        [JsonProperty("customfield_10025")]
        public object Customfield10025 { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }

        [JsonProperty("customfield_10016")]
        public object Customfield10016 { get; set; }

        [JsonProperty("customfield_10017")]
        public object Customfield10017 { get; set; }

        [JsonProperty("customfield_10018")]
        public Customfield10018 Customfield10018 { get; set; }

        [JsonProperty("customfield_10019")]
        public string Customfield10019 { get; set; }

        [JsonProperty("aggregatetimeoriginalestimate")]
        public object Aggregatetimeoriginalestimate { get; set; }

        [JsonProperty("timeestimate")]
        public object Timeestimate { get; set; }

        [JsonProperty("versions")]
        public object[] Versions { get; set; }

        [JsonProperty("issuelinks")]
        public object[] Issuelinks { get; set; }

        [JsonProperty("assignee")]
        public object Assignee { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("components")]
        public object[] Components { get; set; }

        [JsonProperty("timeoriginalestimate")]
        public object Timeoriginalestimate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customfield_10010")]
        public object Customfield10010 { get; set; }

        [JsonProperty("customfield_10014")]
        public object Customfield10014 { get; set; }

        [JsonProperty("timetracking")]
        public Timetracking Timetracking { get; set; }

        [JsonProperty("customfield_10015")]
        public object Customfield10015 { get; set; }

        [JsonProperty("customfield_10005")]
        public object Customfield10005 { get; set; }

        [JsonProperty("customfield_10006")]
        public object Customfield10006 { get; set; }

        [JsonProperty("security")]
        public object Security { get; set; }

        [JsonProperty("customfield_10007")]
        public object Customfield10007 { get; set; }

        [JsonProperty("customfield_10008")]
        public object Customfield10008 { get; set; }

        [JsonProperty("customfield_10009")]
        public object Customfield10009 { get; set; }

        [JsonProperty("attachment")]
        public object[] Attachment { get; set; }

        [JsonProperty("aggregatetimeestimate")]
        public object Aggregatetimeestimate { get; set; }

        [JsonProperty("flagged")]
        public bool Flagged { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("creator")]
        public Creator Creator { get; set; }

        [JsonProperty("subtasks")]
        public Parent[] Subtasks { get; set; }

        [JsonProperty("reporter")]
        public Creator Reporter { get; set; }

        [JsonProperty("customfield_10000")]
        public string Customfield10000 { get; set; }

        [JsonProperty("aggregateprogress")]
        public Progress Aggregateprogress { get; set; }

        [JsonProperty("customfield_10001")]
        public object Customfield10001 { get; set; }

        [JsonProperty("customfield_10002")]
        public object Customfield10002 { get; set; }

        [JsonProperty("customfield_10003")]
        public object Customfield10003 { get; set; }

        [JsonProperty("customfield_10004")]
        public object Customfield10004 { get; set; }

        [JsonProperty("environment")]
        public object Environment { get; set; }

        [JsonProperty("duedate")]
        public object Duedate { get; set; }

        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("comment")]
        public WorklogClass Comment { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("worklog")]
        public WorklogClass Worklog { get; set; }

        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public Parent Parent { get; set; }
    }

    public partial class Progress
    {
        [JsonProperty("progress")]
        public long ProgressProgress { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class WorklogClass
    {
        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public CommentElement[] Comments { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("worklogs", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Worklogs { get; set; }
    }

    public partial class CommentElement
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public Creator Author { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("updateAuthor")]
        public Creator UpdateAuthor { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("jsdPublic")]
        public bool JsdPublic { get; set; }
    }

    public partial class Creator
    {
        public string Self { get; set; }
        public string AccountId { get; set; }
        public string EmailAddress { get; set; }
        public AvatarUrls AvatarUrls { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
        public string AccountType { get; set; }
    }

    public partial class AvatarUrls
    {
        [JsonProperty("48x48")]
        public Uri The48X48 { get; set; }

        [JsonProperty("24x24")]
        public Uri The24X24 { get; set; }

        [JsonProperty("16x16")]
        public Uri The16X16 { get; set; }

        [JsonProperty("32x32")]
        public Uri The32X32 { get; set; }
    }

    public partial class Customfield10018
    {
        [JsonProperty("hasEpicLinkFieldDependency")]
        public bool HasEpicLinkFieldDependency { get; set; }

        [JsonProperty("showField")]
        public bool ShowField { get; set; }

        [JsonProperty("nonEditableReason")]
        public NonEditableReason NonEditableReason { get; set; }
    }

    public partial class NonEditableReason
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Issuerestriction
    {
        [JsonProperty("issuerestrictions")]
        public Timetracking Issuerestrictions { get; set; }

        [JsonProperty("shouldDisplay")]
        public bool ShouldDisplay { get; set; }
    }

    public partial class Timetracking
    {
    }

    public partial class Issuetype
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subtask")]
        public bool Subtask { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("entityId")]
        public Guid EntityId { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("fields")]
        public ParentFields Fields { get; set; }
    }

    public partial class ParentFields
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }
    }

    public partial class Priority
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("statusCategory")]
        public StatusCategory StatusCategory { get; set; }
    }

    public partial class StatusCategory
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("projectTypeKey")]
        public string ProjectTypeKey { get; set; }

        [JsonProperty("simplified")]
        public bool Simplified { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }
    }

    public partial class Votes
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("votes")]
        public long VotesVotes { get; set; }

        [JsonProperty("hasVoted")]
        public bool HasVoted { get; set; }
    }

    public partial class Watches
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("watchCount")]
        public long WatchCount { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }
    }
}
