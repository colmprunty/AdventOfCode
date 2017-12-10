<Query Kind="Program" />

void Main()
{
	var list = Enumerable.Range(0,256).ToArray();
	var text = "76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229";
	//var text = "";
	var newText = new List<int>();
	foreach(var t in text){
		newText.Add(Convert.ToInt32(t));
	}
	var additional = new int[]{17, 31, 73, 47, 23};
	foreach (var a in additional)
	{
		newText.Add(a);
	}
	var skipSize = 0;
	var currentPosition = 0;
	var currentRevPosition = 0;

	for (int i = 0; i < 64; i++)
	{
		foreach (var length in newText)
		{
			var startPoint = currentPosition;
			var currentLength = Convert.ToInt32(length);
			var listLength = list.Length;
			// get all the numbers to be reversed
			var allToReverse = new List<int>();
			while (allToReverse.Count < currentLength)
			{
				allToReverse.Add(list[currentPosition]);
				//			if(allToReverse.Count == currentLength)
				//				break;

				currentPosition++;

				if (currentPosition >= listLength)
					currentPosition = 0;
			}


			for (int v = 0; v < skipSize; v++)
			{
				if (currentPosition == listLength - 1)
					currentPosition = 0;
				else
					currentPosition++;
			}
			skipSize++;
			// reverse them
			allToReverse.Reverse();

			// dole them back out to the list
			currentRevPosition = startPoint;
			for (int s = 0; s < allToReverse.Count; s++)
			{

				if (currentRevPosition >= listLength)
					currentRevPosition = 0;

				list[currentRevPosition] = allToReverse[s];
				currentRevPosition++;
			}
		}
	}
	var listCount = 0;
	var sum = 0;
	var denseList = new int[16];
	var denseCount = 0;
	for (int i = 0; i < list.Length+1; i++)
	{
		if (listCount != 0 && listCount % 16 == 0)
		{
			denseList[denseCount] = sum;
			denseCount++;
			sum = 0;
			
			if(i == list.Length)
				break;
		}
		
		var n = list[i];
		sum = (sum ^ n);
		listCount++;
	}
	
	var hexString = "";
	foreach(var d in denseList){
	var b = d.ToString("X").ToLower();		
		if(b.Length == 1)
			b = "0" + b;
		
		hexString += b;
	}
	
	hexString.Dump();
}

