<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:/Code/aoc/aoc9.txt")[0].ToCharArray();	
	var groupsOpen = 0;
	var garbageOpen = false;
	var totalGroups = 0;
	var ignoreNext = false;
	var totalGroupScore = 0;
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
			garbageOpen = true;

		if (t == '>' && garbageOpen)
			garbageOpen = false;

		if (t == '}' && !garbageOpen)
		{
			totalGroups++;
			totalGroupScore += groupsOpen;
			groupsOpen--;
		}
	}
	totalGroupScore.Dump();
}
