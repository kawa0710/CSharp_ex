//.Net 7 @ https://dotnetfiddle.net/
using System;
var morning = new Shift();
morning.SN = 1;
morning.Name = "早班";
morning.Start = new TimeSpan(8, 0, 0);
morning.End = new TimeSpan(17, 0, 0);

var night = new Shift();
night.SN = 2;
night.Name = "晚班";
night.Start = new TimeSpan(16, 0, 0);
night.End = new TimeSpan(1, 0, 0, 0);

var graveyard = new Shift();
graveyard.SN = 3;
graveyard.Name = "大夜班";
graveyard.Start = new TimeSpan(23, 0, 0);
graveyard.End = new TimeSpan(1, 7, 0, 0);

Console.WriteLine (morning.Name);
Console.WriteLine (morning.StartStr);
Console.WriteLine (morning.EndStr);

Console.WriteLine (night.Name);
Console.WriteLine (night.StartStr);
Console.WriteLine (night.EndStr);

Console.WriteLine (graveyard.Name);
Console.WriteLine (graveyard.StartStr);
Console.WriteLine (graveyard.EndStr);

class Shift
{
    public int SN { get; set; }
    public string Name { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
	
	public string StartStr
	{
		get => $"{Start.Hours:00}:{Start.Minutes:00}:{Start.Seconds:00}";
	}
	
	public string EndStr
	{
		get
		{
			var result = $"{End.Hours:00}:{End.Minutes:00}:{End.Seconds:00}";
			if (End.Days == 1)
			{
				if (End == new TimeSpan(1, 0, 0, 0))
					result = "24:00:00";
				else
					result = "隔日" + result;
			}
			else if (End.Days > 1)
				result = End.Days + "日後" + result;
			return result;
		}
	}
}
