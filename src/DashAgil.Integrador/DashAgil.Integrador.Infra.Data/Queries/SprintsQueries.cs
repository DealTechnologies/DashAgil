namespace DashAgil.Integrador.Infra.Data.Queries
{
    public static class SprintsQueries
    {
        public const string Insert = @"INSERT INTO DashAgil.dbo.Sprints (ExternalId,ProjetoId,Nome,Descricao,DataInicio,DataFim,DataConclusao, Status)
                                       VALUES (@ExternalId,@ProjetoId,@Nome,@Descricao,@DataInicio,@DataFim,@DataConclusao,@Status) ";

		public const string Update = @"UPDATE DashAgil.dbo.Sprints set
									   		  ExternalId = @ExternalId,
									   		  ProjetoId = @ProjetoId,
									   		  Nome = @Nome,
									   		  Descricao = @Descricao,
									   		  DataInicio = @DataInicio,
									   		  DataFim = @DataFim,
									   		  DataConclusao = @DataConclusao,
									   		  Status = @Status
									   where Id  = @Id ";

		public const string Select = @"select * from DashAgil.dbo.Sprints";

		public const string SelectById = @"select * from DashAgil.dbo.Sprints where Id = @Id";

		public const string Delete = @"DELETE FROM DashAgil.dbo.Sprints where Id = @Id";
	}
}
