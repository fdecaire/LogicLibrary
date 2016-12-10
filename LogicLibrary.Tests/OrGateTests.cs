using Xunit;

namespace LogicLibrary.Tests
{
	public class OrGateTests
	{
		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 5)]
		public void perfect_gate_logic_test(double input1, double input2, double expectedOutput)
		{
			var orGate = new OrGate(TTLGateTypeEnum.Perfect, 2);

			orGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1, Unknown = false });
			orGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2, Unknown = false });

			var result = orGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
