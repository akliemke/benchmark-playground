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
            var x = yieldNToList.GetYieldSlow(10).ToList(); // com o to list, iremos alocar a lista inteira na memória, o que pode ser ruim para grandes quantidades de dados
            //var x = yieldNToList.GetYieldSlow(10); // sem o to list, iremos iterar sobre os elementos todas as vezes
            //                                          em que Sum() o IEnumerable for usado, o que pode ser mais lento mas não irá alocar a lista inteira na memória
            Console.WriteLine(x.Sum());
            Console.WriteLine(x.Sum());
            stopWatch.Stop();
            Console.WriteLine($"{stopWatch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

    }
}
