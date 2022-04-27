using System;
using System.Data;
using System.Data.SqlClient;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;");
            connection.Open();

            // prepare command with procedure
            SqlCommand command = new("SearchProducts", connection);
            command.CommandType = CommandType.StoredProcedure;

            // fill parameters
            command.Parameters.Add("@Price", SqlDbType.Money);
            command.Parameters.Add("@OrderedUnits", SqlDbType.SmallInt);
            command.Parameters["@Price"].Value = 10;
            command.Parameters["@OrderedUnits"].Value = 0;

            // execute command
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ProductName"]);
            }
            reader.Close();

            connection.Close();

            Console.WriteLine();

            Complex();
        }

        static void Complex()
        {
            SqlConnection connection = new("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;");
            connection.Open();

            // prepare command with procedure
            SqlCommand command = new("GetProduct", connection);
            command.CommandType = CommandType.StoredProcedure;

            // add parameters
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters.Add("@Article", SqlDbType.VarChar, 40);
            command.Parameters.Add("@Price", SqlDbType.Money);
            command.Parameters.Add("@RetValue", SqlDbType.Int);

            // parameter direction
            command.Parameters["@Id"].Direction = ParameterDirection.Input;
            command.Parameters["@Article"].Direction = ParameterDirection.Output;
            command.Parameters["@Price"].Direction = ParameterDirection.Output;
            command.Parameters["@RetValue"].Direction = ParameterDirection.ReturnValue;

            // fill parameters
            command.Parameters["@Id"].Value = 1;

            // execute command
            command.ExecuteNonQuery();

            if ((int)command.Parameters["@RetValue"].Value == 1)
            {
                Console.WriteLine($"Article: {command.Parameters["@Article"].Value}");
                Console.WriteLine($"Price: {command.Parameters["@Price"].Value}");
            }

            Console.WriteLine($"👉 {command.Parameters["@RetValue"].Value} rows found");

            connection.Close();
        }
    }
}
