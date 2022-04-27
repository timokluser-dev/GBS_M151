using System;
using System.Data.SqlClient;
using System.Threading;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "localhost,14330";
            connectionStringBuilder.InitialCatalog = "Northwind";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "DEV_1234";

            connectionStringBuilder.Pooling = true; // <- Pooling - reuse existing connection

            SqlConnection connection = new(connectionStringBuilder.ConnectionString);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    connection.Open();
                    Console.WriteLine($"🚀 {i + 1}: it worked 🚀");
                    connection.Close();

                    Thread.Sleep(100);
                }


                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("🙁 error while connecting 🙁");
            }
        }

        static void GenericConnect()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "localhost,14330";
            connectionStringBuilder.InitialCatalog = "Northwind";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "DEV_1234";

            using (SqlConnection connection = new(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    Console.WriteLine("🚀 it worked 🚀");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("🙁 error while connecting 🙁");
                }
            }
        }

        static void ConnectWithManualDisapose()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "localhost,14330";
            connectionStringBuilder.InitialCatalog = "Northwind";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "DEV_1234";

            SqlConnection connection = new(connectionStringBuilder.ConnectionString);
            try
            {
                connection.Open();

                Console.WriteLine("🚀 it worked 🚀");
                Console.ReadLine();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("🙁 error while connecting 🙁");
            }
        }
    }
}
