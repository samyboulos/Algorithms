﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class CoolPhoneNumberToLetters: Algorithm
    {
        private string[] table = new string[] { "", "", "a,b,c", "d,e,f", "g,h,i", "j,k,l", "m,n,o", "p,q,r,s", "t,u,v", "w,x,y,z" };

        public void Run()
        {
            var result = LetterCombinations("23");
        }

        /// <summary>
        /// Solving an example for "23"
        /// Build up the solution as such
        /// start with the three letters that correspond to the first digit
        /// {a},{b},{c}
        /// for each letter break it up into its three corrsponding letters and add each letter to each element in the set
        /// So 
        /// {ad},{ae},{af},{bd},{bd},{bf},{cd},{ce},{cf}
        /// ..and so on..
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>

        public IList<string> LetterCombinations(string digits)
        {
            List<string> intermediates = new List<string>();

            if (digits.Length == 0)
                return intermediates;

            intermediates.AddRange(table[Int32.Parse(digits[0].ToString())].Split(',').ToList());

            for (int x = 1; x < digits.Length; x++)
            {
                var newLetters = table[Int32.Parse(digits[x].ToString())].Split(',');
                List<string> intermediates2 = new List<string>();

                foreach (var letter in newLetters)
                {
                    foreach (var element in intermediates)
                    {
                        intermediates2.Add(element + letter);
                    }
                }

                intermediates = intermediates2;
            }

            return intermediates;
        }

    }
}
