<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:\\Code\\aoc\\aoc13.txt");
	var firewalls = new List<Tuple<int, int>>();
	foreach (var l in text)
	{
		var index = l.Substring(0, l.IndexOf(':'));
		var depth = l.Substring(l.IndexOf(' ') + 1, l.Length - (l.IndexOf(' ') + 1));
		firewalls.Add(new Tuple<int, int>(Convert.ToInt32(index), Convert.ToInt32(depth)));
	}

	var endState = firewalls.Max(x => x.Item1);
	
	var count = 0;
	while (true)
	{
		var total = 0;
		// go through each firewall
		for (int i = 0; i <= endState; i++)
		{
			// get the firewall
			var fw = firewalls.SingleOrDefault(x => x.Item1 == i);
			if (fw == null)
				continue;

			var depth = fw.Item2;
			var n = (depth * 2) - 2;

			// check its state at the position
			if ((i + count) % n == 0){
				total += ((i + count) * depth);
				if(total>0)
					break;
			}
				
		}

		if (total == 0)
		{
			count.Dump();
			break;
		}
		
		count++;

	}
}