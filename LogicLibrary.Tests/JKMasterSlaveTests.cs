using Xunit;

namespace LogicLibrary.Tests
{
	public class JKMasterSlaveTests
	{
		[Fact]
		public void jk_set()
		{
			var jkFlipFlop = new JKMasterSlave(TTLGateTypeEnum.Perfect);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(0);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(0);
			jkFlipFlop.Clk.Add(0);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(0);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(0);
			jkFlipFlop.Clk.Add(0);

			jkFlipFlop.RunCircuit();

			Assert.True(jkFlipFlop.VerifyNoShortedOutputs());
			Assert.True(jkFlipFlop.VerifyAllGateInputsConnected());

			Assert.True(jkFlipFlop.CircuitCompletedSuccessfully);
			Assert.Equal(5, jkFlipFlop.Q(1));
			Assert.Equal(0, jkFlipFlop.QNot(1));
		}

		[Fact]
		public void jk_reset()
		{
			var jkFlipFlop = new JKMasterSlave(TTLGateTypeEnum.Perfect);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// Give this 2 clock cycles to sort out any randomness
			jkFlipFlop.RunCircuit();

			Assert.True(jkFlipFlop.VerifyNoShortedOutputs());
			Assert.True(jkFlipFlop.VerifyAllGateInputsConnected());

			Assert.True(jkFlipFlop.CircuitCompletedSuccessfully);
			Assert.Equal(0, jkFlipFlop.Q(3));
			Assert.Equal(5, jkFlipFlop.QNot(3));
		}

		[Fact]
		public void jk_toggle_once()
		{
			var jkFlipFlop = new JKMasterSlave(TTLGateTypeEnum.Perfect);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// start toggle
			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// Give this 2 clock cycles to sort out any randomness
			jkFlipFlop.RunCircuit();

			Assert.True(jkFlipFlop.VerifyNoShortedOutputs());
			Assert.True(jkFlipFlop.VerifyAllGateInputsConnected());

			Assert.True(jkFlipFlop.CircuitCompletedSuccessfully);
			Assert.Equal(5, jkFlipFlop.Q(3));
			Assert.Equal(0, jkFlipFlop.QNot(3));
		}

		[Fact]
		public void jk_toggle_twice()
		{
			var jkFlipFlop = new JKMasterSlave(TTLGateTypeEnum.Perfect);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(0);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// start toggle
			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// second toggle
			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(5);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(5);
			jkFlipFlop.Clk.Add(0);

			// Give this 2 clock cycles to sort out any randomness
			jkFlipFlop.RunCircuit();

			Assert.True(jkFlipFlop.VerifyNoShortedOutputs());
			Assert.True(jkFlipFlop.VerifyAllGateInputsConnected());

			Assert.True(jkFlipFlop.CircuitCompletedSuccessfully);
			Assert.Equal(0, jkFlipFlop.Q(5));
			Assert.Equal(5, jkFlipFlop.QNot(5));
		}
	}
}
