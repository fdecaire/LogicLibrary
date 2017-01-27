using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	/*
	public class TTL74181_alternate_tests
	{
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void a0_plus_b0(int a0, int b0, int f0, int f1)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);
			alu.Cn.Add(5);
			alu.M.Add(0);

			alu.A0.Add(a0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);

			alu.B0.Add(b0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(0, alu.F2(0));
			Assert.Equal(0, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void a1_plus_b1(int a1, int b1, int f1, int f2)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);
			alu.Cn.Add(5);
			alu.M.Add(0);

			alu.A0.Add(0);
			alu.A1.Add(a1);
			alu.A2.Add(0);
			alu.A3.Add(0);

			alu.B0.Add(0);
			alu.B1.Add(b1);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(f2, alu.F2(0));
			Assert.Equal(0, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void a2_plus_b2(int a2, int b2, int f2, int f3)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);
			alu.Cn.Add(5);
			alu.M.Add(0);

			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(a2);
			alu.A3.Add(0);

			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(b2);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(0, alu.F0(0));
			Assert.Equal(0, alu.F1(0));
			Assert.Equal(f2, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0)]
		public void a3_plus_b3(int a3, int b3, int f3, int cn4)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);
			alu.Cn.Add(5);
			alu.M.Add(0);

			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(a3);

			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(0, alu.F0(0));
			Assert.Equal(0, alu.F1(0));
			Assert.Equal(0, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
			Assert.Equal(cn4, alu.Cn4(0)); // this output is inverted
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 0, 5)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 0, 5)]
		[InlineData(5, 5, 5, 0)]
		[InlineData(5, 5, 5, 5)]
		public void f_equals_a(int a0, int a1, int a2, int a3)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(5);
			alu.S3.Add(5);
			alu.Cn.Add(0);
			alu.M.Add(5);

			alu.A0.Add(a0);
			alu.A1.Add(a1);
			alu.A2.Add(a2);
			alu.A3.Add(a3);

			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(a0, alu.F0(0));
			Assert.Equal(a1, alu.F1(0));
			Assert.Equal(a2, alu.F2(0));
			Assert.Equal(a3, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 0, 5)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 0, 5)]
		[InlineData(5, 5, 5, 0)]
		[InlineData(5, 5, 5, 5)]
		public void f_equals_b(int b0, int b1, int b2, int b3)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(0);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.S3.Add(5);
			alu.Cn.Add(0);
			alu.M.Add(5);

			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);

			alu.B0.Add(b0);
			alu.B1.Add(b1);
			alu.B2.Add(b2);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(b0, alu.F0(0));
			Assert.Equal(b1, alu.F1(0));
			Assert.Equal(b2, alu.F2(0));
			Assert.Equal(b3, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 0, 5)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 0, 5)]
		[InlineData(5, 5, 5, 0)]
		[InlineData(5, 5, 5, 5)]
		public void f_equals_0(int b0, int b1, int b2, int b3)
		{
			var alu = new TTL74181_alternate(TTLGateTypeEnum.Perfect);

			alu.S0.Add(0);
			alu.S1.Add(0);
			alu.S2.Add(5);
			alu.S3.Add(5);
			alu.Cn.Add(0);
			alu.M.Add(5);

			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);

			alu.B0.Add(b0);
			alu.B1.Add(b1);
			alu.B2.Add(b2);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.VerifyNoShortedOutputs());
			Assert.True(alu.CircuitCompletedSuccessfully);

			Assert.Equal(5, alu.F0(0));
			Assert.Equal(5, alu.F1(0));
			Assert.Equal(5, alu.F2(0));
			Assert.Equal(5, alu.F3(0));
		}
	}
	*/
}
