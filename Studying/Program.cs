WorkWithText();

static void WorkWithText()
{
    string textFile = Path.Combine(Environment.CurrentDirectory, "streams.txt");

    using (StreamWriter textWriter = new(textFile))
    {
        foreach (string item in Viper.Callsigns)
            textWriter.WriteLine(item);
    }

    Console.WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
    Console.WriteLine(File.ReadAllText(textFile));
}

static class Viper
{
    public static string[] Callsigns = new[]
    {
        "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack"
    };
}
