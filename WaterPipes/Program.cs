using System;

namespace WaterPipes
{
	public class Program
	{
		public static void Main()
		{
			Console.CursorVisible = false;
			Game game = new Game();
			game.PlayGame();
		}
	}
}