using System.Diagnostics;

OutputThreadInfo();

Stopwatch timer = Stopwatch.StartNew();

Console.WriteLine("Running methods synchronously on one thread.");

MethodA();
MethodB();
MethodC();

Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elaplsed.");

static void OutputThreadInfo()
{
    Thread t = Thread.CurrentThread;

    Console.WriteLine($"Thread Id: {t.ManagedThreadId}, Priority: {t.Priority}, Background: {t.IsBackground}, Name: {t.Name ?? "null"}");
}

static void MethodA()
{
    Console.WriteLine("Starting Method A...");
    OutputThreadInfo();
    Thread.Sleep(3000);
    Console.WriteLine("Finished Method A.");
}

static void MethodB()
{
    Console.WriteLine("Starting Method B...");
    OutputThreadInfo();
    Thread.Sleep(2000);
    Console.WriteLine("Finished Method B.");
}

static void MethodC()
{
    Console.WriteLine("Starting Method C...");
    OutputThreadInfo();
    Thread.Sleep(1000);
    Console.WriteLine("Finished Method C.");
}
