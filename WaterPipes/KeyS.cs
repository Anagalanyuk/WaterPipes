using System;

namespace WaterPipes
{
	public sealed class KeyS : IKey
	{
		private Cursor cursor;
		private Field field;
		private ConsoleKey key;

		public KeyS(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.S;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			field[cursor.Y, cursor.X].State = CellState.SourceWater;
		}
	}
}