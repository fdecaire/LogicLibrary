using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74148 : Circuit
	{
		public Wire I0 { get; set; } = new Wire {CircuitName = "I0"};
		public Wire I1 { get; set; } = new Wire {CircuitName = "I1"};
		public Wire I2 { get; set; } = new Wire {CircuitName = "I2"};
		public Wire I3 { get; set; } = new Wire {CircuitName = "I3"};
		public Wire I4 { get; set; } = new Wire {CircuitName = "I4"};
		public Wire I5 { get; set; } = new Wire {CircuitName = "I5"};
		public Wire I6 { get; set; } = new Wire {CircuitName = "I6"};
		public Wire I7 { get; set; } = new Wire {CircuitName = "I7"};
		public Wire EI { get; set; } = new Wire {CircuitName = "EI"};

		public double EO(int timing)
		{
			RunIteration(timing);
			return Gates[12].Output(timing);
		}

		public double GS(int timing)
		{
			RunIteration(timing);
			return Gates[25].Output(timing);
		}

		public double A0(int timing)
		{
			RunIteration(timing);
			return Gates[26].Output(timing);
		}

		public double A1(int timing)
		{
			RunIteration(timing);
			return Gates[27].Output(timing);
		}

		public double A2(int timing)
		{
			RunIteration(timing);
			return Gates[28].Output(timing);
		}

		public TTL74148(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) {CircuitName = "G0"});
			Gates.Add(new Inverter(gateType) { CircuitName = "G1" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G2" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G3" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G4" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G5" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G6" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G7" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G8" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G9" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G10" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G11" });

			Gates.Add(new NandGate(gateType, 9) { CircuitName = "G12" });
			
			Gates.Add(new AndGate(gateType, 5) { CircuitName = "G13" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G14" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G15" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G16" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G17" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G18" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G19" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G20" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G21" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G22" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G23" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G24" });

			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G25" });

			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G26" });
			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G27" });
			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G28" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = I0,
				Termination = Gates[12].Inputs[0],
				Name = "I0 -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = I1,
				Termination = Gates[0].Inputs[0],
				Name = "I1 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = I1,
				Termination = Gates[12].Inputs[1],
				Name = "I1 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = I2,
				Termination = Gates[1].Inputs[0],
				Name = "I2 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = I2,
				Termination = Gates[12].Inputs[2],
				Name = "I2 -> G12-2"
			});

			Connections.Add(new Connection
			{
				Source = I3,
				Termination = Gates[2].Inputs[0],
				Name = "I3 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = I3,
				Termination = Gates[12].Inputs[3],
				Name = "I3 -> G12-3"
			});

			Connections.Add(new Connection
			{
				Source = I4,
				Termination = Gates[3].Inputs[0],
				Name = "I4 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = I4,
				Termination = Gates[12].Inputs[4],
				Name = "I4 -> G12-4"
			});

			Connections.Add(new Connection
			{
				Source = I5,
				Termination = Gates[4].Inputs[0],
				Name = "I5 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = I5,
				Termination = Gates[12].Inputs[5],
				Name = "I5 -> G12-5"
			});

			Connections.Add(new Connection
			{
				Source = I6,
				Termination = Gates[5].Inputs[0],
				Name = "I6 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = I6,
				Termination = Gates[12].Inputs[6],
				Name = "I6 -> G12-6"
			});

			Connections.Add(new Connection
			{
				Source = I7,
				Termination = Gates[6].Inputs[0],
				Name = "I7 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = I7,
				Termination = Gates[12].Inputs[7],
				Name = "I7 -> G12-7"
			});

			Connections.Add(new Connection
			{
				Source = EI,
				Termination = Gates[7].Inputs[0],
				Name = "EI -> G7-0"
			});
			#endregion

			#region Gate 0 outputs
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[13].Inputs[0],
				Name = "G0 -> G13-0"
			});
			#endregion

			#region Gate 1 outputs
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[8].Inputs[0],
				Name = "G1 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[17].Inputs[0],
				Name = "G1 -> G17-0"
			});
			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[14].Inputs[0],
				Name = "G2 -> G14-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[18].Inputs[0],
				Name = "G2 -> G18-0"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[9].Inputs[0],
				Name = "G3 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[21].Inputs[0],
				Name = "G3 -> G21-0"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[10].Inputs[0],
				Name = "G4 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[15].Inputs[0],
				Name = "G4 -> G15-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[22].Inputs[0],
				Name = "G4 -> G22-0"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[11].Inputs[0],
				Name = "G5 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[19].Inputs[0],
				Name = "G5 -> G19-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[23].Inputs[0],
				Name = "G5 -> G23-0"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[24].Inputs[0],
				Name = "G6 -> G24-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[20].Inputs[0],
				Name = "G6 -> G20-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[16].Inputs[0],
				Name = "G6 -> G16-0"
			});
			#endregion

			#region Gate 7 outputs

			for (int i = 12; i < 25; i++)
			{
				Connections.Add(new Connection
				{
					Source = Gates[7],
					Termination = Gates[i].Inputs[Gates[i].Inputs.Count-1],
					Name = $"G7 -> G{i}-{Gates[i].Inputs.Count - 1}"
				});
			}
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[25].Inputs[1],
				Name = "G7 -> G25-1"
			});

			#endregion

			#region Gate 8 outputs
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[13].Inputs[1],
				Name = "G8 -> G13-1"
			});
			#endregion

			#region Gate 9 outputs
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[13].Inputs[2],
				Name = "G9 -> G13-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[14].Inputs[1],
				Name = "G9 -> G14-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[17].Inputs[1],
				Name = "G9 -> G17-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[18].Inputs[1],
				Name = "G9 -> G18-1"
			});
			#endregion

			#region Gate 10 outputs
			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[17].Inputs[2],
				Name = "G10 -> G17-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[18].Inputs[2],
				Name = "G10 -> G18-2"
			});
			#endregion

			#region Gate 11 outputs
			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[13].Inputs[3],
				Name = "G11 -> G13-4"
			});

			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[14].Inputs[2],
				Name = "G11 -> G14-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[15].Inputs[1],
				Name = "G11 -> G15-1"
			});
			#endregion

			#region Gate 12 outputs
			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[25].Inputs[0],
				Name = "G12 -> G25-0"
			});
			#endregion

			#region Gate 13 outputs
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[26].Inputs[0],
				Name = "G13 -> G26-0"
			});
			#endregion

			#region Gate 14 outputs
			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[26].Inputs[1],
				Name = "G14 -> G26-1"
			});
			#endregion

			#region Gate 15 outputs
			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[26].Inputs[2],
				Name = "G15 -> G26-2"
			});
			#endregion

			#region Gate 16 outputs
			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[26].Inputs[3],
				Name = "G16 -> G26-3"
			});
			#endregion

			#region Gate 17 outputs
			Connections.Add(new Connection
			{
				Source = Gates[17],
				Termination = Gates[27].Inputs[0],
				Name = "G17 -> G27-0"
			});
			#endregion

			#region Gate 18 outputs
			Connections.Add(new Connection
			{
				Source = Gates[18],
				Termination = Gates[27].Inputs[1],
				Name = "G18 -> G27-1"
			});
			#endregion

			#region Gate 19 outputs
			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[27].Inputs[2],
				Name = "G19 -> G27-2"
			});
			#endregion

			#region Gate 20 outputs
			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[27].Inputs[3],
				Name = "G20 -> G27-3"
			});
			#endregion

			#region Gate 21 outputs
			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[28].Inputs[0],
				Name = "G21 -> G28-0"
			});
			#endregion

			#region Gate 22 outputs
			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[28].Inputs[1],
				Name = "G22 -> G28-1"
			});
			#endregion

			#region Gate 23 outputs
			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[28].Inputs[2],
				Name = "G23 -> G28-2"
			});
			#endregion

			#region Gate 24 outputs
			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[28].Inputs[3],
				Name = "G24 -> G28-3"
			});
			#endregion
		}
	}
}
