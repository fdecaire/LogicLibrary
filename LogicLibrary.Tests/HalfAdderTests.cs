using Xunit;

namespace LogicLibrary.Tests
{
	public class HalfAdderTests
	{
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void perfect_gate_logic_test(double A, double B, double S, double Cout)
		{
			var halfAdder = new HalfAdder(TTLGateTypeEnum.Perfect);

			halfAdder.A.Add(A);
			halfAdder.B.Add(B);
			halfAdder.RunCircuit();

			Assert.Equal(S, halfAdder.S(0));
			Assert.Equal(Cout,halfAdder.Cout(0));
		}
	}
}
