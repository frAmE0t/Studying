string dir = Path.Combine(Environment.CurrentDirectory, "Code", "Chapter09", "OutputFiles");

Directory.CreateDirectory(dir);

string textFile = Path.Combine(dir, "Dummy.txt");
string backupFile = Path.Combine(dir, "Dummy.bak");

Console.WriteLine($"Working with {textFile}");
Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

using (StreamWriter textWriter = new(textFile))
{
    textWriter.WriteLine("Hello, C#!");
}

Console.WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

File.Copy(textFile, backupFile, true);

Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

Console.Write("Confirm the file exist, and then press ENTER: ");
Console.ReadLine();

File.Delete(textFile);

Console.WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

using (StreamReader textReader = new(backupFile))
{
    Console.WriteLine($"Reading content of {backupFile}");
    Console.WriteLine(textReader.ReadToEnd());
}
