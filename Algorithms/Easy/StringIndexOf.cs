using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class StringIndexOf : IAlgorithm
    {
        public void Run()
        {
            var result = Do("Hello", "lo");
        }

        private int Do(string haystack, string needle)
        {
            if (haystack == needle || needle.Length == 0)
                return 0;

            for (int x = 0; x < haystack.Length - needle.Length + 1; x++)
            {
                bool breakInnerLoop = false;
                //Compare haystack.Substring(x, needle.Length) with needle char by char (optimization over using Substring())
                for (int y = 0; y < needle.Length && !breakInnerLoop; y++) 
                {
                    if (haystack[x + y] != needle[y])
                    {
                        breakInnerLoop = true;
                    }
                    else if (y == needle.Length - 1) //If we reached the end then substring == needle
                    {
                        return x;
                    }
                }
            }

            return -1;
        }

    }
}
