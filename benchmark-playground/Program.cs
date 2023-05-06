using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace benchmark_playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchAsync>();

            Console.WriteLine("Hello, World!");
        }
    }


    public class BenchAsync
    {
        [Benchmark]
        public async Task<string> AsyncMethod()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}