using System;

namespace WaterPipes
{
	class Program
	{
		static void Main()
		{
			Console.CursorVisible = false;
			Game game = new Game();
			game.PlayGame();
		}
	}
}