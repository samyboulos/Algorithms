using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class RecursivePhoneNumberToLetters : Algorithm
    {
        private string[] table = new string[] { "", "", "a,b,c", "d,e,f", "g,h,i", "j,k,l", "m,n,o", "p,q,r,s", "t,u,v", "w,x,y,z" };

        public void Run()
        {
            string input = "34";
            IList<string> result = LetterCombinations(input);
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();

            if (digits.Length == 1)
                return table[Int32.Parse(digits)].Split(',');

            int leftMostDigit = Int32.Parse(digits[0].ToString());
            string[] letters = table[leftMostDigit].Split(',');
            IList<string> result = new List<string>();

            foreach (string letter in letters)
            {
                int length = digits.Length;
                string remainingDigits = digits.Substring(1, length - 1);
                foreach (string s in LetterCombinations(remainingDigits))
                {
                    result.Add(letter + s);
                }
            }

            return result;
        }
    }
}
