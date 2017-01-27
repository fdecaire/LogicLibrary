using LogicLibrary;

namespace TTLLibrary
{
	// 7-segment decoder/driver
	//http://www.davidswinscoe.com/electronics/components/7447/#1
	public class TTL7447 : Circuit
	{
		public Wire A { get; set; } = new Wire { CircuitName = "A" };
		public Wire B { get; set; } = new Wire { CircuitName = "B" };
		public Wire C { get; set; } = new Wire { CircuitName = "C" };
		public Wire D { get; set; } = new Wire { CircuitName = "D" };
		public Wire LampTest { get; set; } = new Wire { CircuitName = "LampTest" };
		public Wire RBI { get; set; } = new Wire { CircuitName = "RBI" };

		public double Segmenta(int timing)
		{
			RunIteration(timing);
			return Gates[37].Output(timing);
		}

		public double Segmentb(int timing)
		{
			RunIteration(timing);
			return Gates[38].Output(timing);
		}

		public double Segmentc(int timing)
		{
			RunIteration(timing);
			return Gates[39].Output(timing);
		}

		public double Segmentd(int timing)
		{
			RunIteration(timing);
			return Gates[40].Output(timing);
		}

		public double Segmente(int timing)
		{
			RunIteration(timing);
			return Gates[41].Output(timing);
		}

		public double Segmentf(int timing)
		{
			RunIteration(timing);
			return Gates[42].Output(timing);
		}

		public double Segmentg(int timing)
		{
			RunIteration(timing);
			return Gates[43].Output(timing);
		}

		public TTL7447(TTLGateTypeEnum gateType)
		{
			Gates.Add(new NandGate(gateType, 2) {CircuitName = "G0"});
			Gates.Add(new NandGate(gateType, 2) {CircuitName = "G1"});
			Gates.Add(new NandGate(gateType, 2) {CircuitName = "G2"});
			Gates.Add(new Inverter(gateType) { CircuitName = "G3" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G4" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G5" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G6" });
			Gates.Add(new NandGate(gateType, 2) { CircuitName = "G7" });
			Gates.Add(new Buffer(gateType) { CircuitName = "G8" }); 
			Gates.Add(new NandGate(gateType, 6) { CircuitName = "G9" });
			Gates.Add(new Buffer(gateType) { CircuitName = "G10" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G11" });

			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G12" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G13" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G14" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G15" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G16" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G17" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G18" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G19" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G10" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G21" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G22" });
			Gates.Add(new Buffer(gateType) { CircuitName = "G23" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G24" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G25" });
			Gates.Add(new AndGate(gateType, 2) { CircuitName = "G26" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G27" });
			Gates.Add(new AndGate(gateType, 3) { CircuitName = "G28" });
			Gates.Add(new AndGate(gateType, 4) { CircuitName = "G29" });

			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G30" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G31" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G32" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G33" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G34" });
			Gates.Add(new NorGate(gateType, 3) { CircuitName = "G35" });
			Gates.Add(new NorGate(gateType, 2) { CircuitName = "G36" });

			Gates.Add(new Inverter(gateType) { CircuitName = "G37" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G38" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G39" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G40" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G41" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G42" });
			Gates.Add(new Inverter(gateType) { CircuitName = "G43" });

			#region inputs
			Connections.Add(new Connection
			{
				Source = A,
				Termination = Gates[0].Inputs[0],
				Name = "G0-0"
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = Gates[1].Inputs[0],
				Name = "G1-0"
			});

			Connections.Add(new Connection
			{
				Source = C,
				Termination = Gates[2].Inputs[0],
				Name = "G2-0"
			});

			Connections.Add(new Connection
			{
				Source = D,
				Termination = Gates[3].Inputs[0],
				Name = "G3-0"
			});

			Connections.Add(new Connection
			{
				Source = LampTest,
				Termination = Gates[10].Inputs[0],
				Name = "G10-0"
			});

			Connections.Add(new Connection
			{
				Source = RBI,
				Termination = Gates[11].Inputs[0],
				Name = "G11-0"
			});
			#endregion

			#region Gate 0 outputs
			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[4].Inputs[0],
				Name = "G4-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[13].Inputs[0],
				Name = "G13-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[17].Inputs[0],
				Name = "G17-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[19].Inputs[0],
				Name = "G19-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[21].Inputs[0],
				Name = "G21-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[0],
				Termination = Gates[9].Inputs[5],
				Name = "G9-5"
			});
			#endregion

			#region Gate 1 outputs
			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[5].Inputs[0],
				Name = "G5-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[14].Inputs[1],
				Name = "G14-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[16].Inputs[1],
				Name = "G16-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[20].Inputs[1],
				Name = "G20-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[21].Inputs[1],
				Name = "G21-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[24].Inputs[0],
				Name = "G24-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[29].Inputs[0],
				Name = "G29-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[1],
				Termination = Gates[9].Inputs[4],
				Name = "G9-4"
			});
			#endregion

			#region Gate 2 outputs
			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[6].Inputs[0],
				Name = "G6-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[14].Inputs[2],
				Name = "G14-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[19].Inputs[2],
				Name = "G19-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[20].Inputs[2],
				Name = "G20-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[26].Inputs[1],
				Name = "G26-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[27].Inputs[1],
				Name = "G27-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[29].Inputs[1],
				Name = "G29-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[2],
				Termination = Gates[9].Inputs[3],
				Name = "G9-3"
			});
			#endregion

			#region Gate 3 outputs
			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[7].Inputs[0],
				Name = "G7-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[14].Inputs[3],
				Name = "G14-3"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[27].Inputs[2],
				Name = "G27-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[29].Inputs[2],
				Name = "G29-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[3],
				Termination = Gates[9].Inputs[2],
				Name = "G9-2"
			});
			#endregion

			#region Gate 4 outputs
			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[14].Inputs[0],
				Name = "G14-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[16].Inputs[0],
				Name = "G16-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[20].Inputs[0],
				Name = "G20-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[22].Inputs[0],
				Name = "G22-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[23].Inputs[0],
				Name = "G23-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[25].Inputs[0],
				Name = "G25-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[27].Inputs[0],
				Name = "G27-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[4],
				Termination = Gates[28].Inputs[0],
				Name = "G28-0"
			});
			#endregion

			#region Gate 5 outputs
			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[12].Inputs[0],
				Name = "G12-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[15].Inputs[0],
				Name = "G15-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[17].Inputs[1],
				Name = "G17-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[19].Inputs[1],
				Name = "G19-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[22].Inputs[1],
				Name = "G22-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[25].Inputs[1],
				Name = "G25-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[26].Inputs[0],
				Name = "G26-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[5],
				Termination = Gates[28].Inputs[1],
				Name = "G28-1"
			});
			#endregion

			#region Gate 6 outputs
			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[13].Inputs[1],
				Name = "G13-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[16].Inputs[2],
				Name = "G16-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[17].Inputs[2],
				Name = "G17-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[18].Inputs[0],
				Name = "G18-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[21].Inputs[2],
				Name = "G21-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[22].Inputs[2],
				Name = "G22-2"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[24].Inputs[1],
				Name = "G24-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[6],
				Termination = Gates[28].Inputs[2],
				Name = "G28-2"
			});
			#endregion

			#region Gate 7 outputs
			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[12].Inputs[1],
				Name = "G12-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[15].Inputs[1],
				Name = "G15-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[7],
				Termination = Gates[18].Inputs[1],
				Name = "G18-1"
			});
			#endregion

			#region Gate 8 outputs
			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[7].Inputs[1],
				Name = "G7-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[6].Inputs[1],
				Name = "G6-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[5].Inputs[1],
				Name = "G5-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[8],
				Termination = Gates[4].Inputs[1],
				Name = "G4-1"
			});
			#endregion

			#region Gate 9 outputs
			Connections.Add(new Connection
			{
				Source = Gates[9],
				Termination = Gates[8].Inputs[0],
				Name = "G8-0"
			});
			#endregion

			#region Gate 10 outputs
			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[9].Inputs[0],
				Name = "G9-0"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[0].Inputs[1],
				Name = "G0-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[1].Inputs[1],
				Name = "G1-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[2].Inputs[1],
				Name = "G2-1"
			});

			Connections.Add(new Connection
			{
				Source = Gates[10],
				Termination = Gates[29].Inputs[3],
				Name = "G29-3"
			});
			#endregion

			#region Gate 11 outputs
			Connections.Add(new Connection
			{
				Source = Gates[11],
				Termination = Gates[9].Inputs[1],
				Name = "G9-1"
			});
			#endregion

			#region Gate 12 outputs
			Connections.Add(new Connection
			{
				Source = Gates[12],
				Termination = Gates[30].Inputs[0],
				Name = "G30-0"
			});
			#endregion

			#region Gate 13 outputs
			Connections.Add(new Connection
			{
				Source = Gates[13],
				Termination = Gates[30].Inputs[1],
				Name = "G30-1"
			});
			#endregion

			#region Gate 14 outputs
			Connections.Add(new Connection
			{
				Source = Gates[14],
				Termination = Gates[30].Inputs[2],
				Name = "G30-2"
			});
			#endregion

			#region Gate 15 outputs
			Connections.Add(new Connection
			{
				Source = Gates[15],
				Termination = Gates[31].Inputs[0],
				Name = "G31-0"
			});
			#endregion

			#region Gate 16 outputs
			Connections.Add(new Connection
			{
				Source = Gates[16],
				Termination = Gates[31].Inputs[1],
				Name = "G31-1"
			});
			#endregion

			#region Gate 17 outputs
			Connections.Add(new Connection
			{
				Source = Gates[17],
				Termination = Gates[31].Inputs[2],
				Name = "G31-2"
			});
			#endregion

			#region Gate 18 outputs
			Connections.Add(new Connection
			{
				Source = Gates[18],
				Termination = Gates[32].Inputs[0],
				Name = "G32-0"
			});
			#endregion

			#region Gate 19 outputs
			Connections.Add(new Connection
			{
				Source = Gates[19],
				Termination = Gates[32].Inputs[1],
				Name = "G32-1"
			});
			#endregion

			#region Gate 20 outputs
			Connections.Add(new Connection
			{
				Source = Gates[20],
				Termination = Gates[33].Inputs[0],
				Name = "G33-0"
			});
			#endregion

			#region Gate 21 outputs
			Connections.Add(new Connection
			{
				Source = Gates[21],
				Termination = Gates[33].Inputs[1],
				Name = "G33-1"
			});
			#endregion

			#region Gate 22 outputs
			Connections.Add(new Connection
			{
				Source = Gates[22],
				Termination = Gates[33].Inputs[2],
				Name = "G33-2"
			});
			#endregion

			#region Gate 23 outputs
			Connections.Add(new Connection
			{
				Source = Gates[23],
				Termination = Gates[34].Inputs[0],
				Name = "G34-0"
			});
			#endregion

			#region Gate 24 outputs
			Connections.Add(new Connection
			{
				Source = Gates[24],
				Termination = Gates[34].Inputs[1],
				Name = "G34-1"
			});
			#endregion

			#region Gate 25 outputs
			Connections.Add(new Connection
			{
				Source = Gates[25],
				Termination = Gates[35].Inputs[0],
				Name = "G35-0"
			});
			#endregion

			#region Gate 26 outputs
			Connections.Add(new Connection
			{
				Source = Gates[26],
				Termination = Gates[35].Inputs[1],
				Name = "G35-1"
			});
			#endregion

			#region Gate 27 outputs
			Connections.Add(new Connection
			{
				Source = Gates[27],
				Termination = Gates[35].Inputs[2],
				Name = "G35-2"
			});
			#endregion

			#region Gate 28 outputs
			Connections.Add(new Connection
			{
				Source = Gates[28],
				Termination = Gates[36].Inputs[0],
				Name = "G36-0"
			});
			#endregion

			#region Gate 29 outputs
			Connections.Add(new Connection
			{
				Source = Gates[29],
				Termination = Gates[36].Inputs[1],
				Name = "G36-1"
			});
			#endregion

			#region Gate 30 outputs
			Connections.Add(new Connection
			{
				Source = Gates[30],
				Termination = Gates[37].Inputs[0],
				Name = "G37-0"
			});
			#endregion

			#region Gate 31 outputs
			Connections.Add(new Connection
			{
				Source = Gates[31],
				Termination = Gates[38].Inputs[0],
				Name = "G38-0"
			});
			#endregion

			#region Gate 32 outputs
			Connections.Add(new Connection
			{
				Source = Gates[32],
				Termination = Gates[39].Inputs[0],
				Name = "G39-0"
			});
			#endregion

			#region Gate 33 outputs
			Connections.Add(new Connection
			{
				Source = Gates[33],
				Termination = Gates[40].Inputs[0],
				Name = "G40-0"
			});
			#endregion

			#region Gate 34 outputs
			Connections.Add(new Connection
			{
				Source = Gates[34],
				Termination = Gates[41].Inputs[0],
				Name = "G41-0"
			});
			#endregion

			#region Gate 35 outputs
			Connections.Add(new Connection
			{
				Source = Gates[35],
				Termination = Gates[42].Inputs[0],
				Name = "G42-0"
			});
			#endregion

			#region Gate 36 outputs
			Connections.Add(new Connection
			{
				Source = Gates[36],
				Termination = Gates[43].Inputs[0],
				Name = "G43-0"
			});
			#endregion
		}
	}
}
