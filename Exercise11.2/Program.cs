using Microsoft.IdentityModel.Tokens;
using Packt.Shared;

using (Northwind db = new())
{
    IQueryable<string?>? allCities = db.Customers?.Select(c => c.City).Distinct();

    Console.WriteLine("Cities list: ");

    foreach (string str in allCities)
        Console.Write($"{str}, ");

    Console.Write("\nEnter the name of a city: ");
    string? cityName = Console.ReadLine();

    IQueryable<Customer?>? companiesInCity = db.Customers?.Where(p => p.City == cityName);

    if (companiesInCity.IsNullOrEmpty())
        Console.WriteLine($"No customers found in {cityName}.");
    else
    {
        Console.WriteLine($"There are {companiesInCity.Count()} customers in {cityName}:");

        foreach (Customer c in companiesInCity)
            Console.WriteLine(c.CompanyName);
    }
}

