using ADO.Net.Training;

namespace AdoNetConsoleApp
{
    class Program
    {
        private static DataService _dataService;
        
        static void Main(string[] args)
        {
            _dataService = new DataService();

            SelectData().GetAwaiter().GetResult();

            AddData().GetAwaiter().GetResult();
            SelectData().GetAwaiter().GetResult();

            UpdateData().GetAwaiter().GetResult();
            SelectData().GetAwaiter().GetResult();

            DeleteData().GetAwaiter().GetResult();
            SelectData().GetAwaiter().GetResult();

            Console.Read();
        }

        static Task SelectData()
        {
            _dataService.SelectData();
            return Task.CompletedTask;
        }

        static Task AddData()
        {
            string sqlExpression = "INSERT INTO Users (UserID, FirstName, LastName, Email, PhoneNumber, Gender) VALUES (7, 'qwe', 'qwe', 'qwe', 'qwe','qwe')";
            _dataService.ExecuteSqlExpression(sqlExpression);

            return Task.CompletedTask;
        }

        static Task UpdateData()
        {

            string sqlExpression = "UPDATE Users SET FirstName='Artem' WHERE UserID = 7";
            _dataService.ExecuteSqlExpression(sqlExpression);

            return Task.CompletedTask;
        }

        static Task DeleteData()
        {
            string sqlExpression = "DELETE FROM Users WHERE LastName='qwe'";
            _dataService.ExecuteSqlExpression(sqlExpression);

            return Task.CompletedTask;
        }
    }
}