using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74153Tests
	{
		[Fact]
		public void test_circuit_valid()
		{
			var ttl74153 = new TTL74153(TTLGateTypeEnum.Perfect);

			Assert.True(ttl74153.VerifyAllGateInputsConnected());
			Assert.True(ttl74153.VerifyNoShortedOutputs());
		}

		[Theory]
		[InlineData(0, 0, 0, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 0, 0, 0, 5)]
		[InlineData(5, 0, 5, 0, 5, 5, 0)]
		[InlineData(5, 0, 0, 5, 0, 0, 5)]
		[InlineData(0, 5, 5, 5, 0, 5, 0)]
		[InlineData(0, 5, 0, 0, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 5, 0, 0)]
		[InlineData(5, 5, 0, 0, 0, 5, 5)]
		public void select_a_side(int s0, int s1, int i0a, int i1a, int i2a, int i3a, int za)
		{
			var ttl74153 = new TTL74153(TTLGateTypeEnum.Perfect);

			ttl74153.Ea.Add(0);
			ttl74153.S0.Add(s0);
			ttl74153.S1.Add(s1);
			ttl74153.I0a.Add(i0a);
			ttl74153.I1a.Add(i1a);
			ttl74153.I2a.Add(i2a);
			ttl74153.I3a.Add(i3a);

			Assert.Equal(za, ttl74153.Za(0));
		}

		[Fact]
		public void disable_a_side()
		{
			var ttl74153 = new TTL74153(TTLGateTypeEnum.Perfect);

			ttl74153.Ea.Add(5);

			ttl74153.S0.Add(0);
			ttl74153.S1.Add(0);
			ttl74153.I0a.Add(5);
			ttl74153.I1a.Add(5);
			ttl74153.I2a.Add(5);
			ttl74153.I3a.Add(5);

			Assert.Equal(0, ttl74153.Za(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 0, 0, 0, 5)]
		[InlineData(5, 0, 5, 0, 5, 5, 0)]
		[InlineData(5, 0, 0, 5, 0, 0, 5)]
		[InlineData(0, 5, 5, 5, 0, 5, 0)]
		[InlineData(0, 5, 0, 0, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 5, 0, 0)]
		[InlineData(5, 5, 0, 0, 0, 5, 5)]
		public void select_b_side(int s0, int s1, int i0b, int i1b, int i2b, int i3b, int zb)
		{
			var ttl74153 = new TTL74153(TTLGateTypeEnum.Perfect);

			ttl74153.Ea.Add(0);
			ttl74153.S0.Add(s0);
			ttl74153.S1.Add(s1);
			ttl74153.I0b.Add(i0b);
			ttl74153.I1b.Add(i1b);
			ttl74153.I2b.Add(i2b);
			ttl74153.I3b.Add(i3b);

			Assert.Equal(zb, ttl74153.Zb(0));
		}

		[Fact]
		public void disable_b_side()
		{
			var ttl74153 = new TTL74153(TTLGateTypeEnum.Perfect);

			ttl74153.Eb.Add(5);

			ttl74153.S0.Add(0);
			ttl74153.S1.Add(0);
			ttl74153.I0b.Add(5);
			ttl74153.I1b.Add(5);
			ttl74153.I2b.Add(5);
			ttl74153.I3b.Add(5);

			Assert.Equal(0, ttl74153.Zb(0));
		}
	}
}
