using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Adder : IAlgorithm
    {
        int baseCalc =2;

        public void Run()
        {
            string result = Add("11", "1");
        }


        private string Add(string op1, string op2)
        {
            int maxLength = op1.Length > op2.Length ? op1.Length : op2.Length;

            op1 = new String(op1.Reverse().ToArray());
            op2 = new String(op2.Reverse().ToArray());

            int carryOver = 0;
            StringBuilder result = new StringBuilder();

            for (int x = 0; x < maxLength; x++)
            {
                int op1Int = (op1.Length <= x) ? 0 : int.Parse(op1[x].ToString());
                int op2Int = (op2.Length <= x) ? 0 : int.Parse(op2[x].ToString());

                var sum = op1Int + op2Int + carryOver;
                var column = sum % baseCalc;
                carryOver = sum / baseCalc;
                result.Insert(0, column);
            }

            if (carryOver != 0) result.Insert(0, carryOver);
            return result.ToString(); 
        }

    }
}
