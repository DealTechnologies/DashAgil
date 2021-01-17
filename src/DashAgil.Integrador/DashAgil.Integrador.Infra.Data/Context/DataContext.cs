using System;
using System.Data.SqlClient;

namespace DashAgil.Integrador.Infra.Data.Context
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DataContext(string connectionString)
        {
            this.Connection = new SqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
