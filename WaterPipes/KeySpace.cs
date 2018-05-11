using System;

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
			step.AddStep();
			Console.SetCursorPosition(0, 0);
			step.Show();
			show.Show();
			Console.SetCursorPosition(0, field.Rows + 3);
		}
	}
}