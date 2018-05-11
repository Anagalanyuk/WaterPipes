using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPipes
{
	public sealed class StepUp : IKey
	{
		private Cursor cursor;
		private Field field;
		ConsoleKey key;

		public StepUp(Cursor cursor, Field field)
		{
			this.cursor = cursor;
			this.field = field;
			key = ConsoleKey.W;
		}

		public ConsoleKey Key
		{
			get { return key; }
		}

		public void Move()
		{
			if (cursor.Y > 0)
			{
				cursor.Y -= 1;
			}
		}
	}
}