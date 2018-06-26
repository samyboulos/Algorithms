using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class PowerSet: Algorithm
    {
        public void Run()
        {
            foreach (var set in CoolPowerSet("A,B,C,D".Split(',')))
            {
                string output = "";
                foreach (var element in set)
                {
                    output += element;
                }

                Console.WriteLine(output);
            }
        }



        /// <summary>
        /// We build up the solution starting with the empty set {}
        /// Then we add each element in the input to all the subsets in the growing power set
        /// While preserving the subsets that were already created in the previous steps
        /// The powerset grows as such
        /// {}
        /// {}, {A}
        /// {}, {A}, {A,B}
        /// {}, {A}, {A,B}, {C}, {A,C}, {A,B,C}
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public List<List<string>> CoolPowerSet (string[] inputArray)
        {
            var originalSet = inputArray.ToList();
            var powerSet = new List<List<string>>();
            //Buid up the solution starting with the empty set {}
            powerSet.Add(new List<string>());

            //add each element in the origial set to each subset in the powerset, 
            //preserving a copy of each element that already existed in the powerset
            foreach (string element in originalSet)
            {
                foreach (var subset in powerSet.ToArray())
                {
                    var newSubset = new List<string>(subset);
                    newSubset.Add(element);
                    powerSet.Add(newSubset);
                }
            }

            return powerSet;
        }

    }
}
