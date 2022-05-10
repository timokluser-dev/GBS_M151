using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new("Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;");

            string selectCommand = "SELECT * FROM Products; SELECT * FROM Suppliers; SELECT * FROM Categories";
            SqlCommand command = new(selectCommand, connection);

            SqlDataAdapter dataAdapter = new(command);
            SqlCommandBuilder commandBuilder = new(dataAdapter);
            dataAdapter.TableMappings.Add("Table", "Products");
            dataAdapter.TableMappings.Add("Table1", "Suppliers");
            dataAdapter.TableMappings.Add("Table2", "Categories");

            DataSet dataSet = new();
            dataAdapter.Fill(dataSet);

            // --- SELECT
            foreach (DataRow row in dataSet.Tables["Products"].Rows)
            {
                Console.WriteLine($"{row["ProductID"]} {row["ProductName"]}");
            }

            Console.WriteLine();
            Console.WriteLine();

            // --- UPDATE
            DataTable products = dataSet.Tables["Products"];
            DataRow product = products.Rows[0];

            try
            {
                product.BeginEdit();
                product["ProductName"] = "Starbucks Coffee";
                product.EndEdit();
            }
            catch (Exception)
            {
                product.CancelEdit();
            }

            dataAdapter.Update(dataSet);

            Console.WriteLine("Updated Product:");
            Console.WriteLine($"{product["ProductID"]} {product["ProductName"]}");

            Console.WriteLine();
            Console.WriteLine();

            // --- INSERT
            DataRow newProduct = products.NewRow();
            newProduct["ProductName"] = "Starbucks Frappuccino Caramel";
            newProduct["Discontinued"] = false;
            products.Rows.Add(newProduct);

            if (dataAdapter.Update(products) < 1)
            {
                Console.WriteLine("Error while creating new product");
            }

            // --- DELETE
            DataRow productToDelete = products.AsEnumerable()
                .Where(product => product.Field<string>("ProductName") == "Chocolade")
                .FirstOrDefault();
            products.Rows.Remove(productToDelete);

            dataAdapter.Update(products);
        }
    }
}
