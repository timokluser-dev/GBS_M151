using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection connection =
                    new("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;Asynchronous Processing=True");
                connection.Open();

                SqlCommand command = new("WAITFOR DELAY '00:00:01'; SELECT COUNT(ProductID) AS count FROM Products;",
                    connection);
                IAsyncResult result = command.BeginExecuteReader();

                while (!result.IsCompleted)
                {
                    Console.WriteLine("Waiting...");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Done");

                var reader = command.EndExecuteReader(result);
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}