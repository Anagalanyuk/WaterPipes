using System;

namespace WaterPipes
{
	public sealed class StepLeft : IKey
	{
		private Cursor cursor;
		private Field field;
		ConsoleKey key;

		public StepLeft(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.A;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			if (cursor.X > 0)
			{
				cursor.X -= 1;
			}
		}
	}
}