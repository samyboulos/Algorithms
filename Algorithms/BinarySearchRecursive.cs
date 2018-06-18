using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BinarySearch:Algorithm
    {

        public void Run()
        {
            int[] input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int x = DoBinarySearch(input, 0, input.Length-1, 5);
        }


        public int DoBinarySearch(int[] input, int start, int end, int value)
        {

            if (start == end)
            {
                return input[start] == value ? start : -1;
            }

            int median = (start + end) / 2;
          

            if (input[median] == value)
            {
                return median;
            }
            else if (input[median] > value)
            {
                return DoBinarySearch(input, start, median - 1, value);
            }
            else
            {
                return DoBinarySearch(input, median+1, end, value);
            }
        }

    }
}
