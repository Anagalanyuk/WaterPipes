using System;

namespace WaterPipes
{
	public sealed class BorderField
	{
		private char border;
		private int height = 2;
		private int offSet = 1;
		private int widht = 1;


		public BorderField(int height, int widht, char border)
		{
			this.border = border;
			this.height += height;
			this.widht += widht;
		}

		public void Show()
		{
			for (int topBottonBorder = 0; topBottonBorder <= widht; ++topBottonBorder)
			{
				Console.SetCursorPosition(topBottonBorder, offSet);
				Console.Write(border);
				Console.SetCursorPosition(topBottonBorder, height);
				Console.Write(border);
			}
			for (int leftRightBorder = 1; leftRightBorder <= height; ++leftRightBorder)
			{
				Console.SetCursorPosition(0, leftRightBorder);
				Console.Write(border);
				Console.SetCursorPosition(widht, leftRightBorder);
				Console.Write(border);
			}
		}
	}
}