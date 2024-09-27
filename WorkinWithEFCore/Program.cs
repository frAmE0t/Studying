using Microsoft.EntityFrameworkCore;
using Packt.Shared;

QueryintCategories();
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
