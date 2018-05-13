﻿using System;

namespace WaterPipes
{
	public sealed class KeySpace
	{
		private Field field;
		private ShowField show;
		private CountStep step;

		public KeySpace(Field field, CountStep step)
		{
			this.field = field;
			this.show = new ShowField(field);
			this.step = step;
		}

		public void StartGame()
		{
			int sleep = 400;
			bool gameOver = false;
			int offSet = 1;
			int offSetCursor = 3;
			while (!gameOver)
			{
				for (int rows = 0; rows < field.Rows; ++rows)
				{
					for (int columns = 0; columns < field.Columns; ++columns)
					{
						if (field[rows, columns].State == CellState.FiledPipe || field[rows, columns].State == CellState.SourceWater)
						{
							if (rows > 0)
							{
								if (field[rows - offSet, columns].State == CellState.EmptyPipe)
								{
									field[rows - offSet, columns].State = CellState.FiledPipe;
								}
							}
							if (columns > 0)
							{
								if (field[rows, columns - offSet].State == CellState.EmptyPipe)
								{
									field[rows, columns - offSet].State = CellState.FiledPipe;
								}
							}
						}
					}
				}
				for (int rows = field.Rows - 1; rows >= 0; --rows)
				{
					for (int columns = field.Columns - 1; columns >= 0; --columns)
					{
						if (field[rows, columns].State == CellState.FiledPipe || field[rows, columns].State == CellState.SourceWater)
						{
							if (rows < field.Rows - 1)
							{
								if (field[rows + offSet, columns].State == CellState.EmptyPipe)
								{
									field[rows + offSet, columns].State = CellState.FiledPipe;
								}
							}
							if (columns < field.Columns - 1)
							{
								if (field[rows, columns + offSet].State == CellState.EmptyPipe)
								{
									field[rows, columns + offSet].State = CellState.FiledPipe;
								}
							}
						}
					}
				}
				gameOver = true;
				for (int i = 0; i < field.Rows; ++i)
				{
					for (int j = 0; j < field.Columns; ++j)
					{
						if (field[i, j].State == CellState.EmptyPipe)
						{
							gameOver = false;
						}
					}
				}
				step.AddStep();
				Console.SetCursorPosition(0, 0);
				step.Show();
				show.Show();
				Console.SetCursorPosition(0, field.Rows + offSetCursor);
				System.Threading.Thread.Sleep(sleep);
			}
		}
	}
}