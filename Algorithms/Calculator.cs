using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Adder : Algorithm
    {
        int baseCalc =2;

        public void Run()
        {
            string result = Add("101011001", "1111");
            Console.WriteLine(result);
        }


        private string Add(string op1, string op2)
        {
            int maxLength = op1.Length > op2.Length ? op1.Length : op2.Length;
            op1= op1.PadLeft(maxLength, '0');
            op2= op2.PadLeft(maxLength, '0');

            var op1Array = op1.Reverse().ToArray();
            var op2Array = op2.Reverse().ToArray();
            int carryOver = 0;
            StringBuilder result = new StringBuilder();

            for (int x = 0; x < maxLength; x++)
            {
                var sum = int.Parse(op1Array[x].ToString()) + int.Parse(op2Array[x].ToString()) + carryOver;
                var column = sum % baseCalc;
                carryOver = sum / baseCalc;
                result.Insert(0, column);
            }

            if (carryOver != 0) result.Insert(0, carryOver);
            return result.ToString(); ;
        }

    }
}
