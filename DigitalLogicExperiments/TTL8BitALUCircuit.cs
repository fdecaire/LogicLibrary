using LogicLibrary;
using TTLLibrary;

namespace DigitalLogicExperiments
{
    public class TTL8BitALUCircuit : Circuit
    {
	    public TTL74181 Alu1;
	    public TTL74181 Alu2;

		public Wire Cin { get; set; } = new Wire { CircuitName = "Cin" };
		public Wire A0 { get; set; } = new Wire { CircuitName = "A0" };
		public Wire B0 { get; set; } = new Wire { CircuitName = "B0" };
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire B2 { get; set; } = new Wire { CircuitName = "B2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire B3 { get; set; } = new Wire { CircuitName = "B3" };
		public Wire A4 { get; set; } = new Wire { CircuitName = "A4" };
		public Wire B4 { get; set; } = new Wire { CircuitName = "B4" };
		public Wire A5 { get; set; } = new Wire { CircuitName = "A5" };
		public Wire B5 { get; set; } = new Wire { CircuitName = "B5" };
		public Wire A6 { get; set; } = new Wire { CircuitName = "A6" };
		public Wire B6 { get; set; } = new Wire { CircuitName = "B6" };
		public Wire A7 { get; set; } = new Wire { CircuitName = "A7" };
		public Wire B7 { get; set; } = new Wire { CircuitName = "B7" };

		public Wire S0 { get; set; } = new Wire { CircuitName = "S0" };
		public Wire S1 { get; set; } = new Wire { CircuitName = "S1" };
		public Wire S2 { get; set; } = new Wire { CircuitName = "S2" };
		public Wire S3 { get; set; } = new Wire { CircuitName = "S3" };

		public double F0(int timing)
		{
			RunIteration(timing);

			return Alu1.F0(timing);
		}

		public double F1(int timing)
		{
			RunIteration(timing);

			return Alu1.F1(timing);
		}

		public double F2(int timing)
		{
			RunIteration(timing);

			return Alu1.F2(timing);
		}

		public double F3(int timing)
		{
			RunIteration(timing);

			return Alu1.F3(timing);
		}

		public double F4(int timing)
		{
			Alu2.Cn.Add(Alu1.Cn4(timing));
			RunIteration(timing);

			return Alu2.F0(timing);
		}

		public double F5(int timing)
		{
			Alu2.Cn.Add(Alu1.Cn4(timing));
			RunIteration(timing);

			return Alu2.F1(timing);
		}

		public double F6(int timing)
		{
			Alu2.Cn.Add(Alu1.Cn4(timing));
			RunIteration(timing);

			return Alu2.F2(timing);
		}

		public double F7(int timing)
		{
			Alu2.Cn.Add(Alu1.Cn4(timing));
			RunIteration(timing);

			return Alu2.F3(timing);
		}

	    public TTL8BitALUCircuit(TTLGateTypeEnum gateTypes)
	    {
		    Name = "8-bit ALU";

		    Alu1 = new TTL74181(gateTypes);
		    Alu2 = new TTL74181(gateTypes);

		    Alu1.Name = "ALU #1";
		    Alu2.Name = "ALU #2";

		    #region inputs

			// hard-code M to be zero for both ALUs
			Connections.Add(new Connection
			{
				Source = new Ground(1),
				WireTermination = Alu1.M,
				Name = "GND -> Alu1.M"
			});
			Connections.Add(new Connection
			{
				Source = new Ground(1),
				WireTermination = Alu2.M,
				Name = "GND -> Alu2.M"
			});

			Connections.Add(new Connection
		    {
			    Source = A0,
			    WireTermination = Alu1.A0,
			    Name = "A0 -> Alu1.A0"
		    });

			Connections.Add(new Connection
			{
				Source = A1,
				WireTermination = Alu1.A1,
				Name = "A1 -> Alu1.A1"
			});

			Connections.Add(new Connection
			{
				Source = A2,
				WireTermination = Alu1.A2,
				Name = "A2 -> Alu1.A2"
			});

			Connections.Add(new Connection
			{
				Source = A3,
				WireTermination = Alu1.A3,
				Name = "A3 -> Alu1.A3"
			});

			Connections.Add(new Connection
			{
				Source = A4,
				WireTermination = Alu2.A0,
				Name = "A4 -> Alu2.A0"
			});

			Connections.Add(new Connection
			{
				Source = A5,
				WireTermination = Alu2.A1,
				Name = "A5 -> Alu2.A1"
			});

			Connections.Add(new Connection
			{
				Source = A6,
				WireTermination = Alu2.A2,
				Name = "A6 -> Alu2.A2"
			});

			Connections.Add(new Connection
			{
				Source = A7,
				WireTermination = Alu2.A3,
				Name = "A7 -> Alu2.A3"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				WireTermination = Alu1.B0,
				Name = "B0 -> Alu1.B0"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				WireTermination = Alu1.B1,
				Name = "B1 -> Alu1.B1"
			});

			Connections.Add(new Connection
			{
				Source = B2,
				WireTermination = Alu1.B2,
				Name = "B2 -> Alu1.B2"
			});

			Connections.Add(new Connection
			{
				Source = B3,
				WireTermination = Alu1.B3,
				Name = "B3 -> Alu1.B3"
			});

			Connections.Add(new Connection
			{
				Source = B4,
				WireTermination = Alu2.B0,
				Name = "B4 -> Alu2.B0"
			});

			Connections.Add(new Connection
			{
				Source = B5,
				WireTermination = Alu2.B1,
				Name = "B5 -> Alu2.B1"
			});

			Connections.Add(new Connection
			{
				Source = B6,
				WireTermination = Alu2.B2,
				Name = "B6 -> Alu2.B2"
			});

			Connections.Add(new Connection
			{
				Source = B7,
				WireTermination = Alu2.B3,
				Name = "B7 -> Alu2.B3"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				WireTermination = Alu1.S0,
				Name = "S0 -> Alu1.S0"
			});

			Connections.Add(new Connection
			{
				Source = S0,
				WireTermination = Alu2.S0,
				Name = "S0 -> Alu2.S0"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				WireTermination = Alu1.S1,
				Name = "S1 -> Alu1.S1"
			});

			Connections.Add(new Connection
			{
				Source = S1,
				WireTermination = Alu2.S1,
				Name = "S1 -> Alu2.S1"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				WireTermination = Alu1.S2,
				Name = "S2 -> Alu1.S2"
			});

			Connections.Add(new Connection
			{
				Source = S2,
				WireTermination = Alu2.S2,
				Name = "S2 -> Alu2.S2"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				WireTermination = Alu1.S3,
				Name = "S3 -> Alu1.S3"
			});

			Connections.Add(new Connection
			{
				Source = S3,
				WireTermination = Alu2.S3,
				Name = "S3 -> Alu2.S3"
			});

			Connections.Add(new Connection
			{
				Source = Cin,
				WireTermination = Alu1.Cn,
				Name = "Cin -> Alu1.Cn"
			});
			#endregion
		}
    }
}
