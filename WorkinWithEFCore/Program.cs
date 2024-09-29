using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Packt.Shared;

//QueryingCategories();
//FilteredIncludes();
//QueryingProducts();
//if (AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, discontinued: true))
//    Console.WriteLine("Add product successful.");
if (IncreaseProductPrice("Bob", 20M))
    Console.WriteLine("Update product price successful.");
ListProducts();

static void QueryingCategories()
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

static bool AddProduct(int categoryId, string productName, decimal? price, bool discontinued)
{
    using (Northwind db = new())
    {
        Product p = new Product()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Cost = price,
            Discontinued = discontinued
        };

        db.Products?.Add(p);

        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static void ListProducts()
{
    using (Northwind db = new())
    {
        Console.WriteLine($"{"Id", -3} {"Product Name", -35} {"Cost", 8} {"Stock", 5} Disc.");
        
        foreach (Product p in db.Products.OrderByDescending(product => product.Cost))
            Console.WriteLine($"{p.ProductId:000} {p.ProductName, -35} {p.Cost, 8:$#,##0.00} {p.Stock, 5} {p.Discontinued}");
    }
}

static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
{
    using (Northwind db = new())
    {
        Product updateProduct = db.Products
            .First(p => p.ProductName.StartsWith(productNameStartsWith));

        updateProduct.Cost += amount;

        int affected = db.SaveChanges();

        return (affected == 1);
    }
}
