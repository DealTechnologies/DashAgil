namespace DashAgil.Infra.Data.Queries
{
    public class SprintQueries
    {
        public const string GetAllBySquadId =
			@"SELECT
				s.Id,
				s.Nome,
				s.ExternalId,
				s.Descricao,
				s.ProjetoId,
				s.DataInicio,
				s.DataFim,
				s.DataConclusao,
				s.Status
			FROM Sprints s	
			WHERE
				s.SquadId = @SquadId
			ORDER BY s.DataInicio, s.Nome desc";

        public const string SprintById = @" SELECT s.Id, s.Nome, s.ExternalId, s.Descricao, s.ProjetoId, s.DataInicio, s.DataFim, s.DataConclusao, s.Status
                                            FROM Sprints s
                                            WHERE s.Id = @sprintId ";
    }
}
