using System;

namespace WaterPipes
{
	public sealed class StepDown : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public StepDown(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.X;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			if (cursor.Y < field.Rows - 1)
			{
				cursor.Y += 1;
			}
		}
	}
}