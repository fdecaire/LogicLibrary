using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74182 : Circuit
	{
		public Wire Cn { get; set; } = new Wire { CircuitName = "Cn" };
		public Wire G0 { get; set; } = new Wire { CircuitName = "G0" };
		public Wire P0 { get; set; } = new Wire { CircuitName = "P0" };
		public Wire G1 { get; set; } = new Wire { CircuitName = "G1" };
		public Wire P1 { get; set; } = new Wire { CircuitName = "P1" };
		public Wire G2 { get; set; } = new Wire { CircuitName = "G2" };
		public Wire P2 { get; set; } = new Wire { CircuitName = "P2" };
		public Wire G3 { get; set; } = new Wire { CircuitName = "G3" };
		public Wire P3 { get; set; } = new Wire { CircuitName = "P3" };

		public double Cnx(int timing)
		{
			RunIteration(timing);
			return Gates[15].Output(timing);
		}

		public double Cny(int timing)
		{
			RunIteration(timing);
			return Gates[16].Output(timing);
		}

		public double Cnz(int timing)
		{
			RunIteration(timing);
			return Gates[17].Output(timing);
		}

		public double G(int timing)
		{
			RunIteration(timing);
			return Gates[18].Output(timing);
		}

		public double P(int timing)
		{
			RunIteration(timing);
			return Gates[14].Output(timing);
		}

		public TTL74182(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) { CircuitName = "G0" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G1" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G2" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G3" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G4" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G5" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G6" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G7" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G8" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G9" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G10" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G11" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G12" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G13" });
			Gates.Add(new OrGate(gateType, 4) { CircuitName = "G14" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G15" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G16" });
			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G17" });
			Gates.Add(new OrGate(gateType, 4) { CircuitName = "G18" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[0].Inputs[0],
				Name = "Cn -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[1].Inputs[0],
				Name = "G0 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[2].Inputs[1],
				Name = "G0 -> G2-1"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[4].Inputs[0],
				Name = "G0 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[5].Inputs[1],
				Name = "G0 -> G5-1"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[8].Inputs[0],
				Name = "G0 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[9].Inputs[1],
				Name = "G0 -> G9-1"
			});

			Connections.Add(new Connection
			{
				Source = G0,
				Termination = Gates[13].Inputs[0],
				Name = "G0 -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = P0,
				Termination = Gates[1].Inputs[1],
				Name = "P0 -> G1-1"
			});

			Connections.Add(new Connection
			{
				Source = P0,
				Termination = Gates[4].Inputs[2],
				Name = "P0 -> G4-2"
			});

			Connections.Add(new Connection
			{
				Source = P0,
				Termination = Gates[8].Inputs[3],
				Name = "P0 -> G8-3"
			});

			Connections.Add(new Connection
			{
				Source = P0,
				Termination = Gates[14].Inputs[0],
				Name = "P0 -> G14-0"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[3].Inputs[0],
				Name = "G1 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[4].Inputs[1],
				Name = "G1 -> G4-1"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[5].Inputs[2],
				Name = "G1 -> G5-2"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[7].Inputs[0],
				Name = "G1 -> G7-0"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[8].Inputs[1],
				Name = "G1 -> G8-1"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[9].Inputs[2],
				Name = "G1 -> G9-2"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[12].Inputs[0],
				Name = "G1 -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = G1,
				Termination = Gates[13].Inputs[1],
				Name = "G1 -> G13-1"
			});

			Connections.Add(new Connection
			{
				Source = P1,
				Termination = Gates[3].Inputs[1],
				Name = "P1 -> G3-1"
			});

			Connections.Add(new Connection
			{
				Source = P1,
				Termination = Gates[7].Inputs[2],
				Name = "P1 -> G7-2"
			});

			Connections.Add(new Connection
			{
				Source = P1,
				Termination = Gates[14].Inputs[1],
				Name = "P1 -> G14-1"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[6].Inputs[0],
				Name = "G2 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[7].Inputs[1],
				Name = "G2 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[8].Inputs[2],
				Name = "G2 -> G8-2"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[9].Inputs[3],
				Name = "G2 -> G9-3"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[11].Inputs[0],
				Name = "G2 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[12].Inputs[1],
				Name = "G2 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = G2,
				Termination = Gates[13].Inputs[2],
				Name = "G2 -> G13-2"
			});

			Connections.Add(new Connection
			{
				Source = P2,
				Termination = Gates[6].Inputs[1],
				Name = "P2 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = P2,
				Termination = Gates[11].Inputs[2],
				Name = "P2 -> G11-2"
			});

			Connections.Add(new Connection
			{
				Source = P2,
				Termination = Gates[14].Inputs[2],
				Name = "P2 -> G14-2"
			});

			Connections.Add(new Connection
			{
				Source = G3,
				Termination = Gates[10].Inputs[0],
				Name = "G3 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = G3,
				Termination = Gates[11].Inputs[1],
				Name = "G3 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = G3,
				Termination = Gates[12].Inputs[2],
				Name = "G3 -> G12-2"
			});

			Connections.Add(new Connection
			{
				Source = G3,
				Termination = Gates[13].Inputs[3],
				Name = "G3 -> G13-3"
			});

			Connections.Add(new Connection
			{
				Source = P3,
				Termination = Gates[10].Inputs[1],
				Name = "P3 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = P3,
				Termination = Gates[14].Inputs[3],
				Name = "P3 -> G14-3"
			});

			#endregion

			#region Gate 0 outputs

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[2].Inputs[0],
				Name = "G0 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[5].Inputs[0],
				Name = "G0 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[9].Inputs[0],
				Name = "G0 -> G9-0"
			});

			#endregion

			#region Gate 1 outputs

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[15].Inputs[0],
				Name = "G1 -> G15-0"
			});

			#endregion

			#region Gate 2 outputs

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[15].Inputs[1],
				Name = "G2 -> G15-1"
			});

			#endregion

			#region Gate 3 outputs

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[16].Inputs[0],
				Name = "G3 -> G16-0"
			});

			#endregion

			#region Gate 4 outputs

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[16].Inputs[1],
				Name = "G4 -> G16-1"
			});

			#endregion

			#region Gate 5 outputs

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[16].Inputs[2],
				Name = "G5 -> G16-2"
			});

			#endregion

			#region Gate 6 outputs

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[17].Inputs[0],
				Name = "G6 -> G17-0"
			});

			#endregion

			#region Gate 7 outputs

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[17].Inputs[1],
				Name = "G7 -> G17-1"
			});

			#endregion

			#region Gate 8 outputs

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[17].Inputs[2],
				Name = "G8 -> G17-2"
			});

			#endregion

			#region Gate 9 outputs

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[17].Inputs[3],
				Name = "G9 -> G17-3"
			});

			#endregion

			#region Gate 10 outputs

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[18].Inputs[0],
				Name = "G10 -> G18-0"
			});

			#endregion

			#region Gate 11 outputs

			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[18].Inputs[1],
				Name = "G11 -> G18-1"
			});

			#endregion

			#region Gate 12 outputs

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[18].Inputs[2],
				Name = "G12 -> G18-2"
			});

			#endregion

			#region Gate 13 outputs

			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[18].Inputs[3],
				Name = "G13 -> G18-3"
			});

			#endregion
		}
	}
}
