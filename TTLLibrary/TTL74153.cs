using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74153 : Circuit
	{
		public Wire Ea { get; set; } = new Wire { CircuitName = "Ea" };
		public Wire I0a { get; set; } = new Wire { CircuitName = "I0a" };
		public Wire I1a { get; set; } = new Wire { CircuitName = "I1a" };
		public Wire I2a { get; set; } = new Wire { CircuitName = "I2a" };
		public Wire I3a { get; set; } = new Wire { CircuitName = "I3a" };

		public Wire S0 { get; set; } = new Wire { CircuitName = "S0" };
		public Wire S1 { get; set; } = new Wire { CircuitName = "S1" };

		public Wire Eb { get; set; } = new Wire { CircuitName = "Eb" };
		public Wire I0b { get; set; } = new Wire { CircuitName = "I0b" };
		public Wire I1b { get; set; } = new Wire { CircuitName = "I1b" };
		public Wire I2b { get; set; } = new Wire { CircuitName = "I2b" };
		public Wire I3b { get; set; } = new Wire { CircuitName = "I3b" };

		public double Za(int timing)
		{
			RunIteration(timing);
			return Gates[14].Output(timing);
		}

		public double Zb(int timing)
		{
			RunIteration(timing);
			return Gates[15].Output(timing);
		}

		public TTL74153(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) { CircuitName = "G0" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G1" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G2" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G3" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G4" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G5" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G6" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G7" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G8" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G9" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G10" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G11" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G12" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G13" });
			Gates.Add(new OrGate(gateType, 4) { CircuitName = "G14" });
			Gates.Add(new OrGate(gateType, 4) { CircuitName = "G15" });

			#region inputs

			Connections.Add(new Connection
			{
				Source = Ea,
				Termination = Gates[0].Inputs[0],
				Name = "Ea -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = I0a,
				Termination = Gates[6].Inputs[3],
				Name = "I0a -> G6-3"
			});

			Connections.Add(new Connection
			{
				Source = I1a,
				Termination = Gates[7].Inputs[3],
				Name = "I1a -> G7-3"
			});

			Connections.Add(new Connection
			{
				Source = I2a,
				Termination = Gates[8].Inputs[3],
				Name = "I2a -> G8-3"
			});

			Connections.Add(new Connection
			{
				Source = I3a,
				Termination = Gates[9].Inputs[3],
				Name = "I3a -> G9-3"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[1].Inputs[0],
				Name = "S1 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[2].Inputs[0],
				Name = "S0 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = I0b,
				Termination = Gates[10].Inputs[0],
				Name = "I0b -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = I1b,
				Termination = Gates[11].Inputs[0],
				Name = "I1b -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = I2b,
				Termination = Gates[12].Inputs[0],
				Name = "I2b -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = I3b,
				Termination = Gates[13].Inputs[0],
				Name = "I3b -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = Eb,
				Termination = Gates[3].Inputs[0],
				Name = "Eb -> G3-0"
			});
			#endregion

			#region Gate 0 outputs

			for (int i = 6; i < 10; i++)
			{
				Connections.Add(new Connection
				{
					Source = Gates[0],
					Termination = Gates[i].Inputs[0],
					Name = $"G0 -> G{i}-0"
				});
			}

			#endregion

			#region Gate 1 outputs
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[4].Inputs[0],
				Name = "G1 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[6].Inputs[1],
				Name = "G1 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[7].Inputs[1],
				Name = "G1 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[10].Inputs[1],
				Name = "G1 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[11].Inputs[1],
				Name = "G1 -> G11-1"
			});

			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[5].Inputs[0],
				Name = "G2 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[6].Inputs[2],
				Name = "G2 -> G6-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[8].Inputs[2],
				Name = "G2 -> G8-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[10].Inputs[2],
				Name = "G2 -> G10-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[12].Inputs[2],
				Name = "G2 -> G12-2"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[10].Inputs[3],
				Name = "G3 -> G10-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[11].Inputs[3],
				Name = "G3 -> G11-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[12].Inputs[3],
				Name = "G3 -> G12-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[13].Inputs[3],
				Name = "G3 -> G13-3"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[8].Inputs[1],
				Name = "G4 -> G8-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[9].Inputs[1],
				Name = "G4 -> G9-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[12].Inputs[1],
				Name = "G4 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[13].Inputs[1],
				Name = "G4 -> G13-1"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[7].Inputs[2],
				Name = "G5 -> G7-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[9].Inputs[2],
				Name = "G5 -> G9-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[11].Inputs[2],
				Name = "G5 -> G11-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[13].Inputs[2],
				Name = "G5 -> G13-2"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[14].Inputs[0],
				Name = "G6 -> G14-0"
			});
			#endregion

			#region Gate 7 outputs
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[14].Inputs[1],
				Name = "G7 -> G14-1"
			});
			#endregion

			#region Gate 8 outputs
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[14].Inputs[2],
				Name = "G8 -> G14-2"
			});
			#endregion

			#region Gate 9 outputs
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[14].Inputs[3],
				Name = "G9 -> G14-3"
			});
			#endregion

			#region Gate 10 outputs
			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[15].Inputs[0],
				Name = "G10 -> G15-0"
			});
			#endregion

			#region Gate 11 outputs
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
				Termination = Gates[15].Inputs[2],
				Name = "G12 -> G15-2"
			});
			#endregion

			#region Gate 13 outputs
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[15].Inputs[3],
				Name = "G13 -> G15-3"
			});
			#endregion
		}
	}
}
