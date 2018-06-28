namespace Algorithms
{
public class ClimbStairs : Algorithm
{
    public void Run()
    {
       int result = ClimbStairsDP(14);    
    }



    /// <summary>
    /// This solution used Dynamic Programming
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int ClimbStairsDP(int n)
	{
		if (n == 1) return 1;

		int[] steps = new int[n + 1];
		steps[0] = 0;
		steps[1] = 1;
		steps[2] = 2;

		for (int x = 3; x < n + 1; x++)
		{
			steps[x] = steps[x - 1] + steps[x - 2];
		}

		return steps[n];
	}
}
}
