using System;
using System.Threading.Tasks;
using EFCoreDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDbFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new NorthwindContext();
            
            foreach (var customer in await context.Customers.ToListAsync())
            {
                Console.WriteLine($"{customer.CustomerId}\t{customer.CompanyName}: {customer.ContactName}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"-- {order.OrderId}:");

                    foreach (var detail in order.OrderDetails)
                    {
                        Console.WriteLine($"--------- {detail.ProductId}: {detail.Quantity}x {detail.Product.ProductName}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
