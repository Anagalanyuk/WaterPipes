using System;

namespace WaterPipes
{
	public sealed class InsertSourceWater : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public InsertSourceWater(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.S;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Modification()
		{
			if (field[cursor.Y, cursor.X].State == CellState.Space)
			{
				field[cursor.Y, cursor.X].State = CellState.SourceWater;
			}
			else
			{
				field[cursor.Y, cursor.X].State = CellState.SourceWater;
			}
		}
	}
}