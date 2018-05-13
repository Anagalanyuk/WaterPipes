using System;
using System.Collections.Generic;

namespace WaterPipes
{
	public sealed class Game
	{
		private BorderField border;
		private Cursor cursor;
		private Field field;
		private int offSet = 3;
		private ShowField show;
		private CountStep step;

		public Game()
		{
			field = new Field();
			border = new BorderField(field.Rows, field.Columns, '+');
			cursor = new Cursor();
			step = new CountStep();
			show = new ShowField(field);
		}

		public void PlayGame()
		{
			step.Show();
			border.Show();
			show.Show();
			cursor.Show();
			Console.SetCursorPosition(0, field.Rows + offSet);
			List<IKey> keys = new List<IKey>();
			keys.Add(new KeyEnter(cursor, field));
			keys.Add(new KeyS(cursor, field));
			var key = ConsoleKey.Pause;
			Moves pressKey = new Moves(cursor, field);
			while (key != ConsoleKey.Spacebar)
			{
				key = Console.ReadKey().Key;
				foreach (IKey canKey in keys)
				{
					if (canKey.Key == key)
					{
						canKey.Action();
					}
				}
				pressKey.Move(key);
				show.Show();
				cursor.Show();
				Console.SetCursorPosition(0, field.Rows + offSet);
			}
			KeySpace start = new KeySpace(field, step);
			start.StartGame();
		}
	}
}