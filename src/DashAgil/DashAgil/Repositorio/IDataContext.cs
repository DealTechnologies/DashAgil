using MySqlConnector;

namespace DashAgil.Repositorio
{
    public interface IDataContext
    {
        MySqlConnection Connection { get; set; }
    }
}
