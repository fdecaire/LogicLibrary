using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LogicLibrary;

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

			andGate.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = input1 });
			andGate.Inputs[1].InputSample.Add(new InputSignal { Timing = 0, Voltage = input2 });

			Assert.Equal(expectedOutput, andGate.Output(0));
		}



		//TODO: need timing tests
		//TODO: need signal transition tests
	}
}
