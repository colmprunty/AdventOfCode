<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:\\Code\\aoc\\aoc13.txt");
	var firewalls = new List<Tuple<int,int>>();
	foreach (var l in text)
	{
		var index = l.Substring(0, l.IndexOf(':'));
		var depth = l.Substring(l.IndexOf(' ')+1,l.Length - (l.IndexOf(' ')+1));
		firewalls.Add(new Tuple<int,int>(Convert.ToInt32(index), Convert.ToInt32(depth)));		
	}
	
	var total = 0;
	var endState = firewalls.Max(x => x.Item1);
	for (int i = 0; i <= endState; i++)
	{
		// my state is i
		var fw = firewalls.SingleOrDefault(x => x.Item1 == i);
		if(fw == null)
			continue;
			
		var depth = fw.Item2;
		var n = (depth*2)-2;
				
		if(i%n==0)
			total += (i*depth);
	}
	
	total.Dump();
}