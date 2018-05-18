using System;

namespace WaterPipes
{
	internal class Program
	{
		internal static void Main()
		{
			Console.CursorVisible = false;
			Game game = new Game();
			game.PlayGame();
		}
	}
}