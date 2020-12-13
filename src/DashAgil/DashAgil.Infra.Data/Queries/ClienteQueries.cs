namespace DashAgil.Infra.Data.Queries
{
    public class ClienteQueries
    {
        public const string GetAllByProvedor =
            @"SELECT c.Id, c.Nome, c.ProvedorId, c.DataInicio, c.DataCancelamento, c.Status
                            FROM Clientes c
                            WHERE c.ProvedorId = @ProvedorId
                                AND c.Status = 1
                            ORDER BY c.Nome";
    }
}
