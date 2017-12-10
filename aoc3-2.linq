<Query Kind="Program" />

public class CoVal
{
	public int x;
	public int y;
	public int value;
}

public int sumOfNeighbours(CoVal current, List<CoVal> all)
{
	var a = all.SingleOrDefault(x => x.x == current.x && x.y == (current.y - 1))?.value;
	var b = all.SingleOrDefault(x => x.x == current.x && x.y == (current.y + 1))?.value;
	var c = all.SingleOrDefault(x => x.y == current.y && x.x == (current.x - 1))?.value;
	var d = all.SingleOrDefault(x => x.y == current.y && x.x == (current.x + 1))?.value;

	var e = all.SingleOrDefault(x => x.x == current.x - 1 && x.y == (current.y + 1))?.value;
	var f = all.SingleOrDefault(x => x.x == current.x + 1 && x.y == (current.y + 1))?.value;
	var g = all.SingleOrDefault(x => x.x == current.x - 1 && x.y == (current.y - 1))?.value;
	var h = all.SingleOrDefault(x => x.x == current.x + 1 && x.y == (current.y - 1))?.value;

	return (a ?? 0) + 
		   (b ?? 0) + 
		   (c ?? 0) + 
		   (d ?? 0) + 
		   (e ?? 0) + 
		   (f ?? 0) + 
		   (g ?? 0) + 
		   (h ?? 0);
}

void Main()
{
	var endSpace = 368078;
	var result = 0;
	var visited = new List<CoVal>{
					new CoVal{ x=0, y=0, value=1}
				};
	
	// how far have we gone?
	var sum = 1;
	// start at the origin
	var x = 0;
	var y = 0;
	
	// move one space at the beginning
	var n = 1;
	var keepGoing = true;
	while(keepGoing){
		keepGoing = ruld(ref x,ref y,ref n, ref sum, ref visited, endSpace, ref result);
	}
	
	result.Dump();
}

private bool checkIfFinished(int endspace, int nextValue){
	if(nextValue > endspace)
		return true;
		
	return false;
}

private int remainingDistance(int endSpace, int distance){
	return endSpace - distance;
}

private bool ruld(ref int x, ref int y, ref int n, ref int count, ref List<CoVal> visited, int endspace, ref int result)
{
	//right
	for(int i = 0; i<n;i++){
		x++;
		var newOne = new CoVal{ x=x, y=y };
		var sum = sumOfNeighbours(newOne, visited);
		if(sum > endspace){
			result = sum;
			return false;
		}
		newOne.value = sum;
		count += sum;
		visited.Add(newOne);
	}	

	//up
	for (int i = 0; i < n; i++)
	{
		y++;
		var newOne = new CoVal { x = x, y = y };
		var sum = sumOfNeighbours(newOne, visited);
		if (sum > endspace)
		{
			result = sum;
			return false;
		}
		newOne.value = sum;
		count += sum;
		visited.Add(newOne);
	}
	
	// now increase n
	n++;

	//left	
	for (int i = 0; i < n; i++)
	{
		x--;
		var newOne = new CoVal { x = x, y = y };
		var sum = sumOfNeighbours(newOne, visited);
		if (sum > endspace)
		{
			result = sum;
			return false;
		}
		newOne.value = sum;
		count += sum;
		visited.Add(newOne);
	}

	//down
	for (int i = 0; i < n; i++)
	{
		y--;
		var newOne = new CoVal { x = x, y = y };
		var sum = sumOfNeighbours(newOne, visited);
		if (sum > endspace)
		{
			result = sum;
			return false;
		}
		newOne.value = sum;
		count += sum;
		visited.Add(newOne);
	}


	n++;
	
	return true;
}