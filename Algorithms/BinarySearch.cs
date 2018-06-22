namespace Algorithms
{
    public class BinarySearch: Algorithm
    {
        public void Run()
        {
            int[] input = new[] { 1, 3, 4, 6, 8, 12, 14, 22, 33, 34, 45, 55 };
            int result7 = DoBinarySearch(input, 7);
            int result8 = DoBinarySearch(input, 8);

            int result7Recur = DoBinarySearchRecursive(input, 0, input.Length, 7);
            int result8Recur = DoBinarySearchRecursive(input, 0, input.Length, 8);
        }

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

        public int DoBinarySearchRecursive(int[] input, int start, int end, int value)
        {

            if (start == end)
            {
                return input[start] == value ? start : -1;
            }

            int median = (start + end) / 2;


            if (input[median] == value)
            {
                return median;
            }
            else if (input[median] > value)
            {
                return DoBinarySearchRecursive(input, start, median - 1, value);
            }
            else
            {
                return DoBinarySearchRecursive(input, median + 1, end, value);
            }
        }
    }
}