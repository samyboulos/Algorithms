namespace Algorithms
{
    public class BinarySearch: IAlgorithm
    {
        public void Run()
        {
            int[] input = new[] { 1, 3, 4, 6, 8, 12, 14, 22, 33, 34, 45, 55 };
            int result7 = Do(input, 7);
            int result8 = Do(input, 8);

            int result7Recur = DoRecursive(input, 0, input.Length, 7);
            int result8Recur = DoRecursive(input, 0, input.Length, 8);
        }

        public int Do(int[] input, int value)
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

        public int DoRecursive(int[] input, int start, int end, int value)
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
                return DoRecursive(input, start, median - 1, value);
            }
            else
            {
                return DoRecursive(input, median + 1, end, value);
            }
        }
    }
}