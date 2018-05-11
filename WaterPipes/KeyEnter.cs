using System;

namespace WaterPipes
{
	public sealed class KeyEnter : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public KeyEnter(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.Enter;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			if (field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				field[cursor.Y, cursor.X].State = CellState.Space;
			}
			else
			{
				field[cursor.Y, cursor.X].StateChange();
			}
		}
	}
}