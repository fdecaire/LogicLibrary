namespace LogicLibrary
{
	public class Ground : LogicGate
	{
		private readonly int _totalSignals;

		public Ground(int totalSignals) : base( 0)
		{
			_totalSignals = totalSignals;

			GateName = "Signal";
		}

		public override double Output(int timing) => 0;

		public override int Count => _totalSignals;
	}
}
