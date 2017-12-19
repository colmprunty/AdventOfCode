<Query Kind="Program" />

void Main()
{
	var locations = new List<int>{0};
	
	var current = 1;
	var result = 0;
	for (int j = 1; j < 50000001; j++)
	{
		current = ((current + 370) % j) + 1;
		
		if(current == 1)
			result = j;
	}
	
	result.Dump();
}