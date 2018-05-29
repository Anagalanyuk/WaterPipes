namespace WaterPipes
{
	public sealed class CheckChanges
	{
		private int countSourceWater;
		private Cursor cursor;
		private Field field;
		private int numberConnections;
		private bool isSource = true;

		public CheckChanges(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public bool CanChange()
		{
			field[cursor.Y, cursor.X].State = CellState.Space;
			int offSetX = 0;
			int offSetY = 0;
			CheckWaterPipe sourceSearch = new CheckWaterPipe(field, cursor);
			//right
			if (isSource && cursor.X < field.Rows - 1)
			{
				cursor.X += 1;
				if (cursor.X < field.Rows - 1)
				{
					if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
						field[cursor.Y, cursor.X].State == CellState.SourceWater)
					{
						isSource = sourceSearch.Check(offSetX, offSetY);
					}
				}
				cursor.X -= 1;
			}
			////up
			sourceSearch.SetisSource(false);
			if (isSource && cursor.Y > 0)
			{
				cursor.Y -= 1;
				if (cursor.Y >= 0)
				{
					if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
						field[cursor.Y, cursor.X].State == CellState.SourceWater)
					{
						isSource = sourceSearch.Check(offSetX, offSetY);
					}
				}
				cursor.Y += 1;
			}
			////left
			sourceSearch.SetisSource(false);
			if (isSource && cursor.X > 0)
			{
				cursor.X -= 1;
				if (cursor.X > 0)
				{
					if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
						field[cursor.Y, cursor.X].State == CellState.SourceWater)
					{
						isSource = sourceSearch.Check(offSetX, offSetY);
					}
				}
				cursor.X += 1;
			}
			////down
			sourceSearch.SetisSource(false);
			if (isSource)
			{
				if (cursor.Y < field.Rows - 1)
				{
					cursor.Y += 1;
					if (field[cursor.Y, cursor.X].State == CellState.EmptyPipe ||
						field[cursor.Y, cursor.X].State == CellState.SourceWater)
					{
						isSource = sourceSearch.Check(offSetX, offSetY);
					}
					cursor.Y -= 1;
				}
			}
			field[cursor.Y, cursor.X].State = CellState.EmptyPipe;
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
	}
}