using MySqlConnector;
using System;
using System.Data.SqlClient;

namespace DashAgil.Infra.Data.Context
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DataContext(string connection)
        {
            Connection = new SqlConnection(connection);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }
    }
}
