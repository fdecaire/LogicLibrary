using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogicLibrary.Tests
{
	public class TwoBitAdderTests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0)]
		//[InlineData(0, 0, 0, 5, 0, 5, 0)]
		[InlineData(0, 0, 5, 0, 5, 0, 0)]
		//[InlineData(0, 0, 5, 5, 5, 5, 0)]
		public void perfect_gate_logic_test(double A2, double A1, double B2, double B1, double S2, double S1, double Cout)
		{
			// a2 a1 b2 b1 | S2 S1 C
			// 0  0  0  0  | 0  0  0
			// 0  0  0  1  | 0  1  0
			// 0  0  1  0  | 1  0  0
			// 0  0  1  1  | 1  1  0
			// 0  1  0  0  | 0  1  0
			// 0  1  0  1  | 1  0  0
			// 0  1  1  0  | 1  1  0
			// 0  1  1  1  | 0  0  1
			// 1  0  0  0  | 1  0  0
			// 1  0  0  1  | 1  1  0
			// 1  0  1  0  | 0  0  1
			// 1  0  1  1  | 0  1  1
			// 1  1  0  0  | 1  1  0
			// 1  1  0  1  | 0  0  1
			// 1  1  1  0  | 0  1  1
			// 1  1  1  1  | 1  0  1

			var adder1Circuit = new FullAdder(TTLGateTypeEnum.Perfect);
			var adder2Circuit = new FullAdder(TTLGateTypeEnum.Perfect);

			adder1Circuit.A.Add(A1);
			adder1Circuit.B.Add(A2);
			adder1Circuit.Cin.Add(0);
			adder1Circuit.RunCircuit();

			adder2Circuit.A.Add(B1);
			adder2Circuit.B.Add(B2);

			adder2Circuit.Cin.Add(adder1Circuit.Cout(0));
			adder2Circuit.RunCircuit();

			Assert.Equal(S1, adder1Circuit.S(0));
			Assert.Equal(S2, adder2Circuit.S(0));
			Assert.Equal(Cout, adder2Circuit.Cout(0));
		}
	}
}
