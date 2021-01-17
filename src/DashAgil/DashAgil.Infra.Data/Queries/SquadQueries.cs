namespace DashAgil.Infra.Data.Queries
{
    public class SquadQueries
    {
        public const string GetAllAtivosByCliente =
            @"SELECT s.Id, s.Nome, s.Descricao, s.ProjetoId, s.SubSquadId, s.DataInicio, s.DataFim, s.Status
                            FROM Squads s
                                INNER JOIN Projetos p on s.ProjetoId = p.Id
                                INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id
                            WHERE o.ClienteId = @ClienteId
                                  AND s.Status = 1
                                  --and EXISTS(SELECT TOP 1 1 FROM UsuarioSquads us WHERE o.ClienteId = us.ClienteId AND s.Id = us.SquadId AND us.UsuarioId = @UsuarioId)
                            ORDER BY s.Nome";
    }
}
