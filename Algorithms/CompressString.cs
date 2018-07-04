

namespace Algorithms
{
    public class CompressString : IAlgorithm
    {

        public void Run()
        {
            Run(new char[] { 'a','b', 'b', 'b', 'b', 'b' ,'b', 'b', 'b', 'b', 'b', 'b', 'b' });
        }

        public int Run (char[] chars)
        {

            if (chars.Length == 0)
                return 0;

            if (chars.Length == 1)
                return 1;

            int write = 0;
            int count = 0;
          
            for (int read = 0; read < chars.Length; read++)
            {
                char current = chars[read];

                char next = (read == chars.Length - 1) ? '0' : chars[read + 1]; // for last iteration set next = '0'
                count++;

                if (chars[read] != next) //Last item in current char
                {
                    chars[write++] = current; //Write the character
                    if (count > 1)
                    {
                        write += WriteCount(count, write, chars); //Write the count
                    }

                    count = 0;
                }

            }

            return write;

        }

        int WriteCount(int countSeen, int write, char[] chars)
        {
            //Write the count
            char[] countChars = countSeen.ToString().ToCharArray();
            for (int c2 = 0; c2 < countChars.Length; c2++)
            {
                chars[write + c2] = countChars[c2];
            }
            return countChars.Length; // 
        }
    }
}
