namespace DashAgil.Infra.Data.Queries
{
    public class ClienteQueries
    {
        public const string GetAllByProvedor =
            @"SELECT c.Id, c.Nome, c.ProvedorId, c.DataInicio, c.DataCancelamento, c.Status
                            FROM Clientes c                                 
                            WHERE c.ProvedorId = @ProvedorId
                                AND c.Status = 1
                                --AND EXISTS(SELECT TOP 1 1 FROM UsuarioSquads us WHERE c.Id = us.ClienteId AND us.UsuarioId = @UsuarioId)
                            ORDER BY c.Nome";
    }
}
