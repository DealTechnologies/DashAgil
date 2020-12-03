using MySqlConnector;
using System;

namespace DashAgil.Infra.Data.Context
{
    public class DataContext : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DataContext(string connection)
        {
            Connection = new MySqlConnection(connection);
            Connection.Open();
        }

        public void Dispose() => Connection.Dispose();
    }
}
