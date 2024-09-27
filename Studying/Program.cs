using NewJson = System.Text.Json.JsonSerializer;

string jsonPath = Path.Combine(Environment.CurrentDirectory, "people.json");

using (FileStream stream = File.Open(jsonPath, FileMode.Open))
{
    List<Person>? people = NewJson.Deserialize(stream, typeof(List<Person>)) as List<Person>;

    if (people is not null)
    {
        foreach (Person person in people)
            Console.WriteLine($"{person.FirsName} {person.SecondName} has {person.Children?.Count ?? 0} children.");
    }
}

public class Person
{
    public Person(decimal salary)
    {
        Salary = salary;
    }
    public Person() { }

    public string? FirsName { get; set; }
    public string? SecondName { get; set; }
    public HashSet<Person>? Children { get; set; }
    public DateTime DateOfBirth { get; set; }
    protected decimal Salary { get; set; }
}
