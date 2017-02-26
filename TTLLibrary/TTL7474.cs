using LogicLibrary;

namespace TTLLibrary
{
	public class TTL7474: Circuit
	{
		public Wire PRE1 { get; set; } = new Wire { CircuitName = "PRE1" };
		public Wire CLR1 { get; set; } = new Wire { CircuitName = "CLR1" };
		public Wire CLK1 { get; set; } = new Wire { CircuitName = "CLK1" };
		public Wire D1 { get; set; } = new Wire { CircuitName = "D1" };

		public Wire PRE2 { get; set; } = new Wire { CircuitName = "PRE2" };
		public Wire CLR2 { get; set; } = new Wire { CircuitName = "CLR2" };
		public Wire CLK2 { get; set; } = new Wire { CircuitName = "CLK2" };
		public Wire D2 { get; set; } = new Wire { CircuitName = "D2" };

		public double Q1(int timing)
		{
			RunIteration(timing);
			return Gates[4].Output(timing);
		}

		public double QBar1(int timing)
		{
			RunIteration(timing);
			return Gates[5].Output(timing);
		}

		public double Q2(int timing)
		{
			RunIteration(timing);
			return Gates[10].Output(timing);
		}

		public double QBar2(int timing)
		{
			RunIteration(timing);
			return Gates[11].Output(timing);
		}

		public TTL7474(TTLGateTypeEnum gateType)
		{
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G0" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G1" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G2" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G3" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G4" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G5" });

			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G6" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G7" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G8" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G9" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G10" });
			Gates.Add(new NandGate(gateType, 3) { CircuitName = "G11" });

			#region inputs

			Connections.Add(new Connection
			{
				Source = PRE1,
				Termination = Gates[0].Inputs[0],
				Name = "PRE1 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = PRE1,
				Termination = Gates[4].Inputs[0],
				Name = "PRE1 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = CLR1,
				Termination = Gates[1].Inputs[1],
				Name = "CLR1 -> G1-1"
			});

			Connections.Add(new Connection
			{
				Source = CLR1,
				Termination = Gates[5].Inputs[1],
				Name = "CLR1 -> G5-1"
			});

			Connections.Add(new Connection
			{
				Source = CLR1,
				Termination = Gates[3].Inputs[1],
				Name = "CLR1 -> G3-1"
			});

			Connections.Add(new Connection
			{
				Source = CLK1,
				Termination = Gates[2].Inputs[1],
				Name = "CLK1 -> G2-1"
			});

			Connections.Add(new Connection
			{
				Source = CLK1,
				Termination = Gates[1].Inputs[2],
				Name = "CLK1 -> G1-2"
			});

			Connections.Add(new Connection
			{
				Source = D1,
				Termination = Gates[3].Inputs[2],
				Name = "D1 -> G3-2"
			});

			// second unit
			Connections.Add(new Connection
			{
				Source = PRE2,
				Termination = Gates[6].Inputs[0],
				Name = "PRE2 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = PRE2,
				Termination = Gates[10].Inputs[0],
				Name = "PRE2 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = CLR2,
				Termination = Gates[7].Inputs[1],
				Name = "CLR2 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = CLR2,
				Termination = Gates[11].Inputs[1],
				Name = "CLR2 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = CLR2,
				Termination = Gates[9].Inputs[1],
				Name = "CLR2 -> G9-1"
			});

			Connections.Add(new Connection
			{
				Source = CLK2,
				Termination = Gates[8].Inputs[1],
				Name = "CLK2 -> G8-1"
			});

			Connections.Add(new Connection
			{
				Source = CLK2,
				Termination = Gates[7].Inputs[2],
				Name = "CLK2 -> G7-2"
			});

			Connections.Add(new Connection
			{
				Source = D2,
				Termination = Gates[9].Inputs[2],
				Name = "D2 -> G9-2"
			});
			#endregion

			#region Gate 0 outputs

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[1].Inputs[0],
				Name = "G0 -> G1-0"
			});
			#endregion

			#region Gate 1 outputs

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[0].Inputs[2],
				Name = "G1 -> G0-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[4].Inputs[1],
				Name = "G1 -> G4-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[2].Inputs[0],
				Name = "G1 -> G2-0"
			});
			#endregion

			#region Gate 2 outputs

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[3].Inputs[0],
				Name = "G2 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[5].Inputs[2],
				Name = "G2 -> G5-2"
			});
			#endregion

			#region Gate 3 outputs

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[2].Inputs[2],
				Name = "G3 -> G2-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[0].Inputs[1],
				Name = "G3 -> G0-1"
			});
			#endregion

			#region Gate 4 outputs

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[5].Inputs[0],
				Name = "G4 -> G5-0"
			});
			#endregion

			#region Gate 5 outputs

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[4].Inputs[2],
				Name = "G5 -> G4-2"
			});
			#endregion

			#region Gate 6 outputs

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[7].Inputs[0],
				Name = "G6 -> G7-0"
			});
			#endregion

			#region Gate 7 outputs

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[6].Inputs[2],
				Name = "G7 -> G6-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[10].Inputs[1],
				Name = "G7 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[8].Inputs[0],
				Name = "G7 -> G8-0"
			});
			#endregion

			#region Gate 8 outputs

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[9].Inputs[0],
				Name = "G8 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[11].Inputs[2],
				Name = "G8 -> G11-2"
			});
			#endregion

			#region Gate 9 outputs

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[8].Inputs[2],
				Name = "G9 -> G8-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[6].Inputs[1],
				Name = "G9 -> G6-1"
			});
			#endregion

			#region Gate 10 outputs

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[11].Inputs[0],
				Name = "G10 -> G11-0"
			});
			#endregion

			#region Gate 11 outputs

			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[10].Inputs[2],
				Name = "G11 -> G10-2"
			});
			#endregion


		}
	}
}
