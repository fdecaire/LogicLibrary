using Xunit;

namespace LogicLibrary.Tests
{
	public class InverterTests
	{
		[Theory]
		[InlineData(0, 5)]
		[InlineData(5, 0)]
		public void perfect_gate_logic_test(double input, double expectedOutput)
		{
			var inverter = new Inverter(TTLGateTypeEnum.Perfect);

			inverter.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input});

			var result = inverter.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
