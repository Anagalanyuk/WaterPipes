namespace WaterPipes
{
	public sealed class CheckChanges
	{
		private int countSourceWater;
		private Cursor cursor;
		private Field field;
		private int numberConnections;

		public CheckChanges(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public int Check()
		{
			for (int i = cursor.Y - 1; i <= cursor.Y + 1; ++i)
			{
				for (int j = cursor.X - 1; j <= cursor.X + 1; ++j)
				{
					if (i >= 0 && i <= field.Rows - 1 && j >= 0 && j <= field.Columns - 1)
					{
						if (field[i, j].State == CellState.EmptyPipe || field[i, j].State == CellState.SourceWater)
						{
							numberConnections += 1;
						}
					}
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