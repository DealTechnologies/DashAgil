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
                            ORDER BY s.Nome";
    }
}
