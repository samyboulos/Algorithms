using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RemoveDupFromSortedArray : IAlgorithm
    {
         
        public void Run()
        {
            int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int value = Do(input);
        }

        private int Do(int[] input)
        {
            if (input == null || input.Length == 0)
                return 0;

            int slow = 0;

            for (int fast = 1; fast < input.Length; fast++)
            {                
                if (input[slow] != input[fast])
                {
                    slow++;
                    input[slow] = input[fast];
                }
            }

            return slow + 1;
        }

       

    }
}
