using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Packt.Shared;

//QueryintCategories();
//FilteredIncludes();
QueryingProducts();

static void QueryintCategories()
{
    using (Northwind db = new())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        Console.WriteLine("Categories and how many products they have:");

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);

        if (categories is null)
        {
            Console.WriteLine("No categories found.");
            return;
        }

        foreach (Category c in categories)
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
    }
}

static void FilteredIncludes()
{
    using (Northwind db = new())
    {
        Console.Write("Enter a minimum for units in stock: ");
        string unitsInStock = Console.ReadLine() ?? "10";
        int stock = int.Parse(unitsInStock);

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products.Where(p => p.Stock >= stock));

        if (categories is null)
        {
            Console.WriteLine("No categories found");
            return;
        }

        foreach (Category c in categories)
        {
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

            foreach (Product p in c.Products)
                Console.WriteLine($"{p.ProductName} has {p.Stock} units in stock.");
        }
    }
}

static void QueryingProducts()
{
    using (Northwind db = new())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        Console.WriteLine("Products that cost more than a price, highest at top.");
        string? input;
        decimal price;

        do
        {
            Console.Write("Enter a product price: ");
            input = Console.ReadLine();
        } while (!decimal.TryParse(input, out price));

        IQueryable<Product>? products = db.Products?
            .Where(p => p.Cost >= price)
            .OrderByDescending(p => p.Cost);

        if (products is null)
        {
            Console.WriteLine("No products found.");
            return;
        }

        foreach (Product p in products)
            Console.WriteLine($"{p.ProductId} : {p.ProductName} costs {p.Cost:$#,##0.00} and has {p.Stock} in stock.");
    }
}
