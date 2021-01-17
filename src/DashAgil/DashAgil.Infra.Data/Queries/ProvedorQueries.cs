namespace DashAgil.Infra.Data.Queries
{
    public class ProvedorQueries
    {
        public const string GetAllAtivos =
            @"SELECT p.Id, p.Descricao, p.Ativo
                            FROM Provedores p
                            WHERE p.Ativo = 1
                            ORDER BY p.Descricao";
    }
}
