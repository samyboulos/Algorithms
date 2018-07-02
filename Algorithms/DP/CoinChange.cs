using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class CoinChange : IAlgorithm
    {

        public void Run()
        {
            var result = Do(new int[] { 1, 2, 5 }, 11); //3
        }


        public int Do(int[] coins, int amount)
        {

            int[] mins = new int[amount + 1];
            mins[0] = 0;

            for (int size = 1; size < amount + 1; size++)
            {
                mins[size] = int.MaxValue; //This means we no number of coins yet match size
                for (int coin = 0; coin < coins.Length; coin++)
                {
                    int remainder = size - coins[coin];
                    if (remainder >= 0 && (mins[remainder] != int.MaxValue))
                    {
                        int numCoins = 1 + mins[remainder];
                        mins[size] = mins[size] < numCoins ? mins[size] : numCoins;
                    }
                }
            }

            //If no match for amount
            if (mins[amount] == int.MaxValue)
                return -1;
            else
                return mins[amount];

        }
    }
}
