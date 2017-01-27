using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74181_alternate : Circuit
	{
		public Wire S0 { get; set; } = new Wire { CircuitName = "S0" };
		public Wire S1 { get; set; } = new Wire { CircuitName = "S1" };
		public Wire S2 { get; set; } = new Wire { CircuitName = "S2" };
		public Wire S3 { get; set; } = new Wire { CircuitName = "S3" };
		public Wire A0 { get; set; } = new Wire { CircuitName = "A0" };
		public Wire B0 { get; set; } = new Wire { CircuitName = "B0" };
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire B2 { get; set; } = new Wire { CircuitName = "B2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire B3 { get; set; } = new Wire { CircuitName = "B3" };
		public Wire Cn { get; set; } = new Wire { CircuitName = "Cn" };
		public Wire M { get; set; } = new Wire { CircuitName = "M" };

		public double GorT(int timing)
		{
			return Gates[53].Output(timing);
		}

		public double Cn4(int timing)
		{
			return Gates[57].Output(timing);
		}

		public double F3(int timing)
		{
			return Gates[58].Output(timing);
		}

		public double F2(int timing)
		{
			return Gates[59].Output(timing);
		}

		public double AequalsB(int timing)
		{
			return Gates[62].Output(timing);
		}

		public double F1(int timing)
		{
			return Gates[60].Output(timing);
		}

		public double F0(int timing)
		{
			return Gates[61].Output(timing);
		}

		public TTL74181_alternate(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) { CircuitName = "G0" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G1" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G2" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G3" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G4" });

			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G5" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G6" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G7" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G8" });
			Gates.Add(new AndGate(gateType, 1) { CircuitName = "G9" });

			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G10" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G11" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G12" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G13" });
			Gates.Add(new AndGate(gateType, 1) { CircuitName = "G14" });

			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G15" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G16" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G17" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G18" });
			Gates.Add(new AndGate(gateType, 1) { CircuitName = "G19" });

			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G20" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G21" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G22" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G23" });
			Gates.Add(new AndGate(gateType, 1) { CircuitName = "G24" });

			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G25" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G26" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G27" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G28" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G29" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G30" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G31" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G32" });

			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G33" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G34" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G35" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G36" });

			Gates.Add(new AndGate(gateType, 1) { CircuitName = "G37" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G38" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G39" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G40" });
			Gates.Add(new NandGate(gateType, 5) { CircuitName = "G41" });
			Gates.Add(new NandGate(gateType, 4) { CircuitName = "G42" });

			Gates.Add(new AndGate(gateType, 5) { CircuitName = "G43" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G44" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G45" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G46" });

			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G47" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G48" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G49" });

			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G50" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G51" });

			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G52" });

			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G53" });
			Gates.Add(new NorGate(gateType, 4) { CircuitName = "G54" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G55" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G56" });

			Gates.Add(new NotOrGate(gateType, 2) { CircuitName = "G57" }); // special inverted input or gate

			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G58" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G59" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G60" });
			Gates.Add(new XorGate(gateType, 2) { CircuitName = "G61" });

			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G62" });

			Gates.Add(new Inverter(gateType) { CircuitName = "G63" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G64" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G65" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G66" });
			#region inputs

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[8].Inputs[0],
				Name = "S0 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[13].Inputs[0],
				Name = "S0 -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[18].Inputs[0],
				Name = "S0 -> G18-0"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[23].Inputs[0],
				Name = "S0 -> G23-0"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[7].Inputs[1],
				Name = "S1 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[12].Inputs[1],
				Name = "S1 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[17].Inputs[1],
				Name = "S1 -> G17-1"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[22].Inputs[1],
				Name = "S1 -> G22-1"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				Termination = Gates[6].Inputs[1],
				Name = "S2 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				Termination = Gates[11].Inputs[1],
				Name = "S2 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				Termination = Gates[16].Inputs[1],
				Name = "S2 -> G16-1"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				Termination = Gates[21].Inputs[1],
				Name = "S2 -> G21-1"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				Termination = Gates[5].Inputs[1],
				Name = "S3 -> G5-1"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				Termination = Gates[10].Inputs[1],
				Name = "S3 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				Termination = Gates[15].Inputs[1],
				Name = "S3 -> G15-1"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				Termination = Gates[20].Inputs[1],
				Name = "S3 -> G20-1"
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
				Termination = Gates[0].Inputs[0],
				Name = "B3 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[8].Inputs[1],
				Name = "B3 -> G8-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[5].Inputs[2],
				Name = "A3 -> G5-2"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[6].Inputs[0],
				Name = "A3 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[9].Inputs[0],
				Name = "A3 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[10].Inputs[0],
				Name = "B2 -> G10-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[1].Inputs[0],
				Name = "B2 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[13].Inputs[1],
				Name = "B2 -> G13-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[10].Inputs[2],
				Name = "A2 -> G10-2"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[11].Inputs[0],
				Name = "A2 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[14].Inputs[0],
				Name = "A2 -> G14-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[15].Inputs[0],
				Name = "B1 -> G15-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[2].Inputs[0],
				Name = "B1 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[18].Inputs[1],
				Name = "B1 -> G18-1"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[15].Inputs[2],
				Name = "A1 -> G15-2"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[16].Inputs[0],
				Name = "A1 -> G16-0"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[19].Inputs[0],
				Name = "A1 -> G19-0"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[20].Inputs[0],
				Name = "B0 -> G20-0"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[3].Inputs[0],
				Name = "B0 -> G3-0"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[23].Inputs[1],
				Name = "B0 -> G23-1"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[20].Inputs[2],
				Name = "A0 -> G20-2"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[21].Inputs[0],
				Name = "A0 -> G21-0"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[24].Inputs[0],
				Name = "A0 -> G24-0"
			});

			Connections.Add(new Connection
			{
				Source = M,
				Termination = Gates[4].Inputs[0],
				Name = "M -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[41].Inputs[4],
				Name = "Cn -> G41-4"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[43].Inputs[0],
				Name = "Cn -> G43-0"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[47].Inputs[0],
				Name = "Cn -> G47-0"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[50].Inputs[0],
				Name = "Cn -> G50-0"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[52].Inputs[0],
				Name = "Cn -> G47-3"
			});

			#endregion

			#region Gate 0 outputs
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[6].Inputs[2],
				Name = "G0 -> G6-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[7].Inputs[0],
				Name = "G0 -> G7-0"
			});
			#endregion

			#region Gate 1 outputs
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[11].Inputs[2],
				Name = "G1 -> G11-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[12].Inputs[0],
				Name = "G1 -> 12-0"
			});
			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[16].Inputs[2],
				Name = "G2 -> G16-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[17].Inputs[0],
				Name = "G2 -> G17-0"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[21].Inputs[2],
				Name = "G3 -> G21-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[22].Inputs[0],
				Name = "G3 -> G22-0"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[43].Inputs[4],
				Name = "G4 -> G43-4"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[44].Inputs[3],
				Name = "G4 -> G44-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[45].Inputs[2],
				Name = "G4 -> G45-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[46].Inputs[1],
				Name = "G4 -> G46-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[47].Inputs[3],
				Name = "G4 -> G47-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[48].Inputs[2],
				Name = "G4 -> G48-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[49].Inputs[1],
				Name = "G4 -> G49-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[50].Inputs[2],
				Name = "G4 -> G50-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[51].Inputs[1],
				Name = "G4 -> G51-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[52].Inputs[1],
				Name = "G4 -> G52-1"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[25].Inputs[0],
				Name = "G5 -> G25-0"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[25].Inputs[1],
				Name = "G6 -> G25-1"
			});
			#endregion

			#region Gate 7 outputs
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[26].Inputs[0],
				Name = "G7 -> G26-0"
			});
			#endregion

			#region Gate 8 outputs
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[26].Inputs[1],
				Name = "G8 -> G26-1"
			});
			#endregion

			#region Gate 9 outputs
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[26].Inputs[2],
				Name = "G9 -> G26-2"
			});
			#endregion

			#region Gate 10 outputs
			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[27].Inputs[0],
				Name = "G10 -> G27-0"
			});
			#endregion

			#region Gate 11 outputs
			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[27].Inputs[1],
				Name = "G11 -> G27-1"
			});
			#endregion

			#region Gate 12 outputs
			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[28].Inputs[0],
				Name = "G12 -> G28-0"
			});
			#endregion

			#region Gate 13 outputs
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[28].Inputs[1],
				Name = "G13 -> G28-1"
			});
			#endregion

			#region Gate 14 outputs
			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[28].Inputs[2],
				Name = "G14 -> G28-2"
			});
			#endregion

			#region Gate 15 outputs
			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[29].Inputs[0],
				Name = "G15 -> G29-0"
			});
			#endregion

			#region Gate 16 outputs
			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[29].Inputs[1],
				Name = "G16 -> G29-1"
			});
			#endregion

			#region Gate 17 outputs
			Connections.Add(new Connection
			{
				Source = Gates[17],
				Termination = Gates[30].Inputs[0],
				Name = "G17 -> G30-0"
			});
			#endregion

			#region Gate 18 outputs
			Connections.Add(new Connection
			{
				Source = Gates[18],
				Termination = Gates[30].Inputs[1],
				Name = "G18 -> G30-1"
			});
			#endregion

			#region Gate 19 outputs
			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[30].Inputs[2],
				Name = "G19 -> G30-2"
			});
			#endregion

			#region Gate 20 outputs
			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[31].Inputs[0],
				Name = "G20 -> G31-0"
			});
			#endregion

			#region Gate 21 outputs
			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[31].Inputs[1],
				Name = "G21 -> G31-1"
			});
			#endregion

			#region Gate 22 outputs
			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[32].Inputs[0],
				Name = "G22 -> G32-0"
			});
			#endregion

			#region Gate 23 outputs
			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[32].Inputs[1],
				Name = "G23 -> G32-1"
			});
			#endregion

			#region Gate 24 outputs
			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[32].Inputs[2],
				Name = "G24 -> G32-2"
			});
			#endregion

			#region Gate 25 outputs
			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[38].Inputs[0],
				Name = "G25 -> G38-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[33].Inputs[0],
				Name = "G25 -> G33-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[39].Inputs[0],
				Name = "G25 -> G39-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[40].Inputs[0],
				Name = "G25 -> G40-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[41].Inputs[0],
				Name = "G25 -> G41-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[42].Inputs[0],
				Name = "G25 -> G42-0"
			});
			#endregion

			#region Gate 26 outputs
			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[37].Inputs[0],
				Name = "G26 -> G37-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[63].Inputs[0],
				Name = "G26 -> G63-0"
			});
			#endregion

			#region Gate 27 outputs
			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[34].Inputs[0],
				Name = "G27 -> G34-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[39].Inputs[1],
				Name = "G27 -> G39-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[40].Inputs[1],
				Name = "G27 -> G40-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[41].Inputs[1],
				Name = "G27 -> G41-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[42].Inputs[1],
				Name = "G27 -> G42-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[43].Inputs[3],
				Name = "G27 -> G43-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[44].Inputs[1],
				Name = "G27 -> G44-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[45].Inputs[0],
				Name = "G27 -> G45-0"
			});
			#endregion

			#region Gate 28 outputs
			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[38].Inputs[1],
				Name = "G28 -> G38-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[64].Inputs[0],
				Name = "G28 -> G64-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[46].Inputs[0],
				Name = "G28 -> G46-0"
			});
			#endregion

			#region Gate 29 outputs
			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[47].Inputs[2],
				Name = "G29 -> G47-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[48].Inputs[0],
				Name = "G29 -> G48-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[40].Inputs[2],
				Name = "G29 -> G40-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[35].Inputs[0],
				Name = "G29 -> G35-0"
			});
			#endregion

			#region Gate 30 outputs
			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[39].Inputs[2],
				Name = "G30 -> G39-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[45].Inputs[1],
				Name = "G30 -> G45-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[49].Inputs[0],
				Name = "G30 -> G49-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[65].Inputs[0],
				Name = "G30 -> G65-0"
			});
			#endregion

			#region Gate 31 outputs
			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[41].Inputs[3],
				Name = "G31 -> G41-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[42].Inputs[3],
				Name = "G31 -> G42-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[43].Inputs[1],
				Name = "G31 -> G43-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[44].Inputs[0],
				Name = "G31 -> G44-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[47].Inputs[1],
				Name = "G31 -> G47-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[50].Inputs[1],
				Name = "G31 -> G50-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[36].Inputs[0],
				Name = "G31 -> G36-0"
			});
			#endregion

			#region Gate 32 outputs
			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[40].Inputs[3],
				Name = "G32 -> G40-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[41].Inputs[2],
				Name = "G32 -> G41-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[42].Inputs[2],
				Name = "G32 -> G42-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[43].Inputs[2],
				Name = "G32 -> G43-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[44].Inputs[2],
				Name = "G32 -> G44-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[48].Inputs[1],
				Name = "G32 -> G48-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[51].Inputs[0],
				Name = "G32 -> G51-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[66].Inputs[0],
				Name = "G32 -> G66-0"
			});
			#endregion

			#region Gate 33 outputs
			Connections.Add(new Connection
			{
				Source = Gates[33],
				Termination = Gates[58].Inputs[0],
				Name = "G33 -> G58-0"
			});
			#endregion

			#region Gate 34 outputs
			Connections.Add(new Connection
			{
				Source = Gates[34],
				Termination = Gates[59].Inputs[0],
				Name = "G34 -> G59-0"
			});
			#endregion

			#region Gate 35 outputs
			Connections.Add(new Connection
			{
				Source = Gates[35],
				Termination = Gates[60].Inputs[0],
				Name = "G35 -> G60-0"
			});
			#endregion

			#region Gate 36 outputs
			Connections.Add(new Connection
			{
				Source = Gates[36],
				Termination = Gates[61].Inputs[0],
				Name = "G36 -> G61-0"
			});
			#endregion

			#region Gate 37 outputs
			Connections.Add(new Connection
			{
				Source = Gates[37],
				Termination = Gates[53].Inputs[0],
				Name = "G37 -> G53-0"
			});
			#endregion

			#region Gate 38 outputs
			Connections.Add(new Connection
			{
				Source = Gates[38],
				Termination = Gates[53].Inputs[1],
				Name = "G38 -> G53-1"
			});
			#endregion

			#region Gate 39 outputs
			Connections.Add(new Connection
			{
				Source = Gates[39],
				Termination = Gates[53].Inputs[2],
				Name = "G39 -> G53-2"
			});
			#endregion

			#region Gate 40 outputs
			Connections.Add(new Connection
			{
				Source = Gates[40],
				Termination = Gates[53].Inputs[3],
				Name = "G40 -> G53-3"
			});
			#endregion

			#region Gate 41 outputs
			Connections.Add(new Connection
			{
				Source = Gates[41],
				Termination = Gates[57].Inputs[1],
				Name = "G41 -> G57-1"
			});
			#endregion

			#region Gate 43 outputs
			Connections.Add(new Connection
			{
				Source = Gates[43],
				Termination = Gates[54].Inputs[0],
				Name = "G43 -> G54-0"
			});
			#endregion

			#region Gate 44 outputs
			Connections.Add(new Connection
			{
				Source = Gates[44],
				Termination = Gates[54].Inputs[1],
				Name = "G44 -> G54-1"
			});
			#endregion

			#region Gate 45 outputs
			Connections.Add(new Connection
			{
				Source = Gates[45],
				Termination = Gates[54].Inputs[2],
				Name = "G45 -> G54-2"
			});
			#endregion

			#region Gate 46 outputs
			Connections.Add(new Connection
			{
				Source = Gates[46],
				Termination = Gates[54].Inputs[3],
				Name = "G46 -> G54-3"
			});
			#endregion

			#region Gate 47 outputs
			Connections.Add(new Connection
			{
				Source = Gates[47],
				Termination = Gates[55].Inputs[0],
				Name = "G47 -> G55-0"
			});
			#endregion

			#region Gate 48 outputs
			Connections.Add(new Connection
			{
				Source = Gates[48],
				Termination = Gates[55].Inputs[1],
				Name = "G48 -> G55-1"
			});
			#endregion

			#region Gate 49 outputs
			Connections.Add(new Connection
			{
				Source = Gates[49],
				Termination = Gates[55].Inputs[2],
				Name = "G49 -> G55-2"
			});
			#endregion

			#region Gate 50 outputs
			Connections.Add(new Connection
			{
				Source = Gates[50],
				Termination = Gates[56].Inputs[0],
				Name = "G50 -> G56-0"
			});
			#endregion

			#region Gate 51 outputs
			Connections.Add(new Connection
			{
				Source = Gates[51],
				Termination = Gates[56].Inputs[1],
				Name = "G51 -> G56-1"
			});
			#endregion

			#region Gate 52 outputs
			Connections.Add(new Connection
			{
				Source = Gates[52],
				Termination = Gates[61].Inputs[1],
				Name = "G52 -> G61-1"
			});
			#endregion

			#region Gate 53 outputs
			Connections.Add(new Connection
			{
				Source = Gates[53],
				Termination = Gates[57].Inputs[0],
				Name = "G53 -> G57-0"
			});
			#endregion

			#region Gate 54 outputs
			Connections.Add(new Connection
			{
				Source = Gates[54],
				Termination = Gates[58].Inputs[1],
				Name = "G54 -> G58-1"
			});
			#endregion

			#region Gate 55 outputs
			Connections.Add(new Connection
			{
				Source = Gates[55],
				Termination = Gates[59].Inputs[1],
				Name = "G55 -> G59-1"
			});
			#endregion

			#region Gate 56 outputs
			Connections.Add(new Connection
			{
				Source = Gates[56],
				Termination = Gates[60].Inputs[1],
				Name = "G56 -> G60-1"
			});
			#endregion

			#region Gate 58 outputs
			Connections.Add(new Connection
			{
				Source = Gates[58],
				Termination = Gates[62].Inputs[0],
				Name = "G58 -> G62-0"
			});
			#endregion

			#region Gate 59 outputs
			Connections.Add(new Connection
			{
				Source = Gates[59],
				Termination = Gates[62].Inputs[1],
				Name = "G59 -> G62-1"
			});
			#endregion

			#region Gate 60 outputs
			Connections.Add(new Connection
			{
				Source = Gates[60],
				Termination = Gates[62].Inputs[2],
				Name = "G60 -> G62-2"
			});
			#endregion

			#region Gate 61 outputs
			Connections.Add(new Connection
			{
				Source = Gates[61],
				Termination = Gates[62].Inputs[3],
				Name = "G61 -> G62-3"
			});
			#endregion

			#region Gate 63 outputs
			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[33].Inputs[1],
				Name = "G63 -> G33-1"
			});
			#endregion

			#region Gate 64 outputs
			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[34].Inputs[1],
				Name = "G64 -> G34-1"
			});
			#endregion

			#region Gate 65 outputs
			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[35].Inputs[1],
				Name = "G65 -> G35-1"
			});
			#endregion

			#region Gate 66 outputs
			Connections.Add(new Connection
			{
				Source = Gates[66],
				Termination = Gates[36].Inputs[1],
				Name = "G66 -> G36-1"
			});
			#endregion
		}
	}
}
