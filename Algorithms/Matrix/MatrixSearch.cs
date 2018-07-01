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
    public class MatrixSearch:IAlgorithm
    {

        public void Run()
        {
            int[,] matrix = new int[,] {{1,3,5,7},
                                    {10,11,16,20},
                                    {23,30,34,50}};


            bool result = new MatrixSearch().DoSearchMatrix(matrix, 30);
        }


        public bool DoSearchMatrix(int[,] matrix, int target)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows == 0 || columns == 0 || matrix[0, 0] > target || matrix[rows - 1, columns - 1] < target)
                return false;

            if (matrix[0, 0] == target)
                return true;

            int row = rows == 1 ? 0 : -1;
            //Try to find the row first
            for (int h = 0; h < rows; h++)
            {
                if (matrix[rows - 1, 0] < target)
                {
                    row = rows - 1;
                    break;
                }

                if (h < rows - 1 && matrix[h, 0] <= target && matrix[h + 1, 0] > target)
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
            int start = 0, end = columns - 1;
            while (start <= end)
            {
                int median = (start + end) / 2;

                if (matrix[row, median] == target)
                    return true;
                // If x greater, ignore left half
                else if (matrix[row, median] < target)
                    start = median + 1;
                // If x is smaller, ignore right half
                else
                    end = median - 1;
            }

            return false;

        }
    }
}
