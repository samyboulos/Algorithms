using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ThreeSum: Algorithm
    {

        public void Run()
        {

            foreach (List<int> solution in GetThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }))
            {
                Console.WriteLine($"{solution [0]} ,{solution[1]}, {solution[2]}" );
            }
        }

        private IList<IList<int>> GetThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            result.Add(new List<int>(new int[] { nums[i], nums[j], nums[k] }));
                            break;
                        }
                    }
                }
            }

            result = result.Where((x, i) => !result.Skip(i + 1).Any(s => s.SequenceEqual(x))).ToList<IList<int>>();

            return result;


        }
    }
}
