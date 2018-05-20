namespace WaterPipes
{
	public class CheckWaterPipe
	{
		private Cursor cursor;
		private Field field;
		private bool isSource = false;

		public CheckWaterPipe(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public bool Check(int offSetX, int offSetY)
		{
			//right
			if (!isSource)
			{
				if (offSetX + cursor.X < field.Columns - 1 && field[cursor.Y + offSetY, cursor.X + offSetX].State != CellState.Space)
				{
					if (field[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						isSource = Check(offSetX + 1, offSetY);
					}
				}
			}
			//down
			if (!isSource)
			{
				if (cursor.Y + offSetY < field.Rows - 1 && field[cursor.Y + offSetY, cursor.X + offSetX].State != CellState.Space)
				{
					if (field[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						isSource = Check(offSetX, offSetY + 1);
					}
				}
			}
			//left
			if (!isSource)
			{
				if (cursor.X - offSetX > 0 && field[cursor.Y + offSetY, cursor.X - offSetX].State != CellState.Space)
				{
					if (field[cursor.Y + offSetY, cursor.X - offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						isSource = Check(offSetX + 1, offSetY);
					}
				}
			}
			//up
			if (!isSource)
			{
				if (cursor.Y - offSetY > 0 && field[cursor.Y - offSetY, cursor.X + offSetX].State != CellState.Space)
				{
					if (field[cursor.Y - offSetY, cursor.X + offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						isSource = Check(offSetX, offSetY + 1);
					}
				}
			}
			return isSource;
		}
	}
}