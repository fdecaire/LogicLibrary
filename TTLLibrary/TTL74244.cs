using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74244: Circuit
	{
		public Wire Input1G { get; set; } = new Wire { CircuitName = "1G" };
		public Wire Input1A1 { get; set; } = new Wire { CircuitName = "1A1" };
		public Wire Input1A2 { get; set; } = new Wire { CircuitName = "1A2" };
		public Wire Input1A3 { get; set; } = new Wire { CircuitName = "1A3" };
		public Wire Input1A4 { get; set; } = new Wire { CircuitName = "1A4" };

		public Wire Input2G { get; set; } = new Wire { CircuitName = "2G" };
		public Wire Input2A1 { get; set; } = new Wire { CircuitName = "2A1" };
		public Wire Input2A2 { get; set; } = new Wire { CircuitName = "2A2" };
		public Wire Input2A3 { get; set; } = new Wire { CircuitName = "2A3" };
		public Wire Input2A4 { get; set; } = new Wire { CircuitName = "2A4" };

		public double Output1Y1(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output1Y2(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output1Y3(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output1Y4(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output2Y1(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output2Y2(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output2Y3(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double Output2Y4(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public TTL74244(TTLGateTypeEnum gateType)
		{
			//TODO: octal line driver
		}
	}
}
