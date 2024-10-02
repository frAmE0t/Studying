using Microsoft.EntityFrameworkCore;
using Packt.Shared;

//FilterAndSort();
//JoinCategoriesAndProducts();
GroupJoinCategoriesAndProducts();

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

static void JoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryJoin = db.Categories.Join(db.Products, category => category.CategoryID, products => products.CategoryId, (c, p) => new
        {
            c.CategoryName, p.ProductName, p.ProductId
        });

        foreach (var item in queryJoin)
            Console.WriteLine($"{item.ProductId}: {item.ProductName} is in {item.CategoryName}.");
    }
}

static void GroupJoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(db.Products, category => category.CategoryID, product => product.CategoryId, (c, matchingProducts) => new
        {
            c.CategoryName,
            Products = matchingProducts.OrderBy(p => p.ProductName)
        });

        foreach (var c in queryGroup)
        {
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");

            foreach (var p in c.Products)
                Console.WriteLine($"   {p.ProductName}");
        }
    }
}
