<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:/Code/aoc/aoc19.txt");
	var theGrid = new List<char[]>();
	var cx = 0;
	var steps = 0;
	var first = false;
	var letters = "";
	foreach (var l in text)
	{
		if(!first){
			cx = l.IndexOf('|');
			first = true;
		}
		
		theGrid.Add(l.ToCharArray());
	}
	
	var cy = 0;
	var direction = "D";
	
	while(true){
		if(direction == "D"){
			steps++;
			Down(ref theGrid, ref cx, ref cy, ref direction, ref letters);
		}

		if (direction == "U"){
			steps++;
			Up(ref theGrid, ref cx, ref cy, ref direction, ref letters);
		}
		
		if (direction == "L"){
			steps++;
			Left(ref theGrid, ref cx, ref cy, ref direction, ref letters);
		}
		
		if (direction == "R"){
			steps++;
			Right(ref theGrid, ref cx, ref cy, ref direction, ref letters);
		}
		
		if(letters.Contains(" "))
			break;			
	}	
	
	letters.Dump();
	steps.Dump();
}

public void Left(ref List<char[]> theGrid, ref int cx, ref int cy, ref string direction, ref string letters)
{
	cx--;
	var nextSquare = (theGrid[cy])[cx];

	if (nextSquare == '|' || nextSquare == '-')
		direction = "L";

	else if (nextSquare == '+')
		direction = GetNextDirection(ref theGrid, ref cx, ref cy, "R");
		
	else letters += nextSquare;
}

public void Right(ref List<char[]> theGrid, ref int cx, ref int cy, ref string direction, ref string letters)
{
	cx++;
	var nextSquare = (theGrid[cy])[cx];

	if (nextSquare == '|' || nextSquare == '-')
		direction = "R";

	else if (nextSquare == '+')
		direction = GetNextDirection(ref theGrid, ref cx, ref cy, "L");
		
	else letters += nextSquare;
}

public void Up(ref List<char[]> theGrid, ref int cx, ref int cy, ref string direction, ref string letters)
{
	cy--;
	var nextSquare = (theGrid[cy])[cx];

	if (nextSquare == '|' || nextSquare == '-')
		direction = "U";

	else if (nextSquare == '+')
		direction = GetNextDirection(ref theGrid, ref cx, ref cy, "D");
		
	else letters += nextSquare;
}

public void Down(ref List<char[]> theGrid, ref int cx, ref int cy, ref string direction, ref string letters){
	cy++;
	var nextSquare = (theGrid[cy])[cx];
	
	if(nextSquare == '|' || nextSquare == '-')
		direction = "D";
		
	else if(nextSquare == '+')
		direction = GetNextDirection(ref theGrid, ref cx, ref cy, "U");
		
	else letters += nextSquare;
}

public string GetNextDirection(ref List<char[]> theGrid, ref int cx, ref int cy, string except){
	var u = except == "U" ? ' ' : (theGrid[cy-1])[cx];
	if(u != ' ')
		return "U";

	var d = except == "D" ? ' ' : (theGrid[cy+1])[cx];
	if (d != ' ')
		return "D";

	var l = except == "L" ? ' ' : (theGrid[cy])[cx-1];
	if (l != ' ')
		return "L";

	var r = except == "R" ? ' ' : (theGrid[cy])[cx+1];
	if (r != ' ')
		return "R";

	return "?";
}