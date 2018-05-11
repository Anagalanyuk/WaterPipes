using System;

namespace WaterPipes
{
	public sealed class Cursor
	{
		private char cursor = 'X';
		int cursorX;
		int cursorY;

		public int X
		{
			get { return cursorX; }
			set { cursorX = value; }
		}

		public int Y
		{
			get { return cursorY; }
			set { cursorY = value; }
		}

		public void Show()
		{
			int offSetX = 1;
			int offSetY = 2;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(cursorX + offSetX, cursorY + offSetY);
			Console.Write(cursor);
			Console.ResetColor();
		}
	}
}