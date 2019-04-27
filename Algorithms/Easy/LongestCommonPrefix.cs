using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class LongestCommonPrefix : IAlgorithm
    {
        public void Run()
        {
            var result = Do(new string[] { "Great", "Greet", "Greece", "Grease" });
        }

        public string Do(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            return strs[0].Substring(0, longestIndex(strs));
        }

        private int longestIndex(string[] strs)
        {
            if (strs[0].Length == 0)
                return 0;

            for (int column = 0; column < strs[0].Length; column++)
            {
                for (int x = 1; x < strs.Length; x++)
                {
                    if (strs[x].Length <= column || strs[0][column] != strs[x][column])
                        return column;
                }
            }

            return strs[0].Length;
        }
    }
}
