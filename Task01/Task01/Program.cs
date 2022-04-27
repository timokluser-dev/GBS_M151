using System;
using System.Data.SqlClient;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;"))
            {
                try
                {
                    connection.Open();

                    Console.WriteLine("🚀 it worked 🚀");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
