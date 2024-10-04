using System.Diagnostics;

namespace Packt.Shared
{
    public class Recorder
    {
        private static Stopwatch timer = new Stopwatch();
        private static long bytesPhysicalBefore = 0;
        private static long bytesVirtualBefore = 0;

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            bytesPhysicalBefore = Process.GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = Process.GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();

            long bytesPhysicalAfter = Process.GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = Process.GetCurrentProcess().VirtualMemorySize64;

            Console.WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            Console.WriteLine($"{bytesVirtualAfter - bytesVirtualBefore:N0} virtual bytes used.");
            Console.WriteLine($"{timer.Elapsed} time span ellapsed.");
            Console.WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds elapsed.", timer.Elapsed);
        }
    }
}
