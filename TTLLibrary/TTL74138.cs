using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74138 : Circuit
	{
		public Wire A { get; set; } = new Wire { CircuitName = "A" };
		public Wire B { get; set; } = new Wire { CircuitName = "B" };
		public Wire C { get; set; } = new Wire { CircuitName = "C" };
		public Wire G1 { get; set; } = new Wire { CircuitName = "G1" };
		public Wire G2A { get; set; } = new Wire { CircuitName = "G2A" };
		public Wire G2B { get; set; } = new Wire { CircuitName = "G2B" };

		public double Y0(int timing)
		{
			return Gates[11].Output(timing);
		}

		public double Y1(int timing)
		{
			return Gates[12].Output(timing);
		}

		public double Y2(int timing)
		{
			return Gates[13].Output(timing);
		}

		public double Y3(int timing)
		{
			return Gates[14].Output(timing);
		}

		public double Y4(int timing)
		{
			return Gates[15].Output(timing);
		}

		public double Y5(int timing)
		{
			return Gates[16].Output(timing);
		}

		public double Y6(int timing)
		{
			return Gates[17].Output(timing);
		}

		public double Y7(int timing)
		{
			return Gates[18].Output(timing);
		}

		public TTL74138(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) { CircuitName = "G0" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G1" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G2" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G3" });

			Gates.Add(new AndGate(gateType,3) { CircuitName = "G4" });

			Gates.Add(new Inverter(gateType) { CircuitName = "G5" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G6" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G7" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G8" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G9" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G10" });

			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G11" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G12" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G13" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G14" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G15" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G16" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G17" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G18" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[0].Inputs[0],
				Name = "G1 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = G2A,
				Termination = Gates[2].Inputs[0],
				Name = "G2A -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = G2B,
				Termination = Gates[3].Inputs[0],
				Name = "G2B -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = A,
				Termination = Gates[5].Inputs[0],
				Name = "A -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = Gates[6].Inputs[0],
				Name = "B -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = C,
				Termination = Gates[7].Inputs[0],
				Name = "C -> G7-0"
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
				Termination = Gates[4].Inputs[0],
				Name = "G1 -> G4-0"
			});
			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[4].Inputs[1],
				Name = "G2 -> G4-1"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[4].Inputs[2],
				Name = "G3 -> G4-2"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[11].Inputs[3],
				Name = "G4 -> G11-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[12].Inputs[3],
				Name = "G4 -> G12-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[13].Inputs[3],
				Name = "G4 -> G13-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[14].Inputs[3],
				Name = "G4 -> G14-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[15].Inputs[3],
				Name = "G4 -> G15-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[16].Inputs[3],
				Name = "G4 -> G16-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[17].Inputs[3],
				Name = "G4 -> G17-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[18].Inputs[0],
				Name = "G4 -> G18-0"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[8].Inputs[0],
				Name = "G5 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[11].Inputs[0],
				Name = "G5 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[13].Inputs[0],
				Name = "G5 -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[15].Inputs[0],
				Name = "G5 -> G15-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[17].Inputs[0],
				Name = "G5 -> G17-0"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[9].Inputs[0],
				Name = "G6 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[11].Inputs[1],
				Name = "G6 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[12].Inputs[1],
				Name = "G6 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[15].Inputs[1],
				Name = "G6 -> G15-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[16].Inputs[0],
				Name = "G6 -> G16-0"
			});
			#endregion

			#region Gate 7 outputs
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[10].Inputs[0],
				Name = "G7 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[11].Inputs[2],
				Name = "G7 -> G11-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[12].Inputs[2],
				Name = "G7 -> G12-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[13].Inputs[2],
				Name = "G7 -> G13-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[14].Inputs[2],
				Name = "G7 -> G14-2"
			});
			#endregion

			#region Gate 8 outputs
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[12].Inputs[0],
				Name = "G8 -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[14].Inputs[0],
				Name = "G8 -> G14-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[16].Inputs[2],
				Name = "G8 -> G16-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[18].Inputs[2],
				Name = "G8 -> G18-2"
			});
			#endregion

			#region Gate 9 outputs
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[13].Inputs[1],
				Name = "G9 -> G13-1"
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
				Termination = Gates[17].Inputs[2],
				Name = "G9 -> G17-2"
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
				Termination = Gates[15].Inputs[2],
				Name = "G10 -> G15-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[16].Inputs[1],
				Name = "G10 -> G16-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[17].Inputs[1],
				Name = "G10 -> G17-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[18].Inputs[3],
				Name = "G10 -> G18-3"
			});
			#endregion
		}
	}
}
