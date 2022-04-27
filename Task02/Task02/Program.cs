using System;
using System.Data.SqlClient;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();

            conBuilder.DataSource = "localhost,14330";
            conBuilder.InitialCatalog = "Northwind";
            conBuilder.UserID = "sa";
            conBuilder.Password = "DEV_1234";

            con.ConnectionString = conBuilder.ConnectionString;

            try
            {
                con.Open();
                Console.WriteLine("🚀 it worked 🚀");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("🙁 Db not found 🙁");
            }
        }
    }
}
