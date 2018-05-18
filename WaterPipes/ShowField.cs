using System;

namespace WaterPipes
{
	public sealed class ShowField
	{
		private Field field;

		public ShowField(Field item)
		{
			field = item;
		}

		public void Show()
		{
			char emptyPipe = '0';
			char filedPipe = '0';
			int offSetRight = 1;
			int offSetDown = 2;
			char sourceWater = 'S';
			char space = ' ';
			for (int rows = 0; rows < field.Rows; ++rows)
			{
				for (int columns = 0; columns < field.Columns; ++columns)
				{
					if (field[rows, columns].State == CellState.Space)
					{
						Console.SetCursorPosition(offSetRight + columns, offSetDown + rows);
						Console.Write(space);
					}
					else if (field[rows, columns].State == CellState.EmptyPipe)
					{
						Console.SetCursorPosition(offSetRight + columns, offSetDown + rows);
						Console.Write(emptyPipe);
					}
					else if (field[rows, columns].State == CellState.SourceWater)
					{
						Console.SetCursorPosition(offSetRight + columns, offSetDown + rows);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(sourceWater);
						Console.ResetColor();
					}
					else if (field[rows, columns].State == CellState.FieldPipe)
					{
						Console.SetCursorPosition(offSetRight + columns, offSetDown + rows);
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write(filedPipe);
						Console.ResetColor();
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}