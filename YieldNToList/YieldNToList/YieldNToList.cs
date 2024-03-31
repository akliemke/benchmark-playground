using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldNToList
{
    [MemoryDiagnoser]
    public class YieldNToList
    {
        [Benchmark]
        public int SumWithToList()
        {
            var sum = GetYield(1000).ToList().Sum();
            return sum;
        }

        [Benchmark]
        public int SumWithoutToList()
        {
            var sum = GetYield(1000).Sum();
            return sum;
        }

        [Benchmark]
        public int SumWithToListSlow()
        {
            var sum = GetYieldSlow(1000).ToList().Sum();
            return sum;
        }

        [Benchmark]
        public int SumWithoutToListSlow()
        {
            var sum = GetYieldSlow(1000).Sum();
            return sum;
        }

        public IEnumerable<int> GetYieldSlow(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(1000);
                yield return i;
            }
        }

        public IEnumerable<int> GetYield(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }
    }
}
