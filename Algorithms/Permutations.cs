using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms
{
    class Permutations : Algorithm
    {

        string s = "ABCD";

        public void Run()
        {
            foreach (var permutation in GetPermutations(s))
                Console.WriteLine(permutation);
        }

        List<string> GetPermutations(string s)
        {
            List<string> list = new List<string>();
            if (s.Length == 1)
            {
                list.Add(s);
                return list;
            }

            for (int x= 0; x < s.Length ; x++)
            {
                foreach (var permutation in GetPermutations(s.Remove(x, 1)))
                {
                    list.Add(s.Substring(x, 1) + permutation);
                }
            }

            return list;
        }
    }
}
