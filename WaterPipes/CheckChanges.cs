namespace WaterPipes
{
	public sealed class CheckChanges
	{
		private int countSourceWater;
		private Cursor cursor;
		private Field field;
		private int numberConnections;
		private bool isSource = false;

		public CheckChanges(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public bool CanChange()
		{
			int offsetX = 0;
			int offsetY = 0;
			CheckWaterPipe foo = new CheckWaterPipe(field, cursor);
			//up
			if (cursor.Y > 0)
			{
				if (field[cursor.Y - 1, cursor.X].State == CellState.EmptyPipe || field[cursor.Y - 1, cursor.X].State == CellState.SourceWater)
				{
					isSource = foo.Check(offsetX, offsetY);
				}
			}
			//left
			if (cursor.X > 0)
			{
				if (field[cursor.Y, cursor.X - 1].State == CellState.EmptyPipe || field[cursor.Y, cursor.X - 1].State == CellState.SourceWater)
				{
					isSource = foo.Check(offsetX, offsetY);
				}
			}
			//down
			if (cursor.Y < field.Columns - 1)
			{
				if (field[cursor.Y + 1, cursor.X].State == CellState.EmptyPipe || field[cursor.Y + 1, cursor.X].State == CellState.SourceWater)
				{
					isSource = foo.Check(offsetX, offsetY);

				}
			}
			//right
			if (cursor.X < field.Rows - 1)
			{
				if (field[cursor.Y, cursor.X + 1].State == CellState.EmptyPipe || field[cursor.Y, cursor.X + 1].State == CellState.SourceWater)
				{
					isSource = foo.Check(offsetX, offsetY);

				}
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
			if (cursor.Y < field.Columns - 1)
			{
				if (field[cursor.Y + 1, cursor.X].State == CellState.EmptyPipe || field[cursor.Y + 1, cursor.X].State == CellState.SourceWater)
				{
					numberConnections += 1;
				}
			}
			if (cursor.X < field.Rows - 1)
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