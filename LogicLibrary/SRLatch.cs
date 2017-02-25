namespace LogicLibrary
{
	public class SRLatch : Circuit
	{
		public Wire S { get; set; } = new Wire();
		public Wire R { get; set; } = new Wire();

		public double Q(int timing)
		{
			return Gates[0].Output(timing);
		}

		public double QBar(int timing)
		{
			return Gates[1].Output(timing);
		}

		public SRLatch(TTLGateTypeEnum gateType)
		{
			var nandGate1 = new NandGate(gateType, 2);
			var nandGate2 = new NandGate(gateType, 2);

			Gates.Add(nandGate1);
			Gates.Add(nandGate2);

			// C0
			Connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate2.Inputs[0]
			});

			// C1
			Connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate1.Inputs[1]
			});

			// C2
			Connections.Add(new Connection
			{
				Source = S,
				Termination = nandGate1.Inputs[0]
			});

			// C3
			Connections.Add(new Connection
			{
				Source = R,
				Termination = nandGate2.Inputs[1]
			});
		}
	}
}
