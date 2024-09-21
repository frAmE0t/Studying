Person[] people =
{
    new() { Name = "Yauhenui" },
    new() { Name = "Ilya" },
    new() { Name = "Egor" },
    new() { Name = "Dima" },
    new() { Name = "Matvey"}
};

Array.Sort(people);

foreach (Person p in people)
    Console.WriteLine(p.Name);

class Person : IComparable<Person>
{
    public string? Name { get; set; }

    public int CompareTo(Person? other)
    {
        if (Name is null)
            return 0;
        return Name.CompareTo(other?.Name);
    }
}
