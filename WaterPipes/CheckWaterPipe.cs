using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPipes
{
	public class CheckWaterPipe
	{
		private Cursor cursor;
		private Field field;

		public CheckWaterPipe(Field field, Cursor cursor)
		{
			this.cursor = cursor;
			this.field = field;
		}

		public bool Check(Field field, Cursor cursor)
		{
			bool IsSource = false;
			if (field[cursor.Y, cursor.X + 1].State == CellState.SourceWater || cursor.X <field.Columns - 2)
			{
				if (field[cursor.Y, cursor.X + 1].State == CellState.SourceWater)
				{
					IsSource = true;
				}
				cursor.X += 1;
				Check(field,cursor);
			}


			//		int columns = cursor.X;
			//		int rows = cursor.Y;
			//		int numberBranches = 0;
			//		int numberSource = 0;
			//		if (cursor.X < field.Columns - 1 && field[cursor.Y, cursor.X + 1].State == CellState.EmptyPipe)
			//		{
			//			++numberBranches;
			//			while (columns < field.Columns - 1)
			//			{
			//				if (field[cursor.Y, columns].State == CellState.SourceWater)
			//				{
			//					++numberSource;
			//					break;
			//				}
			//				else if (field[cursor.Y, columns].State == CellState.Space)
			//				{
			//					break;
			//				}
			//				++columns;
			//			}
			//		}
			//		if (cursor.Y < field.Columns - 1 && field[cursor.Y + 1, cursor.X].State == CellState.EmptyPipe)
			//		{
			//			++numberBranches;
			//			while (rows < field.Rows - 1)
			//			{
			//				if (field[rows, cursor.X].State == CellState.SourceWater)
			//				{
			//					++numberSource;
			//					break;
			//				}
			//				else if (field[rows, cursor.X].State == CellState.Space)
			//				{
			//					break;
			//				}
			//				++rows;
			//			}
			//		}
			//		if (cursor.X > 0 && field[cursor.Y, cursor.X - 1].State == CellState.EmptyPipe)
			//		{
			//			++numberBranches;
			//			while (columns > 0)
			//			{
			//				if (field[cursor.Y, columns].State == CellState.SourceWater)
			//				{
			//					++numberSource;
			//					break;
			//				}
			//				else if (field[cursor.Y, columns].State == CellState.Space)
			//				{
			//					break;
			//				}
			//				--columns;
			//			}
			//		}
			//		if (cursor.Y > 0 && field[cursor.Y - 1, cursor.X].State == CellState.EmptyPipe)
			//		{
			//			++numberBranches;
			//			while (rows > 1)
			//			{
			//				if (field[rows, cursor.X].State == CellState.SourceWater)
			//				{
			//					++numberSource;
			//					break;
			//				}
			//				else if (field[rows, cursor.X].State == CellState.Space)
			//				{
			//					break;
			//				}
			//				--rows;
			//			}
			//		}
			//		if (numberBranches == numberSource)
			//		{
			//			IsSource = true;
			//		}
			return IsSource;
		}
	}
}
