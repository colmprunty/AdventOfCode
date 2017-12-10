<Query Kind="Program" />

void Main()
{
	var endSpace = 368078;	
	
	// how far have we gone?
	var count = 1;
	// start at the origin
	var x = 0;
	var y = 0;
	
	// move one space at the beginning
	var n = 1;
	var keepGoing = true;
	while(keepGoing){
		keepGoing = ruld(ref x,ref y,ref n, ref count, endSpace);
	}
	
	x.Dump();
	y.Dump();
}

private bool checkIfFinished(int endspace, int nextValue){
	if(nextValue > endspace)
		return true;
		
	return false;
}

private int remainingDistance(int endSpace, int distance){
	return endSpace - distance;
}

private bool ruld(ref int x, ref int y, ref int n, ref int count, int endspace)
{
	//right
	if (checkIfFinished(endspace, count + n))
	{
		x = x+remainingDistance(endspace, count);
		return false;
	}
	x = x+n;	
	count = count+n;
 
	//up	
	if (checkIfFinished(endspace, count + n))
	{
		y = y+remainingDistance(endspace, count);
		return false;
	}
		
	y = y + n;
	count = count+n;
	
	// now increase n
	n++;

	//left	
	if (checkIfFinished(endspace, count + n))
	{
		x = x-remainingDistance(endspace, count);
		return false;
	}
		
	x = x - n;
	count = count+n;

	//down
	if (checkIfFinished(endspace, count + n))
	{
		y = y-remainingDistance(endspace, count);
		return false;
	}
		
	y = y - n;
	count = count+n;
	
	n++;
	
	return true;
}