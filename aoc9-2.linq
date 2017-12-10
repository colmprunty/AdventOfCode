<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:/Code/aoc/aoc9.txt")[0].ToCharArray();	
	var groupsOpen = 0;
	var garbageOpen = false;	
	var ignoreNext = false;
	var totalGarbageScore = 0;
	foreach (var t in text)
	{
		if(ignoreNext){
			ignoreNext = false;
			continue;
		}
		
		if (t == '!')
			ignoreNext = true;

		if (t == '{' && !garbageOpen)
			groupsOpen++;

		if (t == '<' && !garbageOpen)
		{
			garbageOpen = true;
			continue;
		}

		if (t == '>' && garbageOpen)
			garbageOpen = false;
			
		if(garbageOpen && t != '>' && !ignoreNext)
			totalGarbageScore++;

		if (t == '}' && !garbageOpen)
			groupsOpen--;
		
	}
	totalGarbageScore.Dump();
}
