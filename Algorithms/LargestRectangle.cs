using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class LargestRectangle: Algorithm
    {

        public void Run()
        {
            int result = GetLargestDP(new int[] { 2, 1, 5, 6, 2, 3 });
        }

        
        
        /// <summary>
        /// This algorithm uses something close to Dynamic Programming.
        /// We need to calculate right and left bound of each elemenent but instead of iterating all the way
        /// Till we reach a smaller element, we save many steps by using the value we already calculated 
        /// for the previous element, knowing that if the previous element is larger than the current,
        /// its right or left bound also applies to the current element. After we make the jump we continue
        /// iteration as normal till we reach a smaller element then stop.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        private int GetLargestDP(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return 0;
            }

            int n = input.Length;
            int max = 0;

            //bounds are inclusive meaning they contain the last element 
            //that fits into the rectangle not the first element outside the rectangle
            //so that the bound of first element will be 0 not -1


            //start building leftBounds table
            int[] leftBoundsTable = new int[n];
            leftBoundsTable[0] = 0;
            
            for (int element = 1; element < n; element++)
            {
                int elementHeight = input[element];
                int currentBound = element-1;

                //keep going left
                while (currentBound >= 0 && input[currentBound] >= elementHeight)
                {
                    //jump to the element beyond the left bound of the element on the left
                    currentBound = leftBoundsTable[currentBound]-1;
                }

                //Here we either reach the start of the array or the first element that is shorter than our element
                leftBoundsTable[element] = currentBound+1;
            }

            int[] rightBoundsTable = new int[n];
            //start building rightBounds table
            rightBoundsTable[n-1] = n-1;

            for (int element = n-2; element >= 0; element--)
            {
                int elementHeight = input[element];
                int currentBound = element +1;

                //keep going right
                while (currentBound < n && input[currentBound] >= elementHeight)
                {
                    //jump to the element beyond the right bound of the element on the left
                    currentBound = rightBoundsTable[currentBound] + 1;
                }

                //Here we either reach the end of the array or the first element that is shorter than our element
                rightBoundsTable[element] = currentBound - 1;
            }

            for (int element = 0; element < n; element++)
            {
                int elementHeight = input[element];
                int area = elementHeight * (rightBoundsTable[element] - leftBoundsTable[element] + 1);
                max = max > area ? max : area;
            }

            return max;
        }

    }
}
