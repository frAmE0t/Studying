using Northwind.EntityModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        Console.WriteLine($"Endpoint name: {rep.DisplayName}");
        Console.WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }

    if (context.Request.Path == "/bonjour")
    {
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    // You could modify the request before calling the next delegate.
    await next();
    // You could modify the response delegete after calling the next delegate.
});

app.UseHttpsRedirection();

app.UseDefaultFiles(); // index.html or default.html etc.
app.UseStaticFiles(); // Loks in wwwroot for static files.

app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

app.Run();
Console.WriteLine("This executes after the web server has stopped!");
