using Xunit;

namespace LogicLibrary.Tests
{
	public class FullAdderTests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(0, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 5, 0)]
		[InlineData(0, 5, 5, 0, 5)]
		[InlineData(5, 0, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5)]
		[InlineData(5, 5, 0, 0, 5)]
		[InlineData(5, 5, 5, 5, 5)]
		public void perfect_gate_logic_test(double A, double B, double Cin, double S, double Cout)
		{
			var fullAdder = new FullAdder(TTLGateTypeEnum.Perfect);

			fullAdder.A.Add(A);
			fullAdder.B.Add(B);
			fullAdder.Cin.Add(Cin);

			Assert.True(fullAdder.VerifyAllGateInputsConnected());
			Assert.True(fullAdder.VerifyNoShortedOutputs());
			
			fullAdder.RunCircuit();

			Assert.True(fullAdder.CircuitCompletedSuccessfully);

			Assert.Equal(S, fullAdder.S(0));
			Assert.Equal(Cout, fullAdder.Cout(0));
		}
	}
}
