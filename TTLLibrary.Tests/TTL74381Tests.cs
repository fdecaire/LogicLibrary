using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74381Tests
	{

		[Theory]
		[InlineData(0, 0, 0, 5, 5, 5, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 5, 0, 5, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 0, 5, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 0, 5, 5, 5, 5, 0)]
		[InlineData(5, 0, 0, 0, 0, 5, 0, 5, 5, 5)]
		[InlineData(5, 0, 5, 5, 0, 0, 5, 5, 5, 0)]
		[InlineData(5, 5, 0, 5, 5, 0, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 0, 0, 5, 5, 5, 0)]
		public void TTL74381_function_selector(int s0, int s1, int s2, int g19, int g20, int g21, int g14, int g15, int g16,
			int g22)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(s0);
			alu.S1.Add(s1);
			alu.S2.Add(s2);
			alu.Cn.Add(0);
			alu.RunCircuit();

			Assert.Equal(g19, alu.GateOutput(19, 0));
			Assert.Equal(g20, alu.GateOutput(20, 0));
			Assert.Equal(g21, alu.GateOutput(21, 0));
			Assert.Equal(g14, alu.GateOutput(14, 0));
			Assert.Equal(g15, alu.GateOutput(15, 0));
			Assert.Equal(g16, alu.GateOutput(16, 0));
			Assert.Equal(g22, alu.GateOutput(22, 0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a0_b0(int a0, int b0, int g63, int g64, int f0, int f1)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(a0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);
			alu.B0.Add(b0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g63, alu.GateOutput(63, 0));
			Assert.Equal(g64, alu.GateOutput(64, 0));

			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a1_b1(int a1, int b1, int g65, int g66, int f1, int f2)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(a1);
			alu.A2.Add(0);
			alu.A3.Add(0);
			alu.B0.Add(0);
			alu.B1.Add(b1);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g65, alu.GateOutput(65, 0));
			Assert.Equal(g66, alu.GateOutput(66, 0));

			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(f2, alu.F2(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a2_b2(int a2, int b2, int g67, int g68, int f2, int f3)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(a2);
			alu.A3.Add(0);
			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(b2);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g67, alu.GateOutput(67, 0));
			Assert.Equal(g68, alu.GateOutput(68, 0));

			Assert.Equal(f2, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a3_b3(int a3, int b3, int g69, int g70, int f3, int cn)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(a3);
			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.Equal(g69, alu.GateOutput(69, 0));
			Assert.Equal(g70, alu.GateOutput(70, 0));

			Assert.Equal(f3, alu.F3(0));
			Assert.Equal(cn, alu.Cn4(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 0, 5, 0, 0, 5, 5, 5)]
		[InlineData(0, 0, 5, 5, 0, 0, 5, 5, 0, 5, 5, 0)]
		public void TTL74381_add(int a3, int a2, int a1, int a0, int b3, int b2, int b1, int b0, int f3, int f2, int f1,
			int f0)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);

			alu.A0.Add(a0);
			alu.A1.Add(a1);
			alu.A2.Add(a2);
			alu.A3.Add(a3);
			alu.B0.Add(b0);
			alu.B1.Add(b1);
			alu.B2.Add(b2);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);


			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(f2, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
		}
	}
}
