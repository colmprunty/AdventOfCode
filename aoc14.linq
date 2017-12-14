<Query Kind="Expression" />

void Main()
{

	var baseText = "jzgqcdpd-";

	var totalBinary = "";

	for (int i = 0; i < 128; i++)
	{
		var list = Enumerable.Range(0, 256).ToArray();
		var skipSize = 0;
		var currentPosition = 0;
		var currentRevPosition = 0;
		var text = baseText + i;
		var newText = new List<int>();
		foreach (var l in text)
		{
			newText.Add(Convert.ToInt32(l));
		}
		var additional = new int[] { 17, 31, 73, 47, 23 };
		foreach (var a in additional)
		{
			newText.Add(a);
		}

		for (int l = 0; l < 64; l++)
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
		for (int j = 0; j < list.Length + 1; j++)
		{
			if (listCount != 0 && listCount % 16 == 0)
			{
				denseList[denseCount] = sum;
				denseCount++;
				sum = 0;

				if (j == list.Length)
					break;
			}

			var n = list[j];
			sum = (sum ^ n);
			listCount++;
		}

		var hexString = "";
		foreach (var d in denseList)
		{
			var b = d.ToString("X").ToLower();
			if (b.Length == 1)
				b = "0" + b;

			hexString += b;
		}


		string binarystring = String.Join(String.Empty, hexString.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
		//binarystring.Dump();
		totalBinary += binarystring;
	}

	totalBinary.ToCharArray().Where(x => x == '1').Count().Dump();

}