using System;

namespace WaterPipes
{
	public interface IKey
	{
		ConsoleKey Key { get; }

		void Move();
	}
}
