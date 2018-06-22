
using System.Collections.Generic;

namespace Algorithms
{
    public class AllSubstrings : Algorithm
    {

        public void Run()
        {
            var result = GetSubstrings("ABCD");
        }

        IList<string> GetSubstrings(string input)
        {
            IList<string> result = new List<string>();
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = x; y < input.Length; y++)
                {
                    result.Add(input.Substring(x, y - x + 1));
                }
            }

            return result;
        }
    }
}
