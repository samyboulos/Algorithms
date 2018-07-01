using System;
using System.Collections.Generic;


namespace Algorithms
{
    class Permutations: IAlgorithm
    {
        public void Run()
        {
            foreach (var permutation in CoolPermutations("A,B,C,D".Split(',')))
            {
                string output = "";
                foreach (var element in permutation)
                {
                    output += element;
                }

                Console.WriteLine(output);
            }
        }


        /// <summary>
        /// We build up the solution starting with the first element "A"
        /// Then we add each element in the input to all the permutations in the growing permutationBuildUp
        /// Adding the element in each location of for each existing permutation
        /// The permutationBuildUp grows as such
        /// "A"
        /// "AB", "BA"
        /// "CAB", "ACB", ABC"
        /// "DCAB", "CDAB", CADB","CABD".......
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<List<string>> CoolPermutations(string[] input)
        {
            var permutationsBuildUp = new List<List<string>>();
            var solution = new List<List<string>>();
            int n = input.Length;

            //Buid up the solution starting with the the first element A
            permutationsBuildUp.Add(new List<string> { input[0] });

            //add each element in the input to each element in the intermediate set, once in every position 
            for (int x= 1; x < n ;x++)
            {
                string newLetter = input[x];

                foreach (var existingPermutation in permutationsBuildUp.ToArray())
                {
                    //insert the character in each position for each existing permutation 
                    for (int z = 0; z < existingPermutation.ToArray().Length + 1; z++)
                    {
                        List<string> newPermutation = new List<string>(existingPermutation);
                        newPermutation.Insert(z, newLetter);
                        permutationsBuildUp.Add(newPermutation);
                        if (newPermutation.Count == input.Length)
                        {
                            solution.Add(newPermutation);
                        }
                    }
                    
                }
            }

            return solution;
        }


        /// <summary>
        /// This is the recursive solution to the same problem
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<string> GetPermutationsRecursive(string s)
        {
            List<string> list = new List<string>();
            if (s.Length == 1)
            {
                list.Add(s);
                return list;
            }

            for (int x = 0; x < s.Length; x++)
            {
                foreach (var permutation in GetPermutationsRecursive(s.Remove(x, 1)))
                {
                    list.Add(s.Substring(x, 1) + permutation);
                }
            }

            return list;
        }
    }
}
