
using System.Collections.Generic;

namespace Algorithms
{
    public class Substrings : IAlgorithm
    {

        public void Run()
        {
            var result = GetSubstrings("ABCD");
        }

        /// <summary>
        /// We have two pointers p1, p2
        /// And we move p2 from A all the way to the end (D) and then increment p1
        /// A B C D
        /// ^
        /// ^-----^
        /// Output: A, AB, ABC, ABCD
        /// 
        /// A B C D
        ///   ^
        ///   ^---^
        /// Output B, BC, BCD  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        IList<string> GetSubstrings(string input)
        {
            IList<string> result = new List<string>();
            for (int p1 = 0; p1 < input.Length; p1++)
            {
                for (int p2 = p1; p2 < input.Length; p2++)
                {
                    result.Add(input.Substring(p1, p2 - p1 + 1));
                }
            }

            return result;
        }
    }
}
