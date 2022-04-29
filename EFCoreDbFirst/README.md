# EF Core - DB First

## install dependencies

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.4

dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.4

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.4

dotnet tool install --global dotnet-ef
```

## scaffold from db

```bash
dotnet ef dbcontext scaffold "Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;" Microsoft.EntityFrameworkCore.SqlServer --context NorthwindContext --output-dir Models  --namespace EFCoreDbFirst.Models
```

> :warning: remove connection string from `Models/NorthwindContext::OnConfiguring`

## add lazy loading

```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 5.0.4
```

File: `Models/NorthwindContext.cs`
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // ...
    optionsBuilder.UseLazyLoadingProxies();
    // ...
}
```

## use db context

```c#
static async Task Main(string[] args)
{
    using (var context = new NorthwindContext()) 
    {
        foreach (var customer in await context.Customers.ToListAsync())
        {
            // ...

            // use the lazy loading
            foreach (var order in customer.Orders)
            {
                // ...
            }
        }
    }
}
```

## information about ef core

- :arrow_right: [docs.microsoft.com](https://docs.microsoft.com/en-us/ef/core/)
- [entityframeworktutorial.net](https://www.entityframeworktutorial.net/)
- [learnentityframeworkcore5.com](https://www.learnentityframeworkcore5.com/)
