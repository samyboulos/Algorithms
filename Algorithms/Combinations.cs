using System;
using System.Collections.Generic;



namespace Algorithms
{
    /// <summary>
    /// Gets all 3 element subset sets out of a set
    /// </summary>
    class Combinations: Algorithm
    {
        public void Run()
        {
            foreach (string set in GetCombinations("A,B,C,D,E,F,G".Split(',')))
            {
                Console.WriteLine(set);
            }
        }

        public string[] GetCombinations (string[] input)
        {
            List<string> results = new List<string>();
            /*
             we start by three pointers i,j,k at the first three elements
            A B C D E F G
            i j k
            so the first element is ABC
            then we advance k one letter at a time, get the set pointed to by ijk 
            move k all the way to the end (G) then advance j to C
            when j reaches F,  advance i to B
            the algorithm ends with this position
             A B C D E F G
                     i j k
            and so the last elelmet in EFG 

             */

            for (int i = 0; i < input.Length - 2; i++)
            {
                for (int j = i + 1; j < input.Length - 1; j++)
                {
                    for (int k = j + 1; k < input.Length; k++)
                    {
                        results.Add($"{input[i]},{input[j]},{input[k]}");

                    }
                }
                    
            }
                

            return results.ToArray();
        }
    }
}
