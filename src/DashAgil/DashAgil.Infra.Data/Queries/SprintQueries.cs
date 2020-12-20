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
				INNER JOIN Projetos p on s.ProjetoId = p.Id
				INNER JOIN Squads sq on p.Id = sq.ProjetoId
			WHERE
				sq.Id = @SquadId
			ORDER BY s.Nome";

        public const string SprintById = @" SELECT s.Id, s.Nome, s.ExternalId, s.Descricao, s.ProjetoId, s.DataInicio, s.DataFim, s.DataConclusao, s.Status
                                            FROM Sprints s
                                            WHERE s.Id = @sprintId ";
    }
}
