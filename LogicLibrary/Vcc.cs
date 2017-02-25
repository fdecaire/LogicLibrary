namespace LogicLibrary
{
	public class Vcc : LogicGate
	{
		public Vcc(int totalSignals) : base( 0)
		{
			Count = totalSignals;

			GateName = "Signal";
			UnknownLastOutput = false;
		}

		public override double Output(int timing) => 5;

		public override int Count { get; }
	}
}
