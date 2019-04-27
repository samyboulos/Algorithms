using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SearchInsertPosition : IAlgorithm
    {
        public void Run()
        {
            var result = Do(new int[] { 1, 3, 5, 6 }, 5);
        }

        public int Do (int[] nums, int target)
        {
            for (int x = 0; x < nums.Length; x++)
            {
                if (nums[x] == target || nums[x] > target)
                    return x;
            }

            return nums.Length;
        }
    }
}
