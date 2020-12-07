namespace DashAgil.Integrador.DevOps.Queries
{
    public static class TiposWorkItensDevopsQueries
    {
        public const string Insert = @"IF(select 1 from DashAgil.dbo.TiposWorkItensDevops
                                       	    where WorkItemTypeId = @WorkItemTypeId) IS NULL
                                       BEGIN
                                       	    INSERT INTO DashAgil.dbo.TiposWorkItensDevops (Id, Nome, Url, WorkItemTypeId, DataCadastro)
                                       	    VALUES (@Id, @Nome, @Url, @WorkItemTypeId, @DataCadastro)
                                       END";
    }
}
