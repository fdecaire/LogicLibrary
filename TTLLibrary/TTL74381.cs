using LogicLibrary;

namespace TTLLibrary
{
	public class TTL74381 : Circuit
	{
		public Wire S0 { get; set; } = new Wire { CircuitName = "S0" };
		public Wire S1 { get; set; } = new Wire { CircuitName = "S1" };
		public Wire S2 { get; set; } = new Wire { CircuitName = "S2" };
		public Wire Cn { get; set; } = new Wire { CircuitName = "Cn" };
		public Wire A0 { get; set; } = new Wire { CircuitName = "A0" };
		public Wire B0 { get; set; } = new Wire { CircuitName = "B0" };
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire B2 { get; set; } = new Wire { CircuitName = "B2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire B3 { get; set; } = new Wire { CircuitName = "B3" };

		public double F0(int timing)
		{
			RunIteration(timing);
			return Gates[96].Output(timing);
		}

		public double F1(int timing)
		{
			RunIteration(timing);
			return Gates[97].Output(timing);
		}

		public double F2(int timing)
		{
			RunIteration(timing);
			return Gates[98].Output(timing);
		}

		public double F3(int timing)
		{
			RunIteration(timing);
			return Gates[99].Output(timing);
		}

		public double OVR(int timing)
		{
			RunIteration(timing);
			return Gates[100].Output(timing);
		}

		public double Cn4(int timing)
		{
			RunIteration(timing);
			return Gates[101].Output(timing);
		}

		public double P(int timing)
		{
			RunIteration(timing);
			return Gates[86].Output(timing);
		}

		public double G(int timing)
		{
			RunIteration(timing);
			return Gates[95].Output(timing);
		}

		public TTL74381(TTLGateTypeEnum gateType)
		{
			Gates.Add(new Inverter(gateType) {CircuitName = "G0"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G1"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G2"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G3"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G4"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G5"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G6"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G7"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G8"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G9"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G10"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G11"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G12"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G13"});
			Gates.Add(new NandGate(gateType, 3) {CircuitName = "G14"});
			Gates.Add(new NandGate(gateType, 3) {CircuitName = "G15"});
			Gates.Add(new NandGate(gateType, 3) {CircuitName = "G16"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G17"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G18"});

			Gates.Add(new NorGate(gateType, 3) {CircuitName = "G19"});
			Gates.Add(new NorGate(gateType, 3) {CircuitName = "G20"});
			Gates.Add(new NorGate(gateType, 2) {CircuitName = "G21"});
			Gates.Add(new OrGate(gateType, 2) {CircuitName = "G22"});

			Gates.Add(new Inverter(gateType) {CircuitName = "G23"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G24"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G25"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G26"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G27"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G28"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G29"});
			Gates.Add(new Inverter(gateType) {CircuitName = "G30"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G31"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G32"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G33"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G34"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G35"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G36"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G37"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G38"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G39"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G40"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G41"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G42"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G43"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G44"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G45"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G46"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G47"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G48"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G49"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G50"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G51"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G52"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G53"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G54"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G55"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G56"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G57"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G58"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G59"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G60"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G61"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G62"});

			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G63"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G64"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G65"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G66"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G67"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G68"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G69"});
			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G70"});

			Gates.Add(new NandGate(gateType, 2) {CircuitName = "G71"});

			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G72"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G73"});

			Gates.Add(new AndGate(gateType, 4) {CircuitName = "G74"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G75"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G76"});

			Gates.Add(new AndGate(gateType, 5) {CircuitName = "G77"});
			Gates.Add(new AndGate(gateType, 4) {CircuitName = "G78"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G79"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G80"});

			Gates.Add(new AndGate(gateType, 5) {CircuitName = "G81"});
			Gates.Add(new AndGate(gateType, 4) {CircuitName = "G82"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G83"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G84"});
			Gates.Add(new AndGate(gateType, 1) {CircuitName = "G85"});

			Gates.Add(new NandGate(gateType, 4) {CircuitName = "G86"});
			Gates.Add(new AndGate(gateType, 4) {CircuitName = "G87"});
			Gates.Add(new AndGate(gateType, 3) {CircuitName = "G88"});
			Gates.Add(new AndGate(gateType, 2) {CircuitName = "G89"});
			Gates.Add(new AndGate(gateType, 1) {CircuitName = "G90"});

			Gates.Add(new NorGate(gateType, 2) {CircuitName = "G91"});

			Gates.Add(new NorGate(gateType, 3) {CircuitName = "G92"});

			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G93"});

			Gates.Add(new NorGate(gateType, 5) {CircuitName = "G94"});

			Gates.Add(new NorGate(gateType, 4) {CircuitName = "G95"});

			Gates.Add(new XnorGate(gateType, 2) {CircuitName = "G96"});

			Gates.Add(new XnorGate(gateType, 2) {CircuitName = "G97"});

			Gates.Add(new XnorGate(gateType, 2) {CircuitName = "G98"});

			Gates.Add(new XnorGate(gateType, 2) {CircuitName = "G99"});

			Gates.Add(new XorGate(gateType, 2) {CircuitName = "G100"});

			Gates.Add(new Inverter(gateType) {CircuitName = "G101"});

			#region inputs

			Connections.Add(new Connection
			{
				Source = S0,
				Termination = Gates[0].Inputs[0],
				Name = "S0 -> G0-0"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				Termination = Gates[2].Inputs[0],
				Name = "S1 -> G2-0"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				Termination = Gates[4].Inputs[0],
				Name = "S2 -> G4-0"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[71].Inputs[1],
				Name = "Cn -> G71-1"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[72].Inputs[1],
				Name = "Cn -> G72-1"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[74].Inputs[1],
				Name = "Cn -> G74-1"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[77].Inputs[1],
				Name = "Cn -> G77-1"
			});

			Connections.Add(new Connection
			{
				Source = Cn,
				Termination = Gates[81].Inputs[0],
				Name = "Cn -> G81-1"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[23].Inputs[0],
				Name = "A0 -> G23-0"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[31].Inputs[1],
				Name = "A0 -> G31-1"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[32].Inputs[1],
				Name = "A0 -> G32-1"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[35].Inputs[1],
				Name = "A0 -> G35-1"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				Termination = Gates[36].Inputs[1],
				Name = "A0 -> G36-1"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[24].Inputs[0],
				Name = "B0 -> G24-0"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[32].Inputs[2],
				Name = "B0 -> G32-2"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[33].Inputs[2],
				Name = "B0 -> G33-2"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[36].Inputs[2],
				Name = "B0 -> G36-2"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				Termination = Gates[37].Inputs[2],
				Name = "B0 -> G37-2"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[25].Inputs[0],
				Name = "A1 -> G25-0"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[39].Inputs[1],
				Name = "A1 -> G39-1"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[40].Inputs[1],
				Name = "A1 -> G40-1"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[43].Inputs[1],
				Name = "A1 -> G43-1"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				Termination = Gates[44].Inputs[1],
				Name = "A1 -> G44-1"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[26].Inputs[0],
				Name = "B1 -> G26-0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[40].Inputs[2],
				Name = "B1 -> G40-2"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[41].Inputs[2],
				Name = "B1 -> G41-2"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[44].Inputs[2],
				Name = "B1 -> G44-2"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				Termination = Gates[45].Inputs[2],
				Name = "B1 -> G45-2"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[27].Inputs[0],
				Name = "A2 -> G27-0"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[47].Inputs[1],
				Name = "A2 -> G47-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[48].Inputs[1],
				Name = "A2 -> G48-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[51].Inputs[1],
				Name = "A2 -> G51-1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				Termination = Gates[52].Inputs[1],
				Name = "A2 -> G51-1"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[28].Inputs[0],
				Name = "B2 -> G28-0"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[48].Inputs[2],
				Name = "B2 -> G48-2"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[49].Inputs[2],
				Name = "B2 -> G49-2"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[52].Inputs[2],
				Name = "B2 -> G52-2"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				Termination = Gates[53].Inputs[2],
				Name = "B2 -> G53-2"
			});

			// ****
			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[29].Inputs[0],
				Name = "A3 -> G29-0"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[55].Inputs[1],
				Name = "A3 -> G55-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[56].Inputs[1],
				Name = "A3 -> G56-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[59].Inputs[1],
				Name = "A3 -> G59-1"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				Termination = Gates[60].Inputs[1],
				Name = "A3 -> G60-1"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[30].Inputs[0],
				Name = "B3 -> G30-0"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[56].Inputs[2],
				Name = "B3 -> G56-2"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[57].Inputs[2],
				Name = "B3 -> G57-2"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[60].Inputs[2],
				Name = "B3 -> G60-2"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				Termination = Gates[61].Inputs[2],
				Name = "B3 -> G61-2"
			});

			#endregion

			#region Gate 0 outputs

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[1].Inputs[0],
				Name = "G0 -> G1-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[7].Inputs[0],
				Name = "G0 -> G7-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[11].Inputs[0],
				Name = "G0 -> G11-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[16].Inputs[0],
				Name = "G0 -> G16-0"
			});

			#endregion

			#region Gate 1 outputs

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[6].Inputs[0],
				Name = "G1 -> G6-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[8].Inputs[0],
				Name = "G1 -> G8-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[9].Inputs[0],
				Name = "G1 -> G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[10].Inputs[0],
				Name = "G1 -> G10-0"
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
				Termination = Gates[14].Inputs[0],
				Name = "G1 -> G14-0"
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
				Termination = Gates[17].Inputs[0],
				Name = "G1 -> G17-0"
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
				Termination = Gates[6].Inputs[1],
				Name = "G2 -> G6-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[9].Inputs[1],
				Name = "G2 -> G9-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[13].Inputs[0],
				Name = "G2 -> G13-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[14].Inputs[1],
				Name = "G2 -> G14-1"
			});

			#endregion

			#region Gate 3 outputs

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[7].Inputs[1],
				Name = "G3 -> G7-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[8].Inputs[1],
				Name = "G3 -> G8-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[11].Inputs[1],
				Name = "G3 -> G11-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[12].Inputs[1],
				Name = "G3 -> G12-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[15].Inputs[1],
				Name = "G3 -> G15-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[16].Inputs[1],
				Name = "G3 -> G16-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[18].Inputs[0],
				Name = "G3 -> G18-0"
			});

			#endregion

			#region Gate 4 outputs

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[5].Inputs[0],
				Name = "G4 -> G5-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[6].Inputs[2],
				Name = "G4 -> G6-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[7].Inputs[2],
				Name = "G4 -> G7-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[14].Inputs[2],
				Name = "G4 -> G14-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[15].Inputs[2],
				Name = "G4 -> G15-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[16].Inputs[2],
				Name = "G4 -> G16-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[17].Inputs[1],
				Name = "G4 -> G17-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[18].Inputs[1],
				Name = "G4 -> G18-1"
			});

			#endregion

			#region Gate 5 outputs

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[8].Inputs[2],
				Name = "G5 -> G8-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[10].Inputs[1],
				Name = "G5 -> G10-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[13].Inputs[1],
				Name = "G5 -> G13-1"
			});

			#endregion

			#region Gate 6 outputs

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[19].Inputs[2],
				Name = "G6 -> G19-2"
			});

			#endregion

			#region Gate 7 outputs

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[19].Inputs[1],
				Name = "G7 -> G19-1"
			});

			#endregion

			#region Gate 8 outputs

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[19].Inputs[0],
				Name = "G8 -> G19-0"
			});

			#endregion

			#region Gate 9 outputs

			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[20].Inputs[2],
				Name = "G9 -> G20-2"
			});

			#endregion

			#region Gate 10 outputs

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[20].Inputs[1],
				Name = "G10 -> G20-1"
			});

			#endregion

			#region Gate 11 outputs

			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[20].Inputs[0],
				Name = "G11 -> G20-0"
			});

			#endregion

			#region Gate 12 outputs

			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[21].Inputs[1],
				Name = "G12 -> G21-1"
			});

			#endregion

			#region Gate 13 outputs

			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[21].Inputs[0],
				Name = "G13 -> G21-0"
			});

			#endregion

			#region Gate 14 outputs

			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[37].Inputs[0],
				Name = "G14 -> G37-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[45].Inputs[0],
				Name = "G14 -> G45-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[53].Inputs[0],
				Name = "G14 -> G53-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[61].Inputs[0],
				Name = "G14 -> G61-0"
			});

			#endregion

			#region Gate 15 outputs

			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[36].Inputs[0],
				Name = "G15 -> G36-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[44].Inputs[0],
				Name = "G15 -> G44-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[52].Inputs[0],
				Name = "G15 -> G52-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[60].Inputs[0],
				Name = "G15 -> G60-0"
			});

			#endregion

			#region Gate 16 outputs

			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[35].Inputs[0],
				Name = "G16 -> G35-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[43].Inputs[0],
				Name = "G16 -> G43-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[51].Inputs[0],
				Name = "G16 -> G51-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[59].Inputs[0],
				Name = "G16 -> G59-0"
			});

			#endregion

			#region Gate 17 outputs

			Connections.Add(new Connection
			{
				Source = Gates[17],
				Termination = Gates[22].Inputs[1],
				Name = "G17 -> G22-1"
			});

			#endregion

			#region Gate 18 outputs

			Connections.Add(new Connection
			{
				Source = Gates[18],
				Termination = Gates[22].Inputs[0],
				Name = "G18 -> G22-0"
			});

			#endregion

			#region Gate 19 outputs

			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[34].Inputs[0],
				Name = "G19 -> G34-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[42].Inputs[0],
				Name = "G19 -> G42-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[50].Inputs[0],
				Name = "G19 -> G50-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[58].Inputs[0],
				Name = "G19 -> G58-0"
			});

			#endregion

			#region Gate 20 outputs

			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[32].Inputs[0],
				Name = "G20 -> G32-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[40].Inputs[0],
				Name = "G20 -> G40-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[48].Inputs[0],
				Name = "G20 -> G48-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[56].Inputs[0],
				Name = "G20 -> G56-0"
			});

			#endregion

			#region Gate 21 outputs

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[31].Inputs[0],
				Name = "G21 -> G31-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[33].Inputs[0],
				Name = "G21 -> G33-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[39].Inputs[0],
				Name = "G21 -> G39-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[41].Inputs[0],
				Name = "G21 -> G41-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[47].Inputs[0],
				Name = "G21 -> G47-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[49].Inputs[0],
				Name = "G21 -> G49-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[55].Inputs[0],
				Name = "G21 -> G55-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[57].Inputs[0],
				Name = "G21 -> G57-0"
			});

			#endregion

			#region Gate 22 outputs

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[71].Inputs[0],
				Name = "G22 -> G71-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[72].Inputs[0],
				Name = "G22 -> G72-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[73].Inputs[0],
				Name = "G22 -> G73-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[74].Inputs[0],
				Name = "G22 -> G74-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[75].Inputs[0],
				Name = "G22 -> G75-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[76].Inputs[0],
				Name = "G22 -> G76-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[77].Inputs[0],
				Name = "G22 -> G77-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[78].Inputs[0],
				Name = "G22 -> G78-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[79].Inputs[2],
				Name = "G22 -> G79-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[80].Inputs[0],
				Name = "G22 -> G80-0"
			});

			#endregion

			#region Gate 23 outputs

			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[33].Inputs[1],
				Name = "G23 -> G33-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[34].Inputs[1],
				Name = "G23 -> G34-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[37].Inputs[1],
				Name = "G23 -> G37-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[38].Inputs[0],
				Name = "G23 -> G38-0"
			});

			#endregion

			#region Gate 24 outputs

			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[31].Inputs[2],
				Name = "G24 -> G31-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[34].Inputs[2],
				Name = "G24 -> G34-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[35].Inputs[2],
				Name = "G24 -> G35-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[38].Inputs[1],
				Name = "G24 -> G38-1"
			});

			#endregion

			#region Gate 25 outputs

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[41].Inputs[1],
				Name = "G25 -> G41-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[42].Inputs[1],
				Name = "G25 -> G42-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[45].Inputs[1],
				Name = "G25 -> G45-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[46].Inputs[0],
				Name = "G25 -> G46-0"
			});

			#endregion

			#region Gate 26 outputs

			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[39].Inputs[2],
				Name = "G26 -> G39-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[42].Inputs[2],
				Name = "G26 -> G42-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[43].Inputs[2],
				Name = "G26 -> G43-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[46].Inputs[1],
				Name = "G26 -> G46-1"
			});

			#endregion

			#region Gate 27 outputs

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[49].Inputs[1],
				Name = "G27 -> G49-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[50].Inputs[1],
				Name = "G27 -> G50-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[53].Inputs[1],
				Name = "G27 -> G53-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[54].Inputs[0],
				Name = "G27 -> G54-0"
			});

			#endregion

			#region Gate 28 outputs

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[47].Inputs[2],
				Name = "G28 -> G47-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[50].Inputs[2],
				Name = "G28 -> G50-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[51].Inputs[2],
				Name = "G28 -> G51-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[54].Inputs[1],
				Name = "G28 -> G54-1"
			});

			#endregion

			#region Gate 29 outputs

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[57].Inputs[1],
				Name = "G29 -> G57-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[58].Inputs[1],
				Name = "G29 -> G58-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[61].Inputs[1],
				Name = "G29 -> G61-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[62].Inputs[0],
				Name = "G29 -> G62-0"
			});

			#endregion

			#region Gate 30 outputs

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[55].Inputs[2],
				Name = "G30 -> G55-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[58].Inputs[2],
				Name = "G30 -> G58-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[59].Inputs[2],
				Name = "G30 -> G59-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[62].Inputs[1],
				Name = "G30 -> G62-1"
			});

			#endregion

			#region Gate 31 outputs

			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[63].Inputs[0],
				Name = "G31 -> G63-0"
			});

			#endregion

			#region Gate 32 outputs

			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[63].Inputs[1],
				Name = "G32 -> G63-1"
			});

			#endregion

			#region Gate 33 outputs

			Connections.Add(new Connection
			{
				Source = Gates[33],
				Termination = Gates[63].Inputs[2],
				Name = "G33 -> G63-2"
			});

			#endregion

			#region Gate 34 outputs

			Connections.Add(new Connection
			{
				Source = Gates[34],
				Termination = Gates[63].Inputs[3],
				Name = "G34 -> G63-3"
			});

			#endregion

			#region Gate 35 outputs

			Connections.Add(new Connection
			{
				Source = Gates[35],
				Termination = Gates[64].Inputs[0],
				Name = "G35 -> G64-0"
			});

			#endregion

			#region Gate 36 outputs

			Connections.Add(new Connection
			{
				Source = Gates[36],
				Termination = Gates[64].Inputs[1],
				Name = "G36 -> G64-1"
			});

			#endregion

			#region Gate 37 outputs

			Connections.Add(new Connection
			{
				Source = Gates[37],
				Termination = Gates[64].Inputs[2],
				Name = "G37 -> G64-2"
			});

			#endregion

			#region Gate 38 outputs

			Connections.Add(new Connection
			{
				Source = Gates[38],
				Termination = Gates[64].Inputs[3],
				Name = "G38 -> G64-3"
			});

			#endregion

			#region Gate 39 outputs

			Connections.Add(new Connection
			{
				Source = Gates[39],
				Termination = Gates[65].Inputs[0],
				Name = "G39 -> G65-0"
			});

			#endregion

			#region Gate 40 outputs

			Connections.Add(new Connection
			{
				Source = Gates[40],
				Termination = Gates[65].Inputs[1],
				Name = "G40 -> G65-1"
			});

			#endregion

			#region Gate 41 outputs

			Connections.Add(new Connection
			{
				Source = Gates[41],
				Termination = Gates[65].Inputs[2],
				Name = "G41 -> G65-2"
			});

			#endregion

			#region Gate 42 outputs

			Connections.Add(new Connection
			{
				Source = Gates[42],
				Termination = Gates[65].Inputs[3],
				Name = "G42 -> G65-3"
			});

			#endregion

			#region Gate 43 outputs

			Connections.Add(new Connection
			{
				Source = Gates[43],
				Termination = Gates[66].Inputs[0],
				Name = "G43 -> G66-0"
			});

			#endregion

			#region Gate 44 outputs

			Connections.Add(new Connection
			{
				Source = Gates[44],
				Termination = Gates[66].Inputs[1],
				Name = "G44 -> G66-1"
			});

			#endregion

			#region Gate 45 outputs

			Connections.Add(new Connection
			{
				Source = Gates[45],
				Termination = Gates[66].Inputs[2],
				Name = "G45 -> G66-2"
			});

			#endregion

			#region Gate 46 outputs

			Connections.Add(new Connection
			{
				Source = Gates[46],
				Termination = Gates[66].Inputs[3],
				Name = "G46 -> G66-3"
			});

			#endregion

			#region Gate 47 outputs

			Connections.Add(new Connection
			{
				Source = Gates[47],
				Termination = Gates[67].Inputs[0],
				Name = "G47 -> G67-0"
			});

			#endregion

			#region Gate 48 outputs

			Connections.Add(new Connection
			{
				Source = Gates[48],
				Termination = Gates[67].Inputs[1],
				Name = "G48 -> G67-1"
			});

			#endregion

			#region Gate 49 outputs

			Connections.Add(new Connection
			{
				Source = Gates[49],
				Termination = Gates[67].Inputs[2],
				Name = "G49 -> G67-2"
			});

			#endregion

			#region Gate 50 outputs

			Connections.Add(new Connection
			{
				Source = Gates[50],
				Termination = Gates[67].Inputs[3],
				Name = "G50 -> G67-3"
			});

			#endregion

			#region Gate 51 outputs

			Connections.Add(new Connection
			{
				Source = Gates[51],
				Termination = Gates[68].Inputs[0],
				Name = "G51 -> G68-0"
			});

			#endregion

			#region Gate 52 outputs

			Connections.Add(new Connection
			{
				Source = Gates[52],
				Termination = Gates[68].Inputs[1],
				Name = "G52 -> G68-1"
			});

			#endregion

			#region Gate 53 outputs

			Connections.Add(new Connection
			{
				Source = Gates[53],
				Termination = Gates[68].Inputs[2],
				Name = "G53 -> G68-2"
			});

			#endregion

			#region Gate 54 outputs

			Connections.Add(new Connection
			{
				Source = Gates[54],
				Termination = Gates[68].Inputs[3],
				Name = "G54 -> G68-3"
			});

			#endregion

			#region Gate 55 outputs

			Connections.Add(new Connection
			{
				Source = Gates[55],
				Termination = Gates[69].Inputs[0],
				Name = "G55 -> G69-0"
			});

			#endregion

			#region Gate 56 outputs

			Connections.Add(new Connection
			{
				Source = Gates[56],
				Termination = Gates[69].Inputs[1],
				Name = "G56 -> G69-1"
			});

			#endregion

			#region Gate 57 outputs

			Connections.Add(new Connection
			{
				Source = Gates[57],
				Termination = Gates[69].Inputs[2],
				Name = "G57 -> G69-2"
			});

			#endregion

			#region Gate 58 outputs

			Connections.Add(new Connection
			{
				Source = Gates[58],
				Termination = Gates[69].Inputs[3],
				Name = "G58 -> G69-3"
			});

			#endregion

			#region Gate 59 outputs

			Connections.Add(new Connection
			{
				Source = Gates[59],
				Termination = Gates[70].Inputs[0],
				Name = "G59 -> G70-0"
			});

			#endregion

			#region Gate 60 outputs

			Connections.Add(new Connection
			{
				Source = Gates[60],
				Termination = Gates[70].Inputs[1],
				Name = "G60 -> G70-1"
			});

			#endregion

			#region Gate 61 outputs

			Connections.Add(new Connection
			{
				Source = Gates[61],
				Termination = Gates[70].Inputs[2],
				Name = "G61 -> G70-2"
			});

			#endregion

			#region Gate 62 outputs

			Connections.Add(new Connection
			{
				Source = Gates[62],
				Termination = Gates[70].Inputs[3],
				Name = "G62 -> G70-3"
			});

			#endregion

			#region Gate 63 outputs

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[96].Inputs[0],
				Name = "G63 -> G96-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[72].Inputs[2],
				Name = "G63 -> G72-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[74].Inputs[2],
				Name = "G63 -> G74-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[77].Inputs[2],
				Name = "G63 -> G77-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[81].Inputs[1],
				Name = "G63 -> G81-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[63],
				Termination = Gates[86].Inputs[0],
				Name = "G63 -> G86-0"
			});

			#endregion

			#region Gate 64 outputs

			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[73].Inputs[1],
				Name = "G64 -> G73-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[75].Inputs[2],
				Name = "G64 -> G75-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[78].Inputs[3],
				Name = "G64 -> G78-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[82].Inputs[3],
				Name = "G64 -> G82-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[64],
				Termination = Gates[87].Inputs[3],
				Name = "G64 -> G87-3"
			});

			#endregion

			#region Gate 65 outputs
			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[97].Inputs[0],
				Name = "G65 -> G96-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[74].Inputs[3],
				Name = "G65 -> G74-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[75].Inputs[1],
				Name = "G65 -> G75-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[77].Inputs[3],
				Name = "G65 -> G77-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[78].Inputs[1],
				Name = "G65 -> G78-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[81].Inputs[2],
				Name = "G65 -> G81-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[82].Inputs[0],
				Name = "G65 -> G82-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[86].Inputs[1],
				Name = "G65 -> G86-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[65],
				Termination = Gates[87].Inputs[0],
				Name = "G65 -> G87-0"
			});
			#endregion

			#region Gate 66 outputs
			Connections.Add(new Connection
			{
				Source = Gates[66],
				Termination = Gates[76].Inputs[1],
				Name = "G66 -> G76-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[66],
				Termination = Gates[79].Inputs[0],
				Name = "G66 -> G79-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[66],
				Termination = Gates[83].Inputs[2],
				Name = "G66 -> G83-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[66],
				Termination = Gates[88].Inputs[2],
				Name = "G66 -> G88-2"
			});
			#endregion

			#region Gate 67 outputs
			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[98].Inputs[0],
				Name = "G67 -> G98-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[77].Inputs[4],
				Name = "G67 -> G77-4"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[78].Inputs[2],
				Name = "G67 -> G78-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[79].Inputs[1],
				Name = "G67 -> G79-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[81].Inputs[3],
				Name = "G67 -> G81-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[82].Inputs[1],
				Name = "G67 -> G82-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[83].Inputs[0],
				Name = "G67 -> G83-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[86].Inputs[2],
				Name = "G67 -> G86-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[87].Inputs[1],
				Name = "G67 -> G87-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[67],
				Termination = Gates[88].Inputs[0],
				Name = "G67 -> G88-0"
			});
			#endregion

			#region Gate 68 outputs
			Connections.Add(new Connection
			{
				Source = Gates[68],
				Termination = Gates[80].Inputs[1],
				Name = "G68 -> G80-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[68],
				Termination = Gates[84].Inputs[1],
				Name = "G68 -> G84-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[68],
				Termination = Gates[89].Inputs[1],
				Name = "G68 -> G89-1"
			});
			#endregion

			#region Gate 69 outputs
			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[99].Inputs[0],
				Name = "G69 -> G99-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[81].Inputs[4],
				Name = "G69 -> G81-4"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[82].Inputs[2],
				Name = "G69 -> G82-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[83].Inputs[1],
				Name = "G69 -> G83-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[84].Inputs[0],
				Name = "G69 -> G84-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[86].Inputs[3],
				Name = "G69 -> G86-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[87].Inputs[2],
				Name = "G69 -> G87-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[88].Inputs[1],
				Name = "G69 -> G88-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[69],
				Termination = Gates[89].Inputs[0],
				Name = "G69 -> G89-0"
			});
			#endregion

			#region Gate 70 outputs
			Connections.Add(new Connection
			{
				Source = Gates[70],
				Termination = Gates[85].Inputs[0],
				Name = "G70 -> G85-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[70],
				Termination = Gates[90].Inputs[0],
				Name = "G70 -> G90-0"
			});
			#endregion

			#region Gate 71 outputs
			Connections.Add(new Connection
			{
				Source = Gates[71],
				Termination = Gates[96].Inputs[1],
				Name = "G71 -> G96-1"
			});
			#endregion

			#region Gate 72 outputs
			Connections.Add(new Connection
			{
				Source = Gates[72],
				Termination = Gates[91].Inputs[0],
				Name = "G72 -> G91-0"
			});
			#endregion

			#region Gate 73 outputs
			Connections.Add(new Connection
			{
				Source = Gates[73],
				Termination = Gates[91].Inputs[1],
				Name = "G73 -> G91-1"
			});
			#endregion

			#region Gate 74 outputs
			Connections.Add(new Connection
			{
				Source = Gates[74],
				Termination = Gates[92].Inputs[0],
				Name = "G74 -> G92-0"
			});
			#endregion

			#region Gate 75 outputs
			Connections.Add(new Connection
			{
				Source = Gates[75],
				Termination = Gates[92].Inputs[1],
				Name = "G75 -> G92-1"
			});
			#endregion

			#region Gate 76 outputs
			Connections.Add(new Connection
			{
				Source = Gates[76],
				Termination = Gates[92].Inputs[2],
				Name = "G76 -> G92-2"
			});
			#endregion

			#region Gate 77 outputs
			Connections.Add(new Connection
			{
				Source = Gates[77],
				Termination = Gates[93].Inputs[0],
				Name = "G77 -> G93-0"
			});
			#endregion

			#region Gate 78 outputs
			Connections.Add(new Connection
			{
				Source = Gates[78],
				Termination = Gates[93].Inputs[1],
				Name = "G78 -> G93-1"
			});
			#endregion

			#region Gate 79 outputs
			Connections.Add(new Connection
			{
				Source = Gates[79],
				Termination = Gates[93].Inputs[2],
				Name = "G79 -> G93-2"
			});
			#endregion

			#region Gate 80 outputs
			Connections.Add(new Connection
			{
				Source = Gates[80],
				Termination = Gates[93].Inputs[3],
				Name = "G80 -> G93-3"
			});
			#endregion

			#region Gate 81 outputs
			Connections.Add(new Connection
			{
				Source = Gates[81],
				Termination = Gates[94].Inputs[0],
				Name = "G81 -> G94-0"
			});
			#endregion

			#region Gate 82 outputs
			Connections.Add(new Connection
			{
				Source = Gates[82],
				Termination = Gates[94].Inputs[1],
				Name = "G82 -> G94-1"
			});
			#endregion

			#region Gate 83 outputs
			Connections.Add(new Connection
			{
				Source = Gates[83],
				Termination = Gates[94].Inputs[2],
				Name = "G83 -> G94-2"
			});
			#endregion

			#region Gate 84 outputs
			Connections.Add(new Connection
			{
				Source = Gates[84],
				Termination = Gates[94].Inputs[3],
				Name = "G84 -> G94-3"
			});
			#endregion

			#region Gate 85 outputs
			Connections.Add(new Connection
			{
				Source = Gates[85],
				Termination = Gates[94].Inputs[4],
				Name = "G85 -> G94-4"
			});
			#endregion

			#region Gate 87 outputs
			Connections.Add(new Connection
			{
				Source = Gates[87],
				Termination = Gates[95].Inputs[0],
				Name = "G87 -> G95-0"
			});
			#endregion

			#region Gate 88 outputs
			Connections.Add(new Connection
			{
				Source = Gates[88],
				Termination = Gates[95].Inputs[1],
				Name = "G88 -> G95-1"
			});
			#endregion

			#region Gate 89 outputs
			Connections.Add(new Connection
			{
				Source = Gates[89],
				Termination = Gates[95].Inputs[2],
				Name = "G89 -> G95-2"
			});
			#endregion

			#region Gate 90 outputs
			Connections.Add(new Connection
			{
				Source = Gates[90],
				Termination = Gates[95].Inputs[3],
				Name = "G90 -> G95-3"
			});
			#endregion

			#region Gate 91 outputs
			Connections.Add(new Connection
			{
				Source = Gates[91],
				Termination = Gates[97].Inputs[1],
				Name = "G91 -> G97-1"
			});
			#endregion

			#region Gate 92 outputs
			Connections.Add(new Connection
			{
				Source = Gates[92],
				Termination = Gates[98].Inputs[1],
				Name = "G92 -> G98-1"
			});
			#endregion

			#region Gate 93 outputs
			Connections.Add(new Connection
			{
				Source = Gates[93],
				Termination = Gates[99].Inputs[1],
				Name = "G93 -> G99-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[93],
				Termination = Gates[100].Inputs[0],
				Name = "G93 -> G100-0"
			});
			#endregion

			#region Gate 94 outputs
			Connections.Add(new Connection
			{
				Source = Gates[94],
				Termination = Gates[100].Inputs[1],
				Name = "G94 -> G100-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[94],
				Termination = Gates[101].Inputs[0],
				Name = "G94 -> G101-0"
			});
			#endregion
		}
	}
}
