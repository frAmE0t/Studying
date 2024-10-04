using Packt.Shared;

Console.WriteLine("Processing. Please wait...");

Recorder.Start();

int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();

Thread.Sleep(new Random().Next(5, 10) * 1000);

Recorder.Stop();
