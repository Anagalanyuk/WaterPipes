using System;
using System.Collections.Generic;

namespace WaterPipes
{
	public sealed class Game
	{
		private BorderField border;
		private Cursor cursor;
		private Field field;
		private ShowField show;
		private CountStep step;

		public Game()
		{
			field = new Field();
			border = new BorderField(field.Rows, field.Columns, '+');
			cursor = new Cursor();
			show = new ShowField(field);
			step = new CountStep();
		}

		public void PlayGame()
		{
			step.Show();
			border.Show();
			show.Show();
			cursor.Show();
			Console.SetCursorPosition(0, field.Rows + 3);
			List<IKey> keys = new List<IKey>();
			keys.Add(new StepLeft(cursor, field));
			keys.Add(new StepRight(cursor, field));
			keys.Add(new StepUp(cursor, field));
			keys.Add(new StepDown(cursor, field));
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
						canKey.Move();
					}
				}
				pressKey.Move(key);
				show.Show();
				cursor.Show();
				Console.SetCursorPosition(0, field.Rows + 3);
			}
			KeySpace start = new KeySpace(field, step);
			start.StartGame();
		}
	}
}