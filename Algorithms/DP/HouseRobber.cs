using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class HouseRobber: IAlgorithm
    {

        public void Run()
        {
            int result = RobCircularDP(new int[] { 1, 2, 3, 1 });
        }


        //This is the solution where houses are in a circle. It uses the linear solution
        public int RobCircularDP(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            //We first assume the first house does not exist (its value =0) and find max
            int firstHouseValueTemp = nums[0];
            nums[0] = 0;
            int max0 = RobLinearDP(nums);

            nums[0] = firstHouseValueTemp;

            //Now do the same for last house
            nums[nums.Length - 1] = 0;
            int maxn = RobLinearDP(nums);

            return max0 > maxn ? max0 : maxn;

        }


        //This is a simple DP solution where build up the solution bottom up.
        //Each house we decide whether we want to take it or no. If we take it we will have to leave the previous 
        //so we take the running sum without it. 
        public int RobLinearDP(int[] nums)
        {

            if (nums == null || nums.Length == 0)
                return 0;


            int prevWithout = 0;
            int prevWith = nums[0];
            int max = nums[0];

            for (int house = 1; house < nums.Length; house++)
            {
                int currentWith = nums[house] + prevWithout;

                int currentWithout = prevWith > prevWithout ? prevWith : prevWithout;
                int currentMax = currentWith > currentWithout ? currentWith : currentWithout;
                max = max > currentMax ? max : currentMax;
                prevWithout = currentWithout;
                prevWith = currentWith;
            }


            return max;
        }


    }
}
