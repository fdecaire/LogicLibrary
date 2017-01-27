using LogicLibrary;

namespace TTLLibrary
{
	// 2-line to 4-line data selector multiplexer
	public class TTL74157 : Circuit
	{
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire B2 { get; set; } = new Wire { CircuitName = "B2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire B3 { get; set; } = new Wire { CircuitName = "B3" };
		public Wire A4 { get; set; } = new Wire { CircuitName = "A4" };
		public Wire B4 { get; set; } = new Wire { CircuitName = "B4" };
		public Wire Select { get; set; } = new Wire { CircuitName = "Select" };
		public Wire Strobe { get; set; } = new Wire { CircuitName = "Strobe" };

		public double Y1(int timing)
		{
			RunIteration(timing);
			return Gates[8].Output(timing);
		}

		public double Y2(int timing)
		{
			RunIteration(timing);
			return Gates[9].Output(timing);
		}

		public double Y3(int timing)
		{
			RunIteration(timing);
			return Gates[10].Output(timing);
		}

		public double Y4(int timing)
		{
			RunIteration(timing);
			return Gates[11].Output(timing);
		}

		public TTL74157(TTLGateTypeEnum gateType)
		{
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G0" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G1" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G2" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G3" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G4" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G5" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G6" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G7" });
			Gates.Add(new OrGate(gateType, 2) { CircuitName = "G8" });
			Gates.Add(new OrGate(gateType, 2) { CircuitName = "G9" });
			Gates.Add(new OrGate(gateType, 2) { CircuitName = "G10" });
			Gates.Add(new OrGate(gateType, 2) { CircuitName = "G11" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G12" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G13" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G14" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[0].Inputs[0],
				Name = "A1 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[1].Inputs[0],
				Name = "B1 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[2].Inputs[0],
				Name = "A2 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[3].Inputs[0],
				Name = "B2 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[4].Inputs[0],
				Name = "A3 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[5].Inputs[0],
				Name = "B3 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = A4,
				Termination = Gates[6].Inputs[0],
				Name = "A4 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = B4,
				Termination = Gates[7].Inputs[0],
				Name = "B4 -> G7-0"
			});

			Connections.Add(new Connection
			{
				Source = Select,
				Termination = Gates[12].Inputs[0],
				Name = "Select -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = Strobe,
				Termination = Gates[14].Inputs[0],
				Name = "Strobe -> G14-0"
			});
			#endregion

			#region Gate 0 outputs
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[8].Inputs[0],
				Name = "G0 -> G8-0"
			});
			#endregion

			#region Gate 1 outputs
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[8].Inputs[1],
				Name = "G1 -> G8-1"
			});
			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[9].Inputs[0],
				Name = "G2 -> G9-0"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[9].Inputs[1],
				Name = "G3 -> G9-1"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[10].Inputs[0],
				Name = "G4 -> G10-0"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[10].Inputs[1],
				Name = "G5 -> G10-1"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[11].Inputs[0],
				Name = "G6 -> G11-0"
			});
			#endregion

			#region Gate 7 outputs
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[11].Inputs[1],
				Name = "G7 -> G11-1"
			});
			#endregion

			#region Gate 12 outputs
			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[0].Inputs[1],
				Name = "G12 -> G0-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[2].Inputs[1],
				Name = "G12 -> G2-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[4].Inputs[1],
				Name = "G12 -> G4-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[6].Inputs[1],
				Name = "G12 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[13].Inputs[0],
				Name = "G12 -> G13-0"
			});
			#endregion

			#region Gate 13 outputs
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[1].Inputs[1],
				Name = "G13 -> G1-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[3].Inputs[1],
				Name = "G13 -> G3-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[5].Inputs[1],
				Name = "G13 -> G5-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[7].Inputs[1],
				Name = "G13 -> G7-1"
			});
			#endregion

			#region Gate 14 outputs
			for (int i = 0; i < 8; i++)
			{
				Connections.Add(new Connection
				{
					Source = Gates[14],
					Termination = Gates[i].Inputs[2],
					Name = $"G14 -> G{i}-2"
				});
			}
			#endregion
		}
	}
}
