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
			CheckChanges checkChange = new CheckChanges(field, cursor);
			CheckWaterPipe checkWiterPipe = new CheckWaterPipe(field, cursor);
			if (field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (checkChange.CountSourceWater() != 1)
				{

					field[cursor.Y, cursor.X].State = CellState.EmptyPipe;
				}
				else
				{
					if(checkChange.Check() == 1)
					{
						field[cursor.Y, cursor.X].State = CellState.Space;
					}
				}
			}
			else if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe || field[cursor.Y, cursor.X].State == CellState.SourceWater)
			{
				if (checkChange.Check() <= 2)
				{
					field[cursor.Y, cursor.X].StateChange();
				}
				else if(checkWiterPipe.Check())
				{
					field[cursor.Y, cursor.X].StateChange();
				}
			}
			else if (checkChange.Check() > 0)
			{
				field[cursor.Y, cursor.X].StateChange();
			}
		}
	}
}