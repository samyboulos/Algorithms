using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MatrixRotation: Algorithm
    {

        public void Run()
        {
            int[,] matrix = new int[,] {{1,3,5,7},
                                    {10,11,16,20},
                                    {23,30,34,50},
                                    {9,12,17,22}};
            Rotate(matrix);
            Print(matrix);
        }

        private void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int layers = (int)Math.Ceiling((double)n / 2);

            for (int layer = 0; layer < layers; layer++)
            {
                Queue<int> buffer1 = new Queue<int>();
                Queue<int> buffer2 = new Queue<int>();
                for (int topx = layer; topx < n - layer; topx++)
                {
                    buffer1.Enqueue(matrix[layer, topx]);
                }
                for (int righty = layer; righty < n - layer; righty++)
                {
                    buffer2.Enqueue(matrix[righty, n - layer - 1]);
                    matrix[righty, n - layer - 1] = buffer1.Dequeue();
                }
                for (int bottomx = n- layer-1; bottomx >= layer; bottomx--)
                {
                    buffer1.Enqueue(matrix[n - layer - 1, bottomx]);
                    matrix[n - layer - 1, bottomx] = buffer2.Dequeue();
                }
                for (int lefty = n - layer - 1; lefty >= layer; lefty--)
                {
                    buffer2.Enqueue(matrix[lefty, layer]);
                    matrix[lefty, layer] = buffer1.Dequeue();
                }
                for (int topx = layer; topx < n - layer; topx++)
                {
                    matrix[layer, topx] = buffer2.Dequeue(); ;
                }
            }
        }
        private void Print (int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int layers = (int)Math.Ceiling((double)n / 2);

            for (int layer = 0; layer < layers; layer++)
            {

                for (int topx = layer; topx < n - layer; topx++)
                {
                    Console.WriteLine(matrix[layer, topx]);
                }
                for (int righty = layer; righty < n - layer; righty++)
                {

                    Console.WriteLine(matrix[righty, n - layer - 1]);
                }
                for (int bottomx = n - layer - 1; bottomx >= layer; bottomx--)
                {
                    Console.WriteLine(matrix[n - layer - 1, bottomx]);
                }
                for (int lefty = n - layer - 1; lefty >= layer; lefty--)
                {
                    Console.WriteLine(matrix[lefty, layer]);
                }
            }
        }

    }
}
