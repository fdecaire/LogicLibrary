using Xunit;

namespace LogicLibrary.Tests
{
	public class NorGateTests
	{
		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 0)]
		public void perfect_gate_logic_test(double input1, double input2, double expectedOutput)
		{
			var norGate = new NorGate(TTLGateTypeEnum.Perfect, 2);

			norGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1 });
			norGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2 });

			var result = norGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
