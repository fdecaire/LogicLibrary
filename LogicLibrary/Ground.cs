namespace LogicLibrary
{
	public class Ground : LogicGate
	{
		public Ground(int totalSignals) : base(0)
		{
			Count = totalSignals;

			GateName = "Signal";
			UnknownLastOutput = false;
		}

		public override double Output(int timing) => 0;

		public override int Count { get; }
	}
}
