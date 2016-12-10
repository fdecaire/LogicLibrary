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

			nandGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1, Unknown = false });
			nandGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2, Unknown = false });

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Fact]
		public void perfect_gate_one_unknown_input()
		{
			var nandGate = new NandGate(TTLGateTypeEnum.Perfect, 2);

			// if any input is zero, then the output is high
			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = 0, Unknown = false });

			var result = nandGate.Output(0);

			Assert.Equal(5, result);
		}
	}
}
