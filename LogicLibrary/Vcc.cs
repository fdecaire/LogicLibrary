namespace LogicLibrary
{
	public class Vcc : LogicGate
	{
		private readonly int _totalSignals;

		public Vcc(int totalSignals) : base( 0)
		{
			_totalSignals = totalSignals;

			GateName = "Signal";
			UnknownLastOutput = false;
		}

		public override double Output(int timing) => 5;

		public override int Count => _totalSignals;
	}
}
