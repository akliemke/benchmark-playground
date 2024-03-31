using System.Diagnostics;
using BenchmarkDotNet;
namespace YieldNToList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            //BenchmarkDotNet.Running.BenchmarkRunner.Run<YieldNToList>();
            var yieldNToList = new YieldNToList();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var x = yieldNToList.GetYieldSlow(10).ToList();
            //var x = yieldNToList.GetYieldSlow(10);
            Console.WriteLine(x.Sum());
            Console.WriteLine(x.Sum());
            stopWatch.Stop();
            Console.WriteLine($"{stopWatch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

    }
}
