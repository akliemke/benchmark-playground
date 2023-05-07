using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace benchmark_playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchAsync>();
        }
    }


    public class BenchAsync
    {
        [Benchmark]
        public async Task WithTaskRunOutside()
        {
            await Task.Run( ()  =>
            {
                for (var i = 0; i < 1000; i++)
                {
                    Task.Delay(1000);
                }
            });
        }

        [Benchmark(Baseline = true)]        
        public async Task WithTaskRunInside()
        {
            await Task.Run(() => CPUBoundWork());
        }

        public void CPUBoundWork()
        {
            for(var i = 0;i < 1000; i++)
            {
                Task.Delay(1000);
            }
        }
        
    }
}