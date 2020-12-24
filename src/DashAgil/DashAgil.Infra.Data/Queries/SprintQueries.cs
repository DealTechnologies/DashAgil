namespace DashAgil.Infra.Data.Queries
{
    public class SprintQueries
    {
        public const string GetAllByCliente =
            @"SELECT s.Id, s.Nome, s.ExternalId, s.Descricao, s.ProjetoId, s.DataInicio, s.DataFim, s.DataConclusao, s.Status
                            FROM Sprints s
                                INNER JOIN Projetos p on s.ProjetoId = p.Id
                                INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id
                            WHERE o.ClienteId = @ClienteId
                                  --and EXISTS(SELECT TOP 1 1 FROM UsuarioSquads us WHERE o.ClienteId = us.ClienteId AND us.UsuarioId = @UsuarioId)
                            ORDER BY s.Nome";

        public const string SprintById = @" SELECT s.Id, s.Nome, s.ExternalId, s.Descricao, s.ProjetoId, s.DataInicio, s.DataFim, s.DataConclusao, s.Status
                                            FROM Sprints s
                                            WHERE s.Id = @sprintId ";
    }
}
