using Microsoft.EntityFrameworkCore;
using Packt.Shared;

FilterAndSort();

static void FilterAndSort()
{
    using (Northwind db = new())
    {
        DbSet<Product>? allProducts = db.Products;
        IQueryable<Product>? filteredProducts = allProducts.Where(p => p.UnitPrice < 10M);
        IOrderedQueryable<Product>? filteredAndSortedProducts = filteredProducts.OrderByDescending(p => p.UnitPrice);

        var projectedProducts = filteredAndSortedProducts.Select(p => new
        {
            p.ProductId,
            p.ProductName,
            p.UnitPrice
        });

        Console.WriteLine("Products that cost less then $10:");

        foreach (var p in projectedProducts)
            Console.WriteLine($"{p.ProductId}: {p.ProductName} costs {p.UnitPrice:$#,##0.00}");
        Console.WriteLine();
    }
}
