using System;

namespace WaterPipes
{
	public sealed class ChangeState : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public ChangeState(Cursor cursor, Field field)
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
			CheckWaterPipe checkWiterPipe = new CheckWaterPipe(field, cursor);
			CheckChanges canChange = new CheckChanges(field, cursor);
			int offsetY = 0;
			int offsetX = 0;
			if (field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (canChange.CountSourceWater() != 1)
				{
					field[cursor.Y, cursor.X].State = CellState.EmptyPipe;
				}
				else if (canChange.CountConnection() == 1)
				{
					field[cursor.Y, cursor.X].State = CellState.Space;
				}
			}
			else if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe || field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (canChange.CountConnection() <= 2)
				{
					if (canChange.CanChange())
					{
						field[cursor.Y, cursor.X].StateChange();
					}
				}
				else if (checkWiterPipe.Check(offsetY, offsetX))
				{
					if (canChange.CanChange())
					{
						field[cursor.Y, cursor.X].StateChange();
					}
				}
			}
			else if (canChange.CountConnection() > 0)
			{
				field[cursor.Y, cursor.X].StateChange();
			}
		}
	}
}