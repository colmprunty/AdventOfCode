<Query Kind="Program" />

void Main()
{
	var programs = "abcdefghijklmnop".ToCharArray();
	var text = File.ReadAllLines("C:\\Code\\aoc\\aoc16.txt");
	var count = 1;
	while (count < 41)
	{
		foreach (var instruction in text[0].Split(','))
		{
			if (instruction.StartsWith("s"))
			{
				var number = instruction.Substring(1, instruction.Length - 1);
				Spin(Convert.ToInt32(number), ref programs);
			}

			if (instruction.StartsWith("x"))
			{
				var x = instruction.Substring(1, instruction.IndexOf('/') - 1);
				var y = instruction.Substring(instruction.IndexOf('/') + 1);
				Exchange(Convert.ToInt32(x), Convert.ToInt32(y), ref programs);
			}

			if (instruction.StartsWith("p"))
			{
				var x = instruction.Substring(1, instruction.IndexOf('/') - 1);
				var y = instruction.Substring(instruction.IndexOf('/') + 1);
				Partner(x, y, ref programs);
			}
		}
		
		if(new string(programs) == "abcdefghijklmnop"){
			count.Dump();
			break;
		}
		
		count++;		
	}
	
	programs.Dump();
}

private void Partner(string x, string y, ref char[] programs){
	var positionOfX = Array.IndexOf(programs, x.ToCharArray()[0]);
	var positionOfY = Array.IndexOf(programs, y.ToCharArray()[0]);
	programs[positionOfX] = y.ToCharArray()[0];
	programs[positionOfY] = x.ToCharArray()[0];
}

private void Exchange(int x, int y, ref char[] programs){
	var toBeAtY = programs[x];
	var toBeAtX = programs[y];
	programs[x] = toBeAtX;
	programs[y] = toBeAtY;
}

private void Spin(int number, ref char[] programs){
	var newArrayPosition =0;
	var newArray = new char[programs.Length];
	for(int i=programs.Length-number; i<programs.Length; i++){
		newArray[newArrayPosition] = programs[i];
		newArrayPosition++;
	}
	
	for(int i = 0; i<programs.Length-number; i++){
		newArray[newArrayPosition] = programs[i];
		newArrayPosition++;
	}
	
	programs = newArray;
}

// Define other methods and classes here
