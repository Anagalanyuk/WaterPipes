namespace WaterPipes
{
	public class CheckWaterPipe
	{
		private Cell[,] clone;
		private Cursor cursor;
		private Field field;
		private bool isSource = false;

		public CheckWaterPipe(Field field, Cursor cursor)
		{
			clone = new Cell[field.Rows, field.Columns];
			for (int i = 0; i < field.Rows; ++i)
			{
				for (int j = 0; j < field.Columns; ++j)
				{
					clone[i, j] = (Cell)field[i, j].Clone();
				}
			}
			this.cursor = cursor;
			this.field = field;
		}

		public bool SetisSource(bool item) => isSource = item;

		public bool Check(int offSetX, int offSetY)
		{
			//right
			if (!isSource)
			{
				if (clone[cursor.Y ,cursor.X].State == CellState.SourceWater ||
					offSetX + cursor.X < field.Columns - 1 &&
					clone[cursor.Y + offSetY, cursor.X + offSetX + 1].State != CellState.Space &&
					clone[cursor.Y + offSetY, cursor.X + offSetX + 1].State != CellState.FilledPipe)
				{
					if (clone[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater ||
						clone[cursor.Y + offSetY, cursor.X + offSetX + 1].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						clone[cursor.Y + offSetY, cursor.X + offSetX].State = CellState.FilledPipe;
						isSource = Check(offSetX + 1, offSetY);
					}
				}
			}
			//down
			if (!isSource)
			{
				if (clone[cursor.Y, cursor.X].State == CellState.SourceWater ||
					cursor.Y + offSetY < field.Rows - 1 &&
					clone[cursor.Y + offSetY + 1, cursor.X + offSetX].State != CellState.Space &&
					clone[cursor.Y + offSetY + 1, cursor.X + offSetX].State != CellState.FilledPipe)
				{
					if (clone[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater ||
						clone[cursor.Y + offSetY + 1, cursor.X + offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						clone[cursor.Y + offSetY, cursor.X + offSetX].State = CellState.FilledPipe;
						isSource = Check(offSetX, offSetY + 1);
					}
				}
			}
			//left
			if (!isSource)
			{
				if (clone[cursor.Y, cursor.X].State == CellState.SourceWater ||
					cursor.X + offSetX > 0 &&
					clone[cursor.Y + offSetY, cursor.X + offSetX - 1].State != CellState.Space &&
					clone[cursor.Y + offSetY, cursor.X + offSetX - 1].State != CellState.FilledPipe)
				{
					if (clone[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater ||
						clone[cursor.Y + offSetY, cursor.X + offSetX - 1].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						clone[cursor.Y + offSetY, cursor.X + offSetX].State = CellState.FilledPipe;
						isSource = Check(offSetX - 1, offSetY);
					}
				}
			}
			//up
			if (!isSource)
			{
				if (clone[cursor.Y, cursor.X].State == CellState.SourceWater ||
					cursor.Y + offSetY > 0 &&
					clone[cursor.Y + offSetY - 1, cursor.X + offSetX].State != CellState.Space &&
					clone[cursor.Y + offSetY - 1, cursor.X + offSetX].State != CellState.FilledPipe)
				{
					if (clone[cursor.Y + offSetY, cursor.X + offSetX].State == CellState.SourceWater ||
						clone[cursor.Y + offSetY - 1, cursor.X + offSetX].State == CellState.SourceWater)
					{
						isSource = true;
					}
					if (!isSource)
					{
						clone[cursor.Y + offSetY, cursor.X + offSetX].State = CellState.FilledPipe;
						isSource = Check(offSetX, offSetY - 1);

					}
				}
			}
			return isSource;
		}
	}
}