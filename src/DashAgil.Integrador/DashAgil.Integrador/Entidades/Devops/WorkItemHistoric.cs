using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DashAgil.Integrador.Entidades.Devops
{
    public class WorkItemHistoric
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("workItemId")]
        public long WorkItemId { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("revisedBy")]
        public RevisedBy RevisedBy { get; set; }

        [JsonProperty("revisedDate")]
        public DateTimeOffset RevisedDate { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Fields Fields { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("relations", NullValueHandling = NullValueHandling.Ignore)]
        public Relations Relations { get; set; }
    }

    public partial class Fields
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonPriority SystemId { get; set; }

        [JsonProperty("AreaId", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonPriority SystemAreaId { get; set; }

        [JsonProperty("NodeName", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemNodeName { get; set; }

        [JsonProperty("AreaLevel1", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemAreaLevel1 { get; set; }

        [JsonProperty("AreaLevel2", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemAreaLevel2 { get; set; }

        [JsonProperty("Rev")]
        public SystemPersonIdClass SystemRev { get; set; }

        [JsonProperty("AuthorizedDate")]
        public MicrosoftVstsCommonStateChangeDate SystemAuthorizedDate { get; set; }

        [JsonProperty("RevisedDate")]
        public MicrosoftVstsCommonStateChangeDate SystemRevisedDate { get; set; }

        [JsonProperty("IterationId", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonPriority SystemIterationId { get; set; }

        [JsonProperty("IterationLevel1", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemIterationLevel1 { get; set; }

        [JsonProperty("IterationLevel2", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemIterationLevel2 { get; set; }

        [JsonProperty("IterationLevel3", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemIterationLevel3 { get; set; }

        [JsonProperty("WorkItemType", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate SystemWorkItemType { get; set; }

        [JsonProperty("State", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate SystemState { get; set; }

        [JsonProperty("Reason", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate SystemReason { get; set; }

        [JsonProperty("AssignedTo", NullValueHandling = NullValueHandling.Ignore)]
        public SystemAssignedToClass SystemAssignedTo { get; set; }

        [JsonProperty("CreatedDate", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemCreatedDate { get; set; }

        [JsonProperty("CreatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public SystemCreatedBy SystemCreatedBy { get; set; }

        [JsonProperty("ChangedDate")]
        public MicrosoftVstsCommonStateChangeDate SystemChangedDate { get; set; }

        [JsonProperty("ChangedBy", NullValueHandling = NullValueHandling.Ignore)]
        public SystemAssignedToClass SystemChangedBy { get; set; }

        [JsonProperty("AuthorizedAs", NullValueHandling = NullValueHandling.Ignore)]
        public SystemAssignedToClass SystemAuthorizedAs { get; set; }

        [JsonProperty("PersonId", NullValueHandling = NullValueHandling.Ignore)]
        public SystemPersonIdClass SystemPersonId { get; set; }

        [JsonProperty("Watermark")]
        public SystemPersonIdClass SystemWatermark { get; set; }

        [JsonProperty("IsDeleted", NullValueHandling = NullValueHandling.Ignore)]
        public SystemBoardColumnDone SystemIsDeleted { get; set; }

        [JsonProperty("CommentCount", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonPriority SystemCommentCount { get; set; }

        [JsonProperty("TeamProject", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemTeamProject { get; set; }

        [JsonProperty("AreaPath", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemAreaPath { get; set; }

        [JsonProperty("IterationPath", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemIterationPath { get; set; }

        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemTitle { get; set; }

        [JsonProperty("BoardColumnDone", NullValueHandling = NullValueHandling.Ignore)]
        public SystemBoardColumnDone SystemBoardColumnDone { get; set; }

        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonPriority MicrosoftVstsCommonPriority { get; set; }

        [JsonProperty("ValueArea", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea MicrosoftVstsCommonValueArea { get; set; }

        [JsonProperty("Celula", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea BrsaCelula { get; set; }

        [JsonProperty("WEF_EF55015B19924144B8B5E8E7C247058C_ExtensionMarker", NullValueHandling = NullValueHandling.Ignore)]
        public SystemBoardColumnDone WefEf55015B19924144B8B5E8E7C247058CSystemExtensionMarker { get; set; }

        [JsonProperty("Column.Done", NullValueHandling = NullValueHandling.Ignore)]
        public SystemBoardColumnDone WefEf55015B19924144B8B5E8E7C247058CKanbanColumnDone { get; set; }

        [JsonProperty("WEF_F2B9FD539AF54BDEAE8A5BFB85454AFF_ExtensionMarker", NullValueHandling = NullValueHandling.Ignore)]
        public SystemBoardColumnDone WefF2B9Fd539Af54Bdeae8A5Bfb85454AffSystemExtensionMarker { get; set; } 

        [JsonProperty("BoardColumn", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate SystemBoardColumn { get; set; }

        [JsonProperty("StateChangeDate", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate MicrosoftVstsCommonStateChangeDate { get; set; }

        [JsonProperty("Column", NullValueHandling = NullValueHandling.Ignore)]
        public MicrosoftVstsCommonStateChangeDate WefEf55015B19924144B8B5E8E7C247058CKanbanColumn { get; set; }
        //[JsonProperty("StackRank", NullValueHandling = NullValueHandling.Ignore)]
        //public MicrosoftVstsCommonPriority MicrosoftVstsCommonStackRank { get; set; }

        [JsonProperty("StoryPoints", NullValueHandling = NullValueHandling.Ignore)]
        public Points MicrosoftVstsSchedulingStoryPoints { get; set; }

        [JsonProperty("Department", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea BrsaDepartment { get; set; }

        [JsonProperty("BusinessArea", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea BrsaBusinessArea { get; set; }

        [JsonProperty("StartDate", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea MicrosoftVstsSchedulingStartDate { get; set; }

        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea SystemDescription { get; set; }

        [JsonProperty("FinishDate", NullValueHandling = NullValueHandling.Ignore)]
        public BrsaBusinessArea MicrosoftVstsSchedulingFinishDate { get; set; }



        [JsonProperty("CompletedWork", NullValueHandling = NullValueHandling.Ignore)]
        public Horas CompletedWork { get; set; }

        [JsonProperty("OriginalEstimate", NullValueHandling = NullValueHandling.Ignore)]
        public Horas OriginalEstimate { get; set; }
    }

    public partial class BrsaBusinessArea
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OldValue { get; set; }
    }

    public partial class Horas
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OldValue { get; set; }
    }

    public partial class Points
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OldValue { get; set; }
    }


    public partial class MicrosoftVstsCommonPriority
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OldValue { get; set; }
    }

    public partial class MicrosoftVstsCommonStateChangeDate
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }

        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OldValue { get; set; }
    }

    public partial class SystemAssignedToClass
    {
        [JsonProperty("newValue", NullValueHandling = NullValueHandling.Ignore)]
        public RevisedBy NewValue { get; set; }

        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public RevisedBy OldValue { get; set; }
    }

    public partial class RevisedBy
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }
    }

    public partial class Avatar
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class SystemBoardColumnDone
    {
        [JsonProperty("newValue")]
        public bool NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public long OldValue { get; set; }
    }

    public partial class SystemCreatedBy
    {
        [JsonProperty("newValue")]
        public RevisedBy NewValue { get; set; }
        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public long OldValue { get; set; }
    }

    public partial class SystemPersonIdClass
    {
        [JsonProperty("newValue")]
        public long NewValue { get; set; }

        [JsonProperty("oldValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? OldValue { get; set; }
    }

    public partial class Relations
    {
        [JsonProperty("added")]
        public List<Added> Added { get; set; }
    }

    public partial class Added
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
