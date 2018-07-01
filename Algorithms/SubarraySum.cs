using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// I solved a variant of this problem on leetcode with slightly different rules
    /// Where the criteria is that sum = multiples of target and min subarray length is 2 
    /// </summary>
    public class SubarraySum: IAlgorithm
    {

        public void Run()
        {
            int[] input = new[] { 23, 2, 4, 6, 7 };
            int target = 6;
            bool result = SubArraySum(input, target);

        }

        /// <summary>
        /// We use two pointers p1, p2 same like with getting all substrings
        /// We keep advancing p2 and calculate running sum. If p2 reaches the end advance p1 and start summing again
        /// At any point if running sum is equal to target return true.
        /// Optimization: Assuming all elements are positive, if we already have exceed target no need to proceed
        /// just advance p1 for the next iteration
        /// {2, 0, 1, 4, 6, 8}
        ///  ^
        ///     ^-----------^
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SubArraySum(int[] input, int target)
        {
            int n = input.Length;
            int p1 = 0;
            int p2 = p1;
            int sum = 0;

            while (p2 < n)
            {
                sum += input[p2];

                if (sum == target)
                {
                    return true;
                }
                else if (sum > target || p2==n-1)
                {
                    sum = 0;
                    p1++;
                    p2 = p1;
                }
                else
                {
                    p2++;
                }
            }

            return false;

        }

    }
}
