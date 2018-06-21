namespace Algorithms
{
    public class BinarySearch
    {
        public int DoBinarySearch(int[] input, int value)
        {
            int start = 0;
            int end = input.Length - 1;

            while (start <= end)
            {
                int median = (start + end) / 2;

                if (input[median] == value)
                {
                    return median;
                }
                else if (input[median] > value)
                {
                    end = median - 1;
                }
                else
                {
                    start = median + 1;
                }
            }

            return -1;

        }
    }
}