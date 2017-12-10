<Query Kind="Program" />

void Main()
{
	var list = Enumerable.Range(0,256).ToArray();
	var text = new int[]{76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229};
	//var list = new int[]{0, 1, 2, 3, 4};
	//var text = new int[]{3, 4, 1, 5};
	var skipSize = 0;
	var currentPosition = 0;
	var currentRevPosition = 0;
	foreach(var length in text){
		var startPoint = currentPosition;
		var currentLength = Convert.ToInt32(length);
		var listLength = list.Length;
		// get all the numbers to be reversed
		var allToReverse = new List<int>();
		 while(allToReverse.Count < currentLength)
		{		
			allToReverse.Add(list[currentPosition]);
//			if(allToReverse.Count == currentLength)
//				break;
			
			currentPosition++;
			
			if(currentPosition>=listLength)
				currentPosition = 0;
		}
		
		
		for(int v = 0; v<skipSize;v++){
			if(currentPosition == listLength-1)
				currentPosition = 0;
			else
				currentPosition++;
		}
		skipSize++;
		// reverse them
		allToReverse.Reverse();
		
		// dole them back out to the list
		currentRevPosition = startPoint;
		for(int s=0; s<allToReverse.Count; s++){
			
			if(currentRevPosition >= listLength)
				currentRevPosition = 0;
			
			list[currentRevPosition] = allToReverse[s];
			currentRevPosition++;
		}
	}
	
	list.Dump();
	skipSize.Dump();
	currentPosition.Dump();
}