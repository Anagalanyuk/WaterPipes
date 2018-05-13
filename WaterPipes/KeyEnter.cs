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

		public void Action()
		{
			CheckChanges check = new CheckChanges(field, cursor);
			if (field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (check.CountSourceWater() != 1)
				{
					field[cursor.Y, cursor.X].State = CellState.EmptyPipe;
				}
			}
			else if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe || field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (check.Check() == 1)
				{
					field[cursor.Y, cursor.X].StateChange();
				}
			}
			else if (check.Check() > 0)
			{
				field[cursor.Y, cursor.X].StateChange();
			}
		}
	}
}