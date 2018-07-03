void Main()
{
	Compress(new char[] {'a','a','b','b','c','c','c'});
}



public int Compress(char[] chars)
{

	if (chars.Length == 0)
		return 0;

	if (chars.Length == 1)
		return 1;


	int write = 0;
	char previous = '0';
	int countCurrent = 0;
	int countPrev =0;

	for (int read = 0; read < chars.Length; read++)
	{
		char current = chars[read];
 		countCurrent++;
		
		if (chars[read] != previous || read== chars.Length-1) //Starting new char
		{
			//write count of previous
			if (countPrev > 1)
			{
				write += WriteCount(countPrev, write, chars);
				countPrev = 0;
			}
			chars[write] = current; //Write the new character
			write++; //advance one char
		}
		

		previous = current;

	}

	return 0;

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
