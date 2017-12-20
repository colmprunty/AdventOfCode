<Query Kind="Program" />

void Main()
{
	var text = File.ReadAllLines("C:/Code/aoc/aoc20.txt");
	var positions = new List<Box>();
	var velocities = new List<Box>();
	var accelerations = new List<Box>();
	
	var ic = 0;
	foreach (var line in text)
	{
		
		var bits = line.Split(',');
		var p1 = Convert.ToInt32(bits[0].Substring(bits[0].IndexOf('<') +1));
		var p2 = Convert.ToInt32(bits[1]);
		var p3 = Convert.ToInt32(bits[2].Substring(0, bits[2].IndexOf('>')));

		var v1 = Convert.ToInt32(bits[3].Substring(bits[3].IndexOf('<') + 1));
		var v2 = Convert.ToInt32(bits[4]);
		var v3 = Convert.ToInt32(bits[5].Substring(0, bits[5].IndexOf('>')));

		var a1 = Convert.ToInt32(bits[6].Substring(bits[6].IndexOf('<') + 1));
		var a2 = Convert.ToInt32(bits[7]);
		var a3 = Convert.ToInt32(bits[8].Substring(0, bits[8].IndexOf('>')));
		
		positions.Add(new Box{
			x = p1, y = p2, z = p3, index = ic
		});
		
		velocities.Add(new Box{
			x = v1, y = v2, z = v3, index = ic
		});
		
		accelerations.Add(new Box{
			x = a1, y = a2, z = a3, index = ic
		});
		
		ic++;
	}

	for (int j = 0; j < 1000; j++)
	{
		var dupes = new List<int>();
		var vals = new List<Tuple<int,int>>();
		for (int i = 0; i < positions.Count; i++)
		{			
			var p = positions[i % positions.Count];
			var v = velocities[i % positions.Count];
			var a = accelerations[i % positions.Count];

			v.x += a.x;
			v.y += a.y;
			v.z += a.z;

			p.x += v.x;
			p.y += v.y;
			p.z += v.z;
			
			var dps = positions.Where(x => x.x == p.x && x.y == p.y && x.z == p.z);
			if (dps.Count() > 1)
			{
				dupes.AddRange(dps.Select(c => c.index));					
			}
		}
			var list = dupes.Distinct();
			foreach (var d in list)
			{
				var p = positions.Single(x => x.index == d);
				positions.Remove(p);

				var v = velocities.Single(x => x.index == d);
				 velocities.Remove(v);

				var a = accelerations.Single(x => x.index == d);
				accelerations.Remove(a);
			}
	}
	
	positions.Count.Dump();
}
public class Box
{
	public int index {get;set;}
	public int x { get; set; }
	public int y { get; set; }
	public int z { get; set; }
	public int closestCount {get;set;}
}