using Xunit;

namespace LogicLibrary.Tests
{
	public class JKFlipFlopTests
	{
		[Fact]
		public void test()
		{
			var jkFlipFlop = new JKFlipFlop(TTLGateTypeEnum.Perfect);

			jkFlipFlop.J.Add(5);
			jkFlipFlop.K.Add(0);
			jkFlipFlop.Clk.Add(0);

			jkFlipFlop.RunCircuit(1);

			Assert.Equal(5, jkFlipFlop.Q(0));
			Assert.Equal(0, jkFlipFlop.QNot(0));
		}
	}
}
