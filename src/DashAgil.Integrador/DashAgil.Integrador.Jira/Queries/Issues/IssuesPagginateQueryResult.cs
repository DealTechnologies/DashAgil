using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DashAgil.Integrador.Jira.Queries.Issues
{

    public partial class IssuesPaginateQueryResult
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("startAt")]
        public long? StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long? MaxResults { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("issues")]
        public List<Issue> Issues { get; set; }
    }

    public partial class Issue
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

    public partial class Parent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

    }

    public partial class IssueFields
    {
        [JsonProperty("statuscategorychangedate")]
        public string Statuscategorychangedate { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("timespent")]
        public object Timespent { get; set; }

        [JsonProperty("sprint")]
        public ClosedSprint Sprint { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("fixVersions")]
        public object[] FixVersions { get; set; }

        [JsonProperty("aggregatetimespent")]
        public long? Aggregatetimespent { get; set; }

        [JsonProperty("resolution")]
        public Priority Resolution { get; set; }

        [JsonProperty("customfield_10028")]
        public long? StoryPoints { get; set; }

        [JsonProperty("resolutiondate")]
        public string Resolutiondate { get; set; }

        [JsonProperty("workratio")]
        public long? Workratio { get; set; }

        [JsonProperty("lastViewed")]
        public object LastViewed { get; set; }

        [JsonProperty("issuerestriction")]
        public Issuerestriction Issuerestriction { get; set; }

        [JsonProperty("watches")]
        public Watches Watches { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("customfield_10020")]
        public ClosedSprint[] Customfield10020 { get; set; }

        [JsonProperty("customfield_10021")]
        public object Customfield10021 { get; set; }

        [JsonProperty("epic")]
        public Epic Epic { get; set; }

        [JsonProperty("customfield_10022")]
        public object Customfield10022 { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("customfield_10023")]
        public object Customfield10023 { get; set; }

        [JsonProperty("customfield_10024")]
        public object Customfield10024 { get; set; }

        [JsonProperty("customfield_10025")]
        public string Customfield10025 { get; set; }

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

        [JsonProperty("timeestimate")]
        public object Timeestimate { get; set; }

        [JsonProperty("aggregatetimeoriginalestimate")]
        public object Aggregatetimeoriginalestimate { get; set; }

        [JsonProperty("versions")]
        public object[] Versions { get; set; }

        [JsonProperty("issuelinks")]
        public object[] Issuelinks { get; set; }

        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("status")]
        public Issuetype Status { get; set; }

        [JsonProperty("components")]
        public object[] Components { get; set; }

        [JsonProperty("timeoriginalestimate")]
        public object Timeoriginalestimate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customfield_10010")]
        public object Customfield10010 { get; set; }

        [JsonProperty("customfield_10014")]
        public string Customfield10014 { get; set; }

        [JsonProperty("customfield_10015")]
        public object Customfield10015 { get; set; }

        [JsonProperty("timetracking")]
        public Timetracking Timetracking { get; set; }

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

        [JsonProperty("aggregatetimeestimate")]
        public long? Aggregatetimeestimate { get; set; }

        [JsonProperty("attachment")]
        public object[] Attachment { get; set; }

        [JsonProperty("customfield_10009")]
        public object Customfield10009 { get; set; }

        [JsonProperty("flagged")]
        public bool Flagged { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("creator")]
        public Assignee Creator { get; set; }

        [JsonProperty("subtasks")]
        public Subtask[] Subtasks { get; set; }

        [JsonProperty("reporter")]
        public Assignee Reporter { get; set; }

        [JsonProperty("customfield_10000")]
        public string Customfield10000 { get; set; }

        [JsonProperty("aggregateprogress")]
        public Aggregateprogress Aggregateprogress { get; set; }

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

        [JsonProperty("closedSprints")]
        public ClosedSprint[] ClosedSprints { get; set; }

        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("worklog")]
        public Comment Worklog { get; set; }
    }

    public partial class Aggregateprogress
    {
        [JsonProperty("progress")]
        public long? Progress { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("percent")]
        public long? Percent { get; set; }
    }

    public partial class Assignee
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("accountType")]
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

    public partial class ClosedSprint
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Self { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("completeDate")]
        public DateTimeOffset CompleteDate { get; set; }

        [JsonProperty("originBoardId", NullValueHandling = NullValueHandling.Ignore)]
        public long? OriginBoardId { get; set; }

        [JsonProperty("goal")]
        public string Goal { get; set; }

        [JsonProperty("boardId", NullValueHandling = NullValueHandling.Ignore)]
        public long? BoardId { get; set; }
    }

    public partial class Comment
    {
        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Comments { get; set; }

        [JsonProperty("maxResults")]
        public long? MaxResults { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("startAt")]
        public long? StartAt { get; set; }

        [JsonProperty("worklogs", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Worklogs { get; set; }
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

    public partial class Epic
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("done")]
        public bool Done { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("key")]
        public string Key { get; set; }
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
        [JsonProperty("remainingEstimate", NullValueHandling = NullValueHandling.Ignore)]
        public string RemainingEstimate { get; set; }

        [JsonProperty("timeSpent", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeSpent { get; set; }

        [JsonProperty("remainingEstimateSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public long? RemainingEstimateSeconds { get; set; }

        [JsonProperty("timeSpentSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeSpentSeconds { get; set; }

        [JsonProperty("originalEstimate", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalEstimate { get; set; }

        [JsonProperty("originalEstimateSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public long? OriginalEstimateSeconds { get; set; }
    }

    public partial class Issuetype
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subtask", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Subtask { get; set; }

        [JsonProperty("statusCategory", NullValueHandling = NullValueHandling.Ignore)]
        public StatusCategory StatusCategory { get; set; }

        [JsonProperty("avatarId", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvatarId { get; set; }
    }

    public partial class StatusCategory
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Priority
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("iconUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial class Progress
    {
        [JsonProperty("progress")]
        public long? ProgressProgress { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }
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

    public partial class Subtask
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("fields")]
        public SubtaskFields Fields { get; set; }
    }

    public partial class SubtaskFields
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("status")]
        public Issuetype Status { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }
    }

    public partial class Votes
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("votes")]
        public long? VotesVotes { get; set; }

        [JsonProperty("hasVoted")]
        public bool HasVoted { get; set; }
    }

    public partial class Watches
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("watchCount")]
        public long? WatchCount { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }
    }
}

