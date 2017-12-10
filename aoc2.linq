<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:/Code/aoc/aoc2.txt");
	var totalDifference = 0;
	foreach(var line in text){
		var numList = new List<int>();
		var numbers = line.Split('\t');
		foreach(var number in numbers){
			numList.Add(Convert.ToInt32(number.ToString()));			
		}
		
		var max = numList.Max();
		var min = numList.Min();
		totalDifference+=(max-min);
	}
	totalDifference.Dump();
}
