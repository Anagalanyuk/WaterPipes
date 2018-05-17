namespace WaterPipes
{
	public sealed class Field
	{
		private int columns = 30;
		private Cell[,] field;
		private int rows = 15;

		public Field()
		{
			field = new Cell[rows, columns];
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < columns; ++j)
				{
					field[i, j] = new Cell();
				}
			}
		}

		public Cell this[int rows, int columns]
		{
			get { return field[rows, columns]; }
			set { field[rows, columns] = value; }
		}

		public int Columns
		{
			get { return columns; }
		}

		public int Rows
		{
			get { return rows; }
		}
	}
}