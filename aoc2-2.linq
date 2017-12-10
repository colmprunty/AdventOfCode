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
		
		numList = numList.OrderBy(x => x).ToList();
		foreach(var num in numList){
			var found = false;
			var reverseList = numList.Except(new List<int>{num}).OrderByDescending(x => x).ToList();
			foreach(var num2 in reverseList){
				if(num2%num == 0){
					totalDifference += num2/num;
					found = true;
					break;
				}
				
				if(found)
					break;
			}
			if(found)
				break;
		}
	}
	totalDifference.Dump();
}
