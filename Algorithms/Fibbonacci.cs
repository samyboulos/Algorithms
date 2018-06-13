using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Fibbonacci:Algorithm
    {
        Dictionary<int, long> cache = new Dictionary<int, long>();

        public void Run()
        {
            GetFibDynamic(20);
        }

        public Fibbonacci()
        {
            cache.Add(0, 0);
            cache.Add(1, 1);
        }

        public long GetFibCache(int n)
        {

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            long fib= GetFibCache(n - 1) + GetFibCache(n - 2);
            cache.Add(n, fib);
            return fib;
        }


        public long GetFibDynamic(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long fibnm1 = 1;
            long fibnm2 = 0;
            long newValue=-1;

            for (int x = 2; x < n+1; x++)
            {
                newValue = fibnm1 + fibnm2;
                fibnm2 = fibnm1;
                fibnm1 = newValue;
            }

            return newValue;
        }
    }
}
