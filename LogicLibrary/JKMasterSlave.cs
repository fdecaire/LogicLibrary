namespace LogicLibrary
{
	public class JKMasterSlave : Circuit
	{
		public Wire J { get; set; } = new Wire { CircuitName = "J" };

		public Wire K { get; set; } = new Wire { CircuitName = "K" };

		public Wire Clk { get; set; } = new Wire { CircuitName = "Clk" };

		public double Q(int timing)
		{
			RunIteration(timing);
			return Gates[0].Output(timing);
		}

		public double QNot(int timing)
		{
			RunIteration(timing);
			return Gates[1].Output(timing);
		}

		public JKMasterSlave(TTLGateTypeEnum gateType)
		{
			var nandGate1 = new NandGate(gateType, 2) { CircuitName = "G1" };
			var nandGate2 = new NandGate(gateType, 2) { CircuitName = "G2" };

			var nandGate3 = new NandGate(gateType, 2) { CircuitName = "G3" };
			var nandGate4 = new NandGate(gateType, 2) { CircuitName = "G4" };

			var nandGate5 = new NandGate(gateType, 2) { CircuitName = "G5" };
			var nandGate6 = new NandGate(gateType, 2) { CircuitName = "G6" };

			var nandGate7 = new NandGate(gateType, 3) { CircuitName = "G7" };
			var nandGate8 = new NandGate(gateType, 3) { CircuitName = "G8" };

			var inverter = new Inverter(gateType) { CircuitName = "G9" };

			Gates.Add(nandGate1);
			Gates.Add(nandGate2);
			Gates.Add(nandGate3);
			Gates.Add(nandGate4);
			Gates.Add(nandGate5);
			Gates.Add(nandGate6);
			Gates.Add(nandGate7);
			Gates.Add(nandGate8);
			Gates.Add(inverter);

			// C0
			Connections.Add(new Connection
			{
				Source = J,
				Termination = nandGate7.Inputs[1],
				Name = "C0"
			});

			// C1
			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate7.Inputs[2],
				Name = "C1"
			});

			// C2
			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate8.Inputs[0],
				Name = "C2"
			});

			// C3
			Connections.Add(new Connection
			{
				Source = K,
				Termination = nandGate8.Inputs[1],
				Name = "C3"
			});

			// C4
			Connections.Add(new Connection
			{
				Source = nandGate7,
				Termination = nandGate5.Inputs[0],
				Name = "C4"
			});

			// C5
			Connections.Add(new Connection
			{
				Source = nandGate8,
				Termination = nandGate6.Inputs[1],
				Name = "C5"
			});

			// C6
			Connections.Add(new Connection
			{
				Source = nandGate6,
				Termination = nandGate5.Inputs[1],
				Name = "C6"
			});

			// C7
			Connections.Add(new Connection
			{
				Source = nandGate5,
				Termination = nandGate6.Inputs[0],
				Name = "C7"
			});

			// C8
			Connections.Add(new Connection
			{
				Source = nandGate5,
				Termination = nandGate3.Inputs[0],
				Name = "C8"
			});

			// C9
			Connections.Add(new Connection
			{
				Source = nandGate6,
				Termination = nandGate4.Inputs[1],
				Name = "C9"
			});

			// C10
			Connections.Add(new Connection
			{
				Source = inverter,
				Termination = nandGate3.Inputs[1],
				Name = "C10"
			});

			// C11
			Connections.Add(new Connection
			{
				Source = inverter,
				Termination = nandGate4.Inputs[0],
				Name = "C11"
			});

			// C12
			Connections.Add(new Connection
			{
				Source = nandGate3,
				Termination = nandGate1.Inputs[0],
				Name = "C12"
			});

			// C13
			Connections.Add(new Connection
			{
				Source = nandGate4,
				Termination = nandGate2.Inputs[1],
				Name = "C13"
			});

			// C14
			Connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate1.Inputs[1],
				Name = "C14"
			});

			// C15
			Connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate2.Inputs[0],
				Name = "C15"
			});

			// C16
			Connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate8.Inputs[2],
				Name = "C16"
			});

			// C17
			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = inverter.Inputs[0],
				Name = "C17"
			});

			// C18
			Connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate7.Inputs[0],
				Name = "C18"
			});
		}
	}
}
