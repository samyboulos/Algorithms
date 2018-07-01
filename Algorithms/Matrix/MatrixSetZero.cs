using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MatrixSetZero: IAlgorithm
    {
        private int rows, columns;

        public void Run()
        {
            int[,] matrix = new int[,]
           { { 0, 1, 2, 0 },
              { 3, 4, 5, 2 },
              { 1, 3, 1, 5 }};



            SetZeroes(matrix);
        }

        /// <summary>
        /// We use the first row and first column in the matrix as a mask
        /// If we see that a cell has zero 
        /// we set the first digit in its row to zero as a marker that this entire row will be zeroed
        /// Similarly we set the first digit in the column to zero 
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[,] matrix)
        {
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);

            //Before we start we need to know if the first row and column originally had any zeros
            bool firstRowHasZero = IsFirstRowHasZero(matrix);
            bool firstColumnHasZero = IsFirstColumnHasZero(matrix);


            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        matrix[row, 0] = 0;
                        matrix[0, column] = 0;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, 0] == 0 && row != 0)
                    ZeroRow(matrix, row); //Zero row if it is not first row
            }

            for (int column = 0; column < columns; column++)
            {
                if (matrix[0, column] == 0 && column!=0)
                    ZeroColumn(matrix, column); //Zero column if it is not first column
            }

            if (firstColumnHasZero)
            {
                 ZeroColumn(matrix, 0);
            }

            if (firstRowHasZero)
            {
                ZeroRow(matrix, 0);
            }

        }

        private bool IsFirstRowHasZero(int[,] matrix)
        {
            for (int column = 0; column < columns; column++)
                if (matrix[0, column] == 0)
                    return true;

            return false;
        }

        private bool IsFirstColumnHasZero(int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
                if (matrix[row, 0] == 0)
                    return true;

            return false;
        }

        private void ZeroRow(int[,] matrix, int zrow)
        {
            for (int column = 1; column < columns; column++)
                matrix[zrow, column] = 0;
        }

        private void ZeroColumn(int[,] matrix, int zcolumn)
        {
            for (int row = 1; row < rows; row++)
                matrix[row, zcolumn] = 0;
        }
    }
}
