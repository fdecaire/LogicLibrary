using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class JKFlipFlop : Circuit
	{
		public Wire J { get; set; } = new Wire {CircuitName = "J"};

		public Wire K { get; set; } = new Wire {CircuitName = "K"};

		public Wire Clk { get; set; } = new Wire {CircuitName = "Clk"};

		public double Q(int timing)
		{
			return Gates[0].Output(timing);
		}

		public double QNot(int timing)
		{
			return Gates[1].Output(timing);
		}

		// test output
		public double Gate3Output(int timing)
		{
			return Gates[2].Output(timing);
		}

		// test output
		public double Gate4Output(int timing)
		{
			return Gates[3].Output(timing);
		}

		public JKFlipFlop(TTLGateTypeEnum gateType)
		{
			var nandGate1 = new NandGate(gateType, 2) {CircuitName = "G1"};
			var nandGate2 = new NandGate(gateType, 2) {CircuitName = "G2"};

			var nandGate3 = new NandGate(gateType, 3) {CircuitName = "G3"};
			var nandGate4 = new NandGate(gateType, 3) {CircuitName = "G4"};

			Gates.Add(nandGate1);
			Gates.Add(nandGate2);
			Gates.Add(nandGate3);
			Gates.Add(nandGate4);

			// C0
			Connections.Add(new Connection
			{
				Source = J,
				Termination = nandGate3.Inputs[1],
				Name = "C0"
			});

			// C1
			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate3.Inputs[2],
				Name = "C1"
			});

			// C2
			Connections.Add(new Connection
			{
				Source = nandGate2, // QNot
				Termination = nandGate3.Inputs[0],
				Name = "C2"
			});

			// C3
			Connections.Add(new Connection
			{
				Source = K,
				Termination = nandGate4.Inputs[1],
				Name = "C3"
			});

			// C4
			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate4.Inputs[0],
				Name = "C4"
			});

			// C5
			Connections.Add(new Connection
			{
				Source = nandGate1, // Q
				Termination = nandGate4.Inputs[2],
				Name = "C5"
			});

			// C6
			Connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate2.Inputs[0],
				Name = "C6"
			});

			// C7
			Connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate1.Inputs[1],
				Name = "C7"
			});

			// C8
			Connections.Add(new Connection
			{
				Source = nandGate3,
				Termination = nandGate1.Inputs[0],
				Name = "C8"
			});

			// C9
			Connections.Add(new Connection
			{
				Source = nandGate4,
				Termination = nandGate2.Inputs[1],
				Name = "C9"
			});
		}
	}
}
