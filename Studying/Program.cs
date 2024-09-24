Dictionary<string, string> dict = new()
{
    { "int", "32-bit integer data type"},
    { "long", "64-bit integer data type"},
    { "float", "Single precision floating point number"}
};

Output("Dictionary keys:", dict.Keys);
Output("\nDictionary values:", dict.Values);

Console.WriteLine("\nKeywords and their definitions:");

foreach (KeyValuePair<string, string> pair in dict)
    Console.WriteLine($"{pair.Key}: {pair.Value}");

static void Output(string title, IEnumerable<string> collect)
{
    Console.WriteLine(title);

    foreach (string item in collect)
        Console.WriteLine($"{item}");
}
