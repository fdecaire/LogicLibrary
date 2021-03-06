﻿using Xunit;

namespace LogicLibrary.Tests
{
	public class TwoBitAdderTests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 0, 0, 0, 5, 0, 5, 0)]
		[InlineData(0, 0, 0, 5, 0, 0, 5, 0)]
		[InlineData(0, 0, 0, 5, 5, 5, 0, 0)]
		[InlineData(0, 0, 5, 0, 0, 5, 0, 0)]
		[InlineData(0, 0, 5, 0, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 0, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 0, 0, 5, 0, 0)]
		[InlineData(0, 5, 0, 0, 5, 5, 5, 0)]
		[InlineData(0, 5, 0, 5, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 5, 5, 0, 0, 5)]
		[InlineData(0, 5, 5, 0, 0, 0, 0, 5)]
		[InlineData(0, 5, 5, 0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 5, 0, 0, 5, 5)]
		[InlineData(0, 5, 5, 5, 5, 5, 0, 5)]
		[InlineData(5, 0, 0, 0, 0, 0, 5, 0)]
		[InlineData(5, 0, 0, 0, 5, 5, 0, 0)]
		[InlineData(5, 0, 0, 5, 0, 5, 0, 0)]
		[InlineData(5, 0, 0, 5, 5, 5, 5, 0)]
		[InlineData(5, 0, 5, 0, 0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0, 0, 5)]
		[InlineData(5, 0, 5, 5, 0, 0, 0, 5)]
		[InlineData(5, 0, 5, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0, 0, 5, 5, 0)]
		[InlineData(5, 5, 0, 0, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 0, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 0, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 5, 5, 5, 5)]
		public void perfect_gate_logic_test(int Cin, int B1, int A1, int B0, int A0, int F1, int F0, int Cout)
		{
			var adder = new TwoBitAdder(TTLGateTypeEnum.Perfect);
			adder.A0.Add(A0);
			adder.B0.Add(B0);
			adder.A1.Add(A1);
			adder.B1.Add(B1);
			adder.Cin.Add(Cin);

			Assert.Equal(F0, adder.F0(0));
			Assert.Equal(F1, adder.F1(0));
			Assert.Equal(Cout, adder.Cout(0));
		}
	}
}
