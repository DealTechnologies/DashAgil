using System.ComponentModel;

namespace DashAgil.Enums
{
    public enum EDemandaTipo
    {
        [Description("Epic")]
        Epic = 1,
        [Description("Feature")]
        Feature = 2,
        [Description("User Story")]
        UserStory = 3,
        [Description("Task")]
        Task = 4,
        [Description("Bug")]
        Bug = 5
    }
}
