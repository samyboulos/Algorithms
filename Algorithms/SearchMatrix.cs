using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    ///The rules of this problem state that: 
    ///-Integers in each row are sorted from left to right.
    ///-The first integer of each row is greater than the last integer of the previous row.
    public class SearchMatrix:Algorithm
    {

        public void Run()
        {
            int[,] matrix = new int[,] {{1,3,5,7},
                                    {10,11,16,20},
                                    {23,30,34,50}};


            bool result = new SearchMatrix().DoSearchMatrix(matrix, 30);
        }


        public bool DoSearchMatrix(int[,] matrix, int target)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (height == 0 || width == 0 || matrix[0, 0] > target || matrix[height - 1, width - 1] < target)
                return false;

            if (matrix[0, 0] == target)
                return true;

            int row = height == 1 ? 0 : -1;
            //Try to find the row first
            for (int h = 0; h < height; h++)
            {
                if (matrix[height - 1, 0] < target)
                {
                    row = height - 1;
                    break;
                }

                if (h < height - 1 && matrix[h, 0] <= target && matrix[h + 1, 0] > target)
                {
                    row = h;
                    break;
                }
                if (matrix[h + 1, 0] == target)
                {
                    row = h + 1;
                    break;
                }
            }

            if (row == -1)
                return false;

            //now knowing the row we use binary search on the row
            int left = 0, right = width - 1;
            while (left <= right)
            {
                int median = (left + right) / 2;

                if (matrix[row, median] == target)
                    return true;
                // If x greater, ignore left half
                else if (matrix[row, median] < target)
                    left = median + 1;
                // If x is smaller, ignore right half
                else
                    right = median - 1;
            }

            return false;

        }
    }
}
