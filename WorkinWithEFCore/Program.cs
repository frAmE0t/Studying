using Microsoft.EntityFrameworkCore;
using Packt.Shared;

//QueryintCategories();
FilteredIncludes();
static void QueryintCategories()
{
    using (Northwind db = new())
    {
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
