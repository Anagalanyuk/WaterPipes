using System;

namespace WaterPipes
{
	public sealed class StepRight : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public StepRight(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.D;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			if (cursor.X < field.Columns - 1)
			{
				cursor.X += 1;
			}
		}
	}
}