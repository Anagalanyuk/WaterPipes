namespace WaterPipes
{
	public sealed class CheckChanges
	{
		private int countSourceWater;
		private Cursor cursor;
		private Field field;
		private int numberConnections;
		private bool isSource = true;
		private bool source = true;

		public CheckChanges(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public bool CanChange()
		{
			if (field[cursor.Y, cursor.X].State != CellState.SourceWater)
			{
				source = false;
			}
			field[cursor.Y, cursor.X].State = CellState.Space;
			// right
			if (isSource && cursor.X + 1 < field.Rows - 1)
			{
				cursor.X += 1;
				if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
					field[cursor.Y, cursor.X].State == CellState.SourceWater)
				{
					isSource = SearchSource();
				}
				cursor.X -= 1;
			}
			// up
			if (isSource && cursor.Y - 1 >= 0)
			{
				cursor.Y -= 1;
				if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
					field[cursor.Y, cursor.X].State == CellState.SourceWater)
				{
					isSource = SearchSource();
				}
				cursor.Y += 1;
			}
			// left
			if (isSource && cursor.X - 1 > 0)
			{
				cursor.X -= 1;
				if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
					field[cursor.Y, cursor.X].State == CellState.SourceWater)
				{
					isSource = SearchSource();
				}
				cursor.X += 1;
			}
			// down
			if (isSource && cursor.Y + 1 < field.Rows - 1)
			{
				cursor.Y += 1;
				if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
					field[cursor.Y, cursor.X].State == CellState.SourceWater)
				{
					isSource = SearchSource();
				}
				cursor.Y -= 1;
			}
			if (source)
			{
				field[cursor.Y, cursor.X].State = CellState.SourceWater;
			}
			else
			{
				field[cursor.Y, cursor.X].State = CellState.EmptyPipe;
			}
			return isSource;
		}

		public int CountConnection()
		{
			if (cursor.Y > 0)
			{
				if (field[cursor.Y - 1, cursor.X].State == CellState.EmptyPipe || field[cursor.Y - 1, cursor.X].State == CellState.SourceWater)
				{
					numberConnections += 1;
				}
			}
			if (cursor.X > 0)
			{
				if (field[cursor.Y, cursor.X - 1].State == CellState.EmptyPipe || field[cursor.Y, cursor.X - 1].State == CellState.SourceWater)
				{
					numberConnections += 1;
				}
			}
			if (cursor.Y < field.Rows - 1)
			{
				if (field[cursor.Y + 1, cursor.X].State == CellState.EmptyPipe || field[cursor.Y + 1, cursor.X].State == CellState.SourceWater)
				{
					numberConnections += 1;
				}
			}
			if (cursor.X < field.Columns - 1)
			{
				if (field[cursor.Y, cursor.X + 1].State == CellState.EmptyPipe || field[cursor.Y, cursor.X + 1].State == CellState.SourceWater)
				{
					numberConnections += 1;
				}
			}
			return numberConnections;
		}

		public int CountSourceWater()
		{
			for (int rows = 0; rows < field.Rows; ++rows)
			{
				for (int columns = 0; columns < field.Columns; ++columns)
				{
					if (field[rows, columns].State == CellState.SourceWater)
					{
						countSourceWater += 1;
					}
				}
			}
			return countSourceWater;
		}

		public bool SearchSource()
		{
			CheckWaterPipe isSource = new CheckWaterPipe(field, cursor);
			return isSource.Check(0, 0);
		}
	}
}