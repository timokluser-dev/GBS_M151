using System;
using System.Data.SqlClient;

namespace Task06
{
    class Program
    {
        private static string ConnectionString =
            "Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Update();
            Insert();
            Delete();
            Scalar();
            DataReader();
        }

        private static void Update()
        {
            using SqlConnection connection =
                new(ConnectionString);
            connection.Open();

            SqlCommand command = new("UPDATE Products SET ProductName='Sojasauce' WHERE ProductName='Chai';",
                connection);

            try
            {
                int affectedRows = command.ExecuteNonQuery();

                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine();
        }

        private static void Insert()
        {
            using SqlConnection connection =
                new(ConnectionString);
            connection.Open();

            SqlCommand command = new("INSERT INTO Products(ProductName, Discontinued) VALUES ('Schweizer Käse', 0);",
                connection);

            try
            {
                int affectedRows = command.ExecuteNonQuery();

                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine();
        }

        private static void Delete()
        {
            using SqlConnection connection =
                new(ConnectionString);
            connection.Open();

            SqlCommand command = new("DELETE FROM Products WHERE ProductName = 'Schweizer Käse';",
                connection);

            try
            {
                int affectedRows = command.ExecuteNonQuery();

                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine();
        }

        private static void Scalar()
        {
            using SqlConnection connection =
                new(ConnectionString);
            connection.Open();

            SqlCommand command = new("SELECT COUNT(ProductID) FROM Products WHERE CategoryID = 1;",
                connection);

            try
            {
                int rows = (int) command.ExecuteScalar();

                Console.WriteLine($"Count: {rows}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine();
        }

        private static void DataReader()
        {
            using SqlConnection connection =
                new(ConnectionString);
            connection.Open();

            SqlCommand command = new("SELECT ProductName, UnitPrice FROM Products ORDER BY UnitPrice;",
                connection);

            try
            {
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]} - Price: {reader["UnitPrice"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine();
        }
    }
}