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

            int result = MaxProductBF(new int[] { 2, -5, -2, -4, 3});
        }


        public int MaxProduct(int[] nums)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This is the Brute Force solution
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

        private int Max(int i1, int i2)
        {
            return i1 > i2 ? i1 : i2;
        }

        private int Abs(int i)
        {
            if (i == 0) return 0;

            return i > 0 ? i : -1 * i;
        }

        private int MaxAbs(int i1, int i2)
        {
            return Abs(i1) > Abs(i2) ? i1 : i2;
        }

    }
}
