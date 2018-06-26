using System;
using System.Collections.Generic;


namespace Algorithms
{
    class Permutations: Algorithm
    {
        public void Run()
        {
            foreach (var permutation in GetPermutations("A,B,C,D".Split(',')))
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
        public List<List<string>> GetPermutations(string[] input)
        {
            var permutationsBuildUp = new List<List<string>>();

            string s = input[0];
            //Buid up the solution starting with the the first element A
            List<string> firstPermutation = new List<string>();
            firstPermutation.Add(input[0]);
            permutationsBuildUp.Add(firstPermutation);

            //add each element in the input to each element in the intermediate set, once in every position 
            for (int x= 1; x<input.Length;x++)
            {
                string letterToInsert = input[x];

                //Take a snapshot of the count as the set keeps growing
                int countSnapshot1 = permutationsBuildUp.Count;

                for (int y = 0; y < countSnapshot1; y++)
                {
                    var existingPermutation = permutationsBuildUp[y];

                    var countSnapshot2 = existingPermutation.Count + 1;
                    //insert the character in each position for each existing permutation 
                    for (int z = 0; z < countSnapshot2; z++)
                    {
                        List<string> newPermutation = new List<string>(existingPermutation);
                        newPermutation.Insert(z, letterToInsert);
                        permutationsBuildUp.Add(newPermutation);
                    }
                    
                }
            }

            //Here wer filter the permutations whose length =4 
            //We could have avoided this loop by keeping a separate list for the final solution
            var solution = new List<List<string>>();
            foreach (var permutation in permutationsBuildUp)
            {
                if (permutation.Count == input.Length)
                {
                    solution.Add(permutation);
                }
            }

            return solution;
        }


        List<string> GetPermutationsRecursive(string s)
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
