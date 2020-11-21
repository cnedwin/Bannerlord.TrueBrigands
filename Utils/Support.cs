using System;
using TaleWorlds.Core;

namespace TrueBrigands
{
	public static class Support
	{
		public static Settings settings;

		public static Random random = new Random();

		public static int Random(int min = 0, int max = 1)
		{
			if (min > max)
			{
				int num = max;
				max = min;
				min = num;
			}
			return random.Next(min * 100, max * 100) / 100;
		}

		public static void LogMessage(string message)
		{
			InformationManager.DisplayMessage(new InformationMessage(message));
		}
	}
}
