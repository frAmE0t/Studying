using Exercise02;
using Newtonsoft.Json;

using (Northwind db = new())
{
    string categoriesPath = Path.Combine(Environment.CurrentDirectory, "SerializationCategories.json");
    string productsPath = Path.Combine(Environment.CurrentDirectory, "SerializationProducts.json");

    IQueryable<Product>? products = db.Products;
    IQueryable<Category>? categories = db.Categories;    

    using (StreamWriter textWriter = new(categoriesPath))
    {
        JsonSerializer json = new();
        json.Serialize(textWriter, categories);

        Console.WriteLine($"Categories were successfuly serialized to {categoriesPath}");
    }

    using (StreamWriter textWriter = new(productsPath))
    {
        JsonSerializer json = new();
        json.Serialize(textWriter, products);

        Console.WriteLine($"Products were successfuly serialized to {productsPath}");
    }
}
