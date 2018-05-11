using System;

namespace WaterPipes
{
	public class CountStep
	{
		private int numberSteps;
		private string step = "Step: ";

		public int NumberSteps
		{
			get { return numberSteps; }
		}

		public void AddStep()
		{
			numberSteps += 1;
		}

		public void Show()
		{
			Console.Write(step);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(numberSteps);
			Console.ResetColor();
		}
	}
}