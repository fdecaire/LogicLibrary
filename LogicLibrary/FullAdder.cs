namespace LogicLibrary
{
	public class FullAdder : Circuit
	{
		public Wire A { get; set; } = new Wire();

		public Wire B { get; set; } = new Wire();

		public Wire Cin { get; set; } = new Wire();

		public double S(int timing)
		{
			RunIteration(timing);
			return Gates[1].Output(timing);
		}

		public double Cout(int timing)
		{
			RunIteration(timing);
			return Gates[4].Output(timing);
		}

		public FullAdder(TTLGateTypeEnum gateTypes)
		{
			Name = "full adder";

			Gates.Add(new XorGate(gateTypes, 2) { CircuitName = "G0" });
			Gates.Add(new XorGate(gateTypes, 2) { CircuitName = "G1" });
			Gates.Add(new AndGate(gateTypes, 2) { CircuitName = "G2" });
			Gates.Add(new AndGate(gateTypes, 2) { CircuitName = "G3" });
			Gates.Add(new OrGate(gateTypes, 2) { CircuitName = "G4" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = A,
				Termination = Gates[0].Inputs[0],
				Name = "A -> G0(0)"
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = Gates[0].Inputs[1],
				Name = "B -> G0(1)"
			});

			Connections.Add(new Connection
			{
				Source = A,
				Termination = Gates[3].Inputs[0],
				Name = "A -> G3(0)"
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = Gates[3].Inputs[1],
				Name = "B -> G3(1)"
			});

			Connections.Add(new Connection
			{
				Source = Cin,
				Termination = Gates[1].Inputs[1],
				Name = "Cin -> G1(1)"
			});

			Connections.Add(new Connection
			{
				Source = Cin,
				Termination = Gates[2].Inputs[0],
				Name = "Cin -> G2(0)"
			});
			#endregion

			#region gate 0 output
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[1].Inputs[0],
				Name = "G0 -> G1(0)"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[2].Inputs[1],
				Name = "G0 -> G2(1)"
			});
			#endregion

			#region gate 2 output
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[4].Inputs[0],
				Name = "G2 -> G4(0)"
			});
			#endregion

			#region gate 3 output
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[4].Inputs[1],
				Name = "G3 -> G4(1)"
			});
			#endregion
		}
	}
}
