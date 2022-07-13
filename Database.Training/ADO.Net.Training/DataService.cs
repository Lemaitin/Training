using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO.Net.Training
{
    public class DataService
    {
        public Task ExecuteSqlExpression(string sqlExpression)
        {
            using var connection = new Connection();

            SqlCommand command = new SqlCommand(sqlExpression, connection.GetSqlConnection());
            int number = command.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public Task SelectData()
        {
            using var connection = new Connection();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", connection.GetSqlConnection());
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "Users");

            foreach (DataRow dataRow in dataset.Tables["Users"].Rows)
            {
                Console.WriteLine($"{dataRow["UserID"]} {dataRow["FirstName"]} {dataRow["LastName"]} {dataRow["Email"]} " +
                    $"{dataRow["PhoneNumber"]} {dataRow["Gender"]}");
            }
            return Task.CompletedTask;
        }
    }
}