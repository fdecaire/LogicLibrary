using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogicLibrary.Tests
{
	public class LatchTests
	{
		[Fact]
		public void sr_latch_circuit_test()
		{
			// proof of concept for a set/reset latch made from nand gates
			var connections = new List<Connection>();

			var nandGate1 = new NandGate(TTLGateTypeEnum.Perfect, 2);
			var nandGate2 = new NandGate(TTLGateTypeEnum.Perfect, 2);

			connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate2.Inputs[1]
			});

			connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate1.Inputs[1]
			});

			nandGate1.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = 5 });
			nandGate2.Inputs[0].InputSample.Add(new InputSignal { Timing = 0, Voltage = 0 });

			connections[0].TransmitSignal();
			connections[1].TransmitSignal();

			Assert.Equal(5,nandGate1.Output(0));
			Assert.Equal(0,nandGate2.Output(0));
		}
	}
}
