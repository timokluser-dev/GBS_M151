using System;
using System.Data;
using System.Data.SqlClient;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using SqlConnection connection =
                    new("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;");
                connection.Open();

                SqlCommand command =
                    new("SELECT * FROM Products WHERE ProductName = @ProductName OR CategoryID = @CategoryID",
                        connection);

                command.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = "Konbu";
                command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = 1;

                var reader = command.ExecuteReader();

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