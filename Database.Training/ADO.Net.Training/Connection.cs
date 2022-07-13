using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ADO.Net.Training
{
    public class Connection : IDisposable
    {
        private SqlConnection _connection;

        public Connection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetSqlConnection()
        {
            try
            {
                _connection.Open();
                Console.WriteLine("Подключение выполненно успешно");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}