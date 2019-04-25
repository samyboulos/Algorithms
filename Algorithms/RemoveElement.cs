using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class RemoveElement: IAlgorithm
    {
        public void Run()
        {
            var x = Do(new int[] { 2,0,1,3,2,1,3 }, 2);
        }

        public int Do(int[] nums, int removedVal)
        {
            int size = nums.Length;
            int x = 0;

            while (x < size)
            {
                if (nums[x] == removedVal)
                {
                    //Copy last element in the array and reduce the size
                    nums[x] = nums[size - 1];
                    size--; 
                }
                else
                    x++;  //Proceed

            }

            return x;
        }
    }
}
