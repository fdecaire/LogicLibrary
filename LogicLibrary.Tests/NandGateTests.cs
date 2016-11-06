using Xunit;

namespace LogicLibrary.Tests
{
	public class NandGateTests
	{
		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 0)]
		public void perfect_gate_logic_test(double input1, double input2, double expectedOutput)
		{
			var nandGate = new NandGate(TTLGateTypeEnum.Perfect, 2);

			nandGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1 });
			nandGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2 });

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
