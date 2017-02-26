using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL7474Tests
	{
		[Fact]
		public void test_circuit_valid()
		{
			var ttl7474 = new TTL7474(TTLGateTypeEnum.Perfect);

			Assert.True(ttl7474.VerifyAllGateInputsConnected());
			Assert.True(ttl7474.VerifyNoShortedOutputs());
		}

		[Theory]
		[InlineData(0, 5, 0, 5)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5)]
		public void basic_d_latch_tests_1(int pre, int clr, int d, int q)
		{
			var ttl7474 = new TTL7474(TTLGateTypeEnum.Perfect);

			for (int i = 0; i < 4; i++)
			{
				ttl7474.PRE1.Add(pre);
				ttl7474.CLR1.Add(clr);
				ttl7474.D1.Add(d);
				ttl7474.CLK1.Add((i % 2) * 5);
			}

			Assert.Equal(q, ttl7474.Q1(3));
		}

		[Theory]
		[InlineData(0, 5, 0, 5)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5)]
		public void basic_d_latch_tests_2(int pre, int clr, int d, int q)
		{
			var ttl7474 = new TTL7474(TTLGateTypeEnum.Perfect);

			for (int i = 0; i < 4; i++)
			{
				ttl7474.PRE2.Add(pre);
				ttl7474.CLR2.Add(clr);
				ttl7474.D2.Add(d);
				ttl7474.CLK2.Add((i % 2) * 5);
			}

			Assert.Equal(q, ttl7474.Q2(3));
		}
	}
}
