namespace WaterPipes
{
	public class CheckWaterPipe
	{
		private Cursor cursor;
		private Field field;
		private bool isSource = false;
		private int rows;
		private int columns;

		public CheckWaterPipe(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
			rows = cursor.Y;
			columns = cursor.X;
		}

		public bool Check()
		{
			if (field[rows, columns].State != CellState.Space && columns < field.Columns - 1)
			{
				++columns;
				if (field[rows, columns].State == CellState.SourceWater)
				{
					isSource = true;
				}
				Check();
			}
			//if (!isSource)
			//{
			if (field[rows, columns].State != CellState.Space && rows < field.Rows - 1)
				{
					++rows;
					if (field[rows, columns].State == CellState.EmptyPipe)
					{
						isSource = true;
					}
					Check();
				}
			//}

			return isSource;
		}
	}
}
