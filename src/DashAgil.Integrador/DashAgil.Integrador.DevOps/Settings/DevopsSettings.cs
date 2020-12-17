namespace DashAgil.Integrador.DevOps.Settings
{
    public class DevopsSettings
    {
        public string RendimentoId { get; set; }
        public string CorporativoIds { get; set; }
        public EndPointsDevops EndPoints { get; set; } = new EndPointsDevops();
        public Queries Queries { get; set; }
    }

    public class Queries
    {
        public string AllEpics { get; set; }
        public string AllFeatures { get; set; }
        public string AllUS { get; set; }
        public string AllTasks { get; set; }
    }
    public class EndPointsDevops
    {
        public string URI { get; set; }
        public string Projetos { get; set; }
        public string Boards { get ; set ; }
        public string WorkItemTypes { get; set; }
        public string WorkItemByQuery { get; set; }
        public string WorkItemById { get; set; }
    }
}
