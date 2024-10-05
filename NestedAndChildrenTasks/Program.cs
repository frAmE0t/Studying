Task outerTask = Task.Factory.StartNew(OuterMethod);
outerTask.Wait();
Console.WriteLine("Console app is stopping");

static void OuterMethod()
{
    Console.WriteLine("Outer method starting...");
    Task innerTask = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
    Console.WriteLine("Outer method finished.");
}

static void InnerMethod()
{
    Console.WriteLine("Inner method starting...");
    //Thread.Sleep(2000);
    Console.WriteLine("Inner method finished.");
}
