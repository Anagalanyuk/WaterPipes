namespace WaterPipes
{
	public sealed class Cell
	{
		private CellState cell = CellState.Space;

		public CellState State
		{
			get { return cell; }
			set { cell = value; }
		}

		public object Clone()
		{
			Cell clone = new Cell();
			clone.cell = cell;
			return clone;
		}

		public void StateChange()
		{
			if (cell == CellState.Space || cell == CellState.SourceWater)
			{
				cell = CellState.EmptyPipe;
			}
			else
			{
				cell = CellState.Space;
			}
		}
	}
}