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
		public void sr_latch_circuit_set()
		{
			var srLatch = new SRLatch(TTLGateTypeEnum.Perfect);

			srLatch.S.Add(5);
			srLatch.R.Add(0);
			srLatch.RunCircuit();

			Assert.True(srLatch.CircuitCompletedSuccessfully);
			Assert.Equal(0, srLatch.Q(0));
			Assert.Equal(5, srLatch.QBar(0));
		}

		[Fact]
		public void sr_latch_circuit_reset()
		{
			var srLatch = new SRLatch(TTLGateTypeEnum.Perfect);

			srLatch.S.Add(0);
			srLatch.R.Add(5);
			srLatch.RunCircuit();

			Assert.True(srLatch.CircuitCompletedSuccessfully);
			Assert.Equal(5, srLatch.Q(0));
			Assert.Equal(0, srLatch.QBar(0));
		}
	}
}
