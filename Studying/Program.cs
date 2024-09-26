using System.Xml.Serialization;

List<Person> people = new()
{
    new(30000M)
    {
        FirsName = "Alice",
        SecondName = "Smith",
        DateOfBirth = new DateTime(1974, 3, 14)
    },

    new(40000M)
    {
        FirsName = "Bob",
        SecondName = "Jones",
        DateOfBirth = new DateTime(1969, 11, 23)
    },

    new(20000M)
    {
        FirsName = "Charlie",
        SecondName = "Cox",
        DateOfBirth = new DateTime(1984, 5, 4),
        Children = new()
        {
            new(0M)
            {
                FirsName = "Sally",
                SecondName = "Cox",
                DateOfBirth = new(2000, 7, 12)
            }
        }
    }
};

XmlSerializer xml = new(people.GetType());
string path = Path.Combine(Environment.CurrentDirectory, "people.xml");

using (StreamWriter stream = new(path))
{
    xml.Serialize(stream, people);
}

Console.WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");

Console.WriteLine(File.ReadAllText(path));

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
