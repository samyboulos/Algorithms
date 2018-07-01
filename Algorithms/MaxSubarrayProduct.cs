using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MaxSubarrayProduct : IAlgorithm
    {

        public void Run()
        {

            int result = MaxProductBF(new int[] { 2, -5, -2, -4, 3 });

            int result2 = MaxProductDP(new int[] { 2, -5, -2, -4, 3 });
        }


        


        private int Max(int i1, int i2)
        {
            return i1 > i2 ? i1 : i2;
        }

        private int Min(int i1, int i2)
        {
            return i1 > i2 ? i2 : i1;
        }


        /// <summary>
        /// This is the Dynamic Programming solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProductDP(int[] nums)
        {

            int max = nums[0];
            int currentMax = nums[0];
            int currentMin = nums[0];

            for (int x = 1; x < nums.Length; x++)
            {
                int currentVal = nums[x];

                if (currentVal > 0)
                {
                    currentMax = Max(currentVal, currentVal * currentMax);
                    currentMin = Min(currentVal, currentVal * currentMin);

                }
                else
                {
                    int temp = currentMax;
                    currentMax = Max(currentVal, currentVal * currentMin);
                    currentMin = Min(currentVal, currentVal * temp);
                }

                max = Max(max, currentMax);

            }

            return max;


        }
        

        /// <summary>
        /// This is the Brute Force solution I created
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public int MaxProductBF (int[] nums)
        {
            int max = int.MinValue;

            for (int p1 = 0; p1 < nums.Length; p1++)
            {
                int current = nums[p1];
                max = Max(max, current);

                for (int p2 = p1+1; p2 < nums.Length; p2++)
                {
                    current *= nums[p2];
                    max = Max(max, current);
                }
            }

            return max;
        }


    }
}
