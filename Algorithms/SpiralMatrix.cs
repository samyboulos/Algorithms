using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SpiralMatrix: Algorithm
    {
        public void Run()
        {
            //int[,] input = new int[,] { { 1, 2, 3},
            //                            { 4, 5, 6},
            //                            { 7, 8, 9}};


            //int[,] input = new int[,] { { 1, 2, 3},
            //                            { 4, 5, 6}};

            int[,] input = new int[,] { { 6,9,7}};

            var result = SpiralOrder(input);
        }


        public IList<int> SpiralOrder(int[,] matrix)
        {
            IList<int> result = new List<int>();

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int l= m < n ? m : n; // min (m,n)

            int layers = l / 2 + l % 2; // Ceiling (l/2)

            for (int layer = 0; layer < layers; layer++)
            {
                if (layer == n / 2 && n==m) //We are at the center
                {
                    result.Add(matrix[layer, layer]);
                    break;
                }

                int farRow = n - 1 - layer;
                int farCol = m - 1 - layer;


                //Top (row = layer)
                for (int col = layer; col < farCol; col++)
                {
                    result.Add(matrix[layer, col]);
                }
                //right (col = farCol)
                for (int row = layer; row < farRow; row++)
                {
                    result.Add(matrix[row, farCol]);
                }
                //bottom (row = farRow)
                for (int col = farCol; col > layer; col--)
                {
                    result.Add(matrix[farRow, col]);
                }
                //Left (col = layer)
                for (int row = farRow; row > layer; row--)
                {
                    result.Add(matrix[row, layer]);
                }
            }


            return result;
        }

    }
}
