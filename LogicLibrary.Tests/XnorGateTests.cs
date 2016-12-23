using Xunit;

namespace LogicLibrary.Tests
{
	public class XnorGateTests
	{
		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 5)]
		public void perfect_gate_logic_test(double input1, double input2, double expectedOutput)
		{
			var xnorGate = new XnorGate(TTLGateTypeEnum.Perfect, 2);

			xnorGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1, Unknown = false });
			xnorGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2, Unknown = false });

			var result = xnorGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
