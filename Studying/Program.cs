Person[] people =
{
    new() { Name = "Alexander" },
    new() { Name = "Noah" },
    new() { Name = "Michael" },
    new() { Name = "Edward" },
    new() { Name = "Steve"}
};

Array.Sort(people, new PersonComparer());

foreach (Person p in people)
    Console.WriteLine(p.Name);

public class Person
{
    public string? Name { get; set; }
}

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null)
            return 0;

        int result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
            return x.Name.CompareTo(y.Name);

        else
        {
            return result;
        }
    }
}
