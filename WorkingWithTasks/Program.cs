using System.Diagnostics;

OutputThreadInfo();

Stopwatch timer = Stopwatch.StartNew();

//Console.WriteLine("Running methods synchronously on one thread.");

//MethodA();
//MethodB();
//MethodC();

//Console.WriteLine("Running methods asynchronously on multiple threads.");

//Task taskA = new(MethodA);
//taskA.Start();

//Task taskB = Task.Factory.StartNew(MethodB);

//Task taskC = Task.Run(MethodC);

//Task[] tasks = {taskA, taskB, taskC};
//Task.WaitAll(tasks);

//Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elaplsed.");

Console.WriteLine("Passing the result of one task as an input into another.");

Task<string> taskServiceThenSPRoc = Task.Factory
    .StartNew(CallWebService)
    .ContinueWith(previousResult => CallStoredProcedure(previousResult.Result));

Console.WriteLine($"Result: {taskServiceThenSPRoc.Result}");

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

static decimal CallWebService()
{
    Console.WriteLine("Starting call to web service...");
    OutputThreadInfo();
    Thread.Sleep((new Random()).Next(2000, 4000));
    Console.WriteLine("Finished call to web service.");
    return 89.99M;
}

static string CallStoredProcedure(decimal amount)
{
    Console.WriteLine("Starting call to stored procedure.");
    OutputThreadInfo();
    Thread.Sleep((new Random()).Next(2000, 4000));
    Console.WriteLine("Finished call to stored procedure.");
    return $"12 products cost more than {amount:C}.";
}
