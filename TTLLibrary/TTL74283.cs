using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74283 :Circuit 
	{
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire B2 { get; set; } = new Wire { CircuitName = "B2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire B3 { get; set; } = new Wire { CircuitName = "B3" };
		public Wire A4 { get; set; } = new Wire { CircuitName = "A4" };
		public Wire B4 { get; set; } = new Wire { CircuitName = "B4" };
		public Wire Cin { get; set; } = new Wire { CircuitName = "Cin" };

		public double S1(int timing)
		{
			RunIteration(timing);
			return Gates[32].Output(timing);
		}

		public double S2(int timing)
		{
			RunIteration(timing);
			return Gates[33].Output(timing);
		}

		public double S3(int timing)
		{
			RunIteration(timing);
			return Gates[34].Output(timing);
		}

		public double S4(int timing)
		{
			RunIteration(timing);
			return Gates[35].Output(timing);
		}

		public double Cout(int timing)
		{
			RunIteration(timing);
			return Gates[31].Output(timing);
		}

		public TTL74283(TTLGateTypeEnum gateType)
		{
			Name = "4-bit adder";

			Gates.Add(new Inverter(gateType) { CircuitName = "G0" });
			Gates.Add(new NorGate(gateType,2) { CircuitName = "G1" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G2" });

			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G3" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G4" });

			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G5" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G6" });

			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G7" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G8" });

			Gates.Add(new Inverter(gateType) { CircuitName = "G9" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G10" });
			Gates[10].Inputs[1].InputInverted = true;


			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G11" });
			Gates.Add(new LogicLibrary.Buffer(gateType) { CircuitName = "G12" });

			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G13" });
			Gates[13].Inputs[1].InputInverted = true;
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G14" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G15" });
			Gates.Add(new LogicLibrary.Buffer(gateType) { CircuitName = "G16" });

			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G17" });
			Gates[17].Inputs[1].InputInverted = true;
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G18" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G19" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G20" });
			Gates.Add(new LogicLibrary.Buffer(gateType) { CircuitName = "G21" });

			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G22" });
			Gates[22].Inputs[1].InputInverted = true;
			Gates.Add(new AndGate(gateType, 5) { CircuitName = "G23" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G24" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G25" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G26" });
			Gates.Add(new LogicLibrary.Buffer(gateType) { CircuitName = "G27" });

			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G28" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G29" });
			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G30" });
			Gates.Add(new NorGate(gateType, 5) { CircuitName = "G31" });

			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G32" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G33" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G34" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G35" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = Cin,
				Termination = Gates[0].Inputs[0],
				Name = "Cin -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[1].Inputs[1],
				Name = "A1 -> G1-1"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[2].Inputs[0],
				Name = "A1 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[1].Inputs[0],
				Name = "B1 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[2].Inputs[1],
				Name = "B1 -> G2-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[3].Inputs[1],
				Name = "A2 -> G3-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[4].Inputs[0],
				Name = "A2 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[3].Inputs[0],
				Name = "B2 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[4].Inputs[1],
				Name = "B2 -> G4-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[5].Inputs[1],
				Name = "A3 -> G5-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[6].Inputs[0],
				Name = "A3 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[5].Inputs[0],
				Name = "B3 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[6].Inputs[1],
				Name = "B3 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = A4,
				Termination = Gates[7].Inputs[1],
				Name = "A4 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = A4,
				Termination = Gates[8].Inputs[0],
				Name = "A4 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = B4,
				Termination = Gates[7].Inputs[0],
				Name = "B4 -> G7-0"
			});

			Connections.Add(new Connection
			{
				Source = B4,
				Termination = Gates[8].Inputs[1],
				Name = "B4 -> G8-1"
			});
			#endregion

			#region gate 0 output
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[9].Inputs[0],
				Name = "G0 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[11].Inputs[1],
				Name = "G0 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[14].Inputs[2],
				Name = "G0 -> G14-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[18].Inputs[3],
				Name = "G0 -> G18-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[23].Inputs[4],
				Name = "G0 -> G23-4"
			});
			#endregion

			#region gate 1 output
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[10].Inputs[1],
				Name = "G1 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[12].Inputs[0],
				Name = "G1 -> G12-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[15].Inputs[0],
				Name = "G1 -> G15-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[19].Inputs[0],
				Name = "G1 -> G19-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[24].Inputs[0],
				Name = "G1 -> G24-0"
			});
			#endregion

			#region gate 2 output
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[10].Inputs[0],
				Name = "G2 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[11].Inputs[0],
				Name = "G2 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[14].Inputs[1],
				Name = "G2 -> G14-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[18].Inputs[2],
				Name = "G2 -> G18-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[23].Inputs[3],
				Name = "G2 -> G23-3"
			});
			#endregion

			#region gate 3 output
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[13].Inputs[1],
				Name = "G3 -> G13-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[16].Inputs[0],
				Name = "G3 -> G16-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[20].Inputs[0],
				Name = "G3 -> G20-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[25].Inputs[0],
				Name = "G3 -> G25-0"
			});
			#endregion

			#region gate 4 output
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[13].Inputs[0],
				Name = "G4 -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[14].Inputs[0],
				Name = "G4 -> G14-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[15].Inputs[1],
				Name = "G4 -> G15-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[18].Inputs[1],
				Name = "G4 -> G18-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[19].Inputs[2],
				Name = "G4 -> G19-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[23].Inputs[2],
				Name = "G4 -> G23-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[24].Inputs[3],
				Name = "G4 -> G24-3"
			});
			#endregion

			#region gate 5 output
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[17].Inputs[1],
				Name = "G5 -> G17-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[21].Inputs[0],
				Name = "G5 -> G21-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[26].Inputs[0],
				Name = "G5 -> G26-0"
			});
			#endregion

			#region gate 6 output
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[17].Inputs[0],
				Name = "G6 -> G17-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[18].Inputs[0],
				Name = "G6 -> G18-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[19].Inputs[1],
				Name = "G6 -> G19-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[20].Inputs[1],
				Name = "G6 -> G20-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[23].Inputs[1],
				Name = "G6 -> G23-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[24].Inputs[2],
				Name = "G6 -> G24-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[25].Inputs[2],
				Name = "G6 -> G25-2"
			});
			#endregion

			#region gate 7 output
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[22].Inputs[1],
				Name = "G7 -> G22-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[27].Inputs[0],
				Name = "G7 -> G27-0"
			});
			#endregion

			#region gate 8 output
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[22].Inputs[0],
				Name = "G8 -> G22-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[23].Inputs[0],
				Name = "G8 -> G23-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[24].Inputs[1],
				Name = "G8 -> G24-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[25].Inputs[1],
				Name = "G8 -> G25-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[26].Inputs[1],
				Name = "G8 -> G26-1"
			});
			#endregion

			#region gate 9 output
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[32].Inputs[1],
				Name = "G9 -> G32-1"
			});
			#endregion

			#region gate 10 output
			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[32].Inputs[0],
				Name = "G10 -> G32-0"
			});
			#endregion

			#region gate 11 output
			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[28].Inputs[1],
				Name = "G11 -> G28-1"
			});
			#endregion

			#region gate 12 output
			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[28].Inputs[0],
				Name = "G12 -> G28-0"
			});
			#endregion

			#region gate 13 output
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[33].Inputs[0],
				Name = "G13 -> G33-0"
			});
			#endregion

			#region gate 14 output
			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[29].Inputs[2],
				Name = "G14 -> G29-2"
			});
			#endregion

			#region gate 15 output
			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[29].Inputs[1],
				Name = "G15 -> G29-1"
			});
			#endregion

			#region gate 16 output
			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[29].Inputs[0],
				Name = "G16 -> G29-0"
			});
			#endregion

			#region gate 17 output
			Connections.Add(new Connection
			{
				Source = Gates[17],
				Termination = Gates[34].Inputs[0],
				Name = "G17 -> G34-0"
			});
			#endregion

			#region gate 18 output
			Connections.Add(new Connection
			{
				Source = Gates[18],
				Termination = Gates[30].Inputs[3],
				Name = "G18 -> G30-3"
			});
			#endregion

			#region gate 19 output
			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[30].Inputs[2],
				Name = "G19 -> G30-2"
			});
			#endregion

			#region gate 20 output
			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[30].Inputs[1],
				Name = "G20 -> G30-1"
			});
			#endregion

			#region gate 21 output
			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[30].Inputs[0],
				Name = "G21 -> G30-0"
			});
			#endregion

			#region gate 22 output
			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[35].Inputs[0],
				Name = "G22 -> G35-0"
			});
			#endregion

			#region gate 23 output
			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[31].Inputs[4],
				Name = "G23 -> G31-4"
			});
			#endregion

			#region gate 24 output
			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[31].Inputs[3],
				Name = "G24 -> G31-3"
			});
			#endregion

			#region gate 25 output
			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[31].Inputs[2],
				Name = "G25 -> G31-2"
			});
			#endregion

			#region gate 26 output
			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[31].Inputs[1],
				Name = "G26 -> G31-1"
			});
			#endregion

			#region gate 27 output
			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[31].Inputs[0],
				Name = "G27 -> G31-0"
			});
			#endregion

			#region gate 28 output
			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[33].Inputs[1],
				Name = "G28 -> G33-1"
			});
			#endregion

			#region gate 29 output
			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[34].Inputs[1],
				Name = "G29 -> G34-1"
			});
			#endregion

			#region gate 30 output
			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[35].Inputs[1],
				Name = "G30 -> G35-1"
			});
			#endregion
		}
	}
}
