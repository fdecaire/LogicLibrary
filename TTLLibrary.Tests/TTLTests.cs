using System;
using System.Threading;
using LogicLibrary;
using TTLLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTLTests
	{
		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 0)]
		public void TTL7400_test(double input1, double input2, double expectedOutput)
		{
			var nandGate = new TTL7400(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 0)]
		public void TTL7402_test(double input1, double input2, double expectedOutput)
		{
			var norGate = new TTL7402(TTLGateTypeEnum.Perfect);

			norGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			norGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = norGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 5)]
		[InlineData(5, 0)]
		public void TTL7404_test(double input, double expectedOutput)
		{
			var inverter = new TTL7404(TTLGateTypeEnum.Perfect);

			inverter.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input, Unknown = false});

			var result = inverter.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 5)]
		public void TTL7408_test(double input1, double input2, double expectedOutput)
		{
			var nandGate = new TTL7408(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(0, 5, 0, 5)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 5)]
		[InlineData(5, 5, 5, 0)]
		public void TTL7410_test(double input1, double input2, double input3, double expectedOutput)
		{
			var nandGate = new TTL7410(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5)]
		public void TTL7411_test(double input1, double input2, double input3, double expectedOutput)
		{
			var nandGate = new TTL7411(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5)]
		[InlineData(0, 0, 0, 5, 5)]
		[InlineData(0, 0, 5, 0, 5)]
		[InlineData(0, 0, 5, 5, 5)]
		[InlineData(0, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 5)]
		[InlineData(5, 0, 0, 5, 5)]
		[InlineData(5, 0, 5, 0, 5)]
		[InlineData(5, 0, 5, 5, 5)]
		[InlineData(5, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0)]
		public void TTL7420_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var nandGate = new TTL7420(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			nandGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(0, 0, 0, 5, 0)]
		[InlineData(0, 0, 5, 0, 0)]
		[InlineData(0, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0)]
		[InlineData(0, 5, 5, 0, 0)]
		[InlineData(0, 5, 5, 5, 0)]
		[InlineData(5, 0, 0, 0, 0)]
		[InlineData(5, 0, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 0)]
		[InlineData(5, 0, 5, 5, 0)]
		[InlineData(5, 5, 0, 0, 0)]
		[InlineData(5, 5, 0, 5, 0)]
		[InlineData(5, 5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5, 5)]
		public void TTL7421_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var andGate = new TTL7421(TTLGateTypeEnum.Perfect);

			andGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			andGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			andGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			andGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			var result = andGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 0)]
		public void TTL7427_test(double input1, double input2, double input3, double expectedOutput)
		{
			var norGate = new TTL7427(TTLGateTypeEnum.Perfect);

			norGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			norGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			norGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = norGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5)]
		[InlineData(0, 0, 0, 5, 5)]
		[InlineData(0, 0, 5, 0, 5)]
		[InlineData(0, 0, 5, 5, 5)]
		[InlineData(0, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 5)]
		[InlineData(5, 0, 0, 5, 5)]
		[InlineData(5, 0, 5, 0, 5)]
		[InlineData(5, 0, 5, 5, 5)]
		[InlineData(5, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0)]
		public void TTL7430_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var nandGate = new TTL7430(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			nandGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			//TODO: need 4 more inputs to complete unit tests.

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 5)]
		public void TTL7432_test(double input1, double input2, double expectedOutput)
		{
			var orGate = new TTL7432(TTLGateTypeEnum.Perfect);

			orGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			orGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = orGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}
	}
}
