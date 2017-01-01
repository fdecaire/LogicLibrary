using Xunit;

namespace LogicLibrary.Tests
{
	public class AndGateTests
	{
		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 5)]
		public void ttl_and_gate_logic_tests(double input1, double input2, double expectedOutput)
		{
			var andGate = new AndGate(TTLGateTypeEnum.Perfect, 2);

			andGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1, Unknown = false});
			andGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2, Unknown = false });

			Assert.Equal(expectedOutput, andGate.Output(0));
		}

		[Theory]
		[InlineData(0, 0)]
		[InlineData(5, 5)]
		public void test_one_input_and_gate(int input, int output)
		{
			var andGate = new AndGate(TTLGateTypeEnum.Perfect, 1);

			andGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input, Unknown = false });

			Assert.Equal(output, andGate.Output(0));
		}

		//TODO: need timing tests
		//TODO: need signal transition tests
	}
}
