using System;

namespace WaterPipes
{
	public sealed class Moves
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public Moves(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move(ConsoleKey key)
		{
			this.key = key;
			if (key == ConsoleKey.RightArrow && cursor.X < field.Columns - 1)
			{
				cursor.X += 1;
			}
			else if (key == ConsoleKey.LeftArrow && cursor.X > 0)
			{
				cursor.X -= 1;
			}
			else if (key == ConsoleKey.UpArrow && cursor.Y > 0)
			{
				cursor.Y -= 1;
			}
			else if (key == ConsoleKey.DownArrow && cursor.Y < field.Rows - 1)
			{
				cursor.Y += 1;
			}
		}
	}
}