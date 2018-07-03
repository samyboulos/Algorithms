public int Compress(char[] chars)
{
 
 if (chars.Length==0)
 
 return 0;
 
 if (chars.Length==1)
 
 return 1;
 

 int write =0;
 char previous = '0';
 int countSeen =0;
 int totalCount= 0;
 
	for (int read = 0; read < chars.Length; read ++)
	{
		char current= chars[read];

		if (chars[read] != previous) //Starting new char
		{
			if (countSeen > 1)
			{
                write += WriteCount(countSeen, write, chars);
				countSeen =0;
			}
			else 
			{
				countSeen++;
			}

			chars[write] = current;//Write the character
			write++; //advance only one char
		}
        else  //repeated char
		{
			countSeen ++;
		}
		
		previous= current;
		
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
