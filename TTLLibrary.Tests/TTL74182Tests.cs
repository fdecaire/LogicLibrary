using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74182Tests
	{
		[Theory]
		[InlineData(5, 5, 5, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5)]
		public void cnx_tests(int cn, int g0, int p0, int cnx)
		{
			var ttl74182 = new TTL74182(TTLGateTypeEnum.Perfect);

			ttl74182.Cn.Add(cn);
			ttl74182.G0.Add(g0);
			ttl74182.P0.Add(p0);

			Assert.True(ttl74182.VerifyAllGateInputsConnected());
			Assert.True(ttl74182.VerifyNoShortedOutputs());

			Assert.Equal(cnx, ttl74182.Cnx(0));
		}

		[Theory]
		[InlineData(5, 5, 5, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5)]
		public void cny_tests(int cn, int g1, int p1, int cny)
		{
			var ttl74182 = new TTL74182(TTLGateTypeEnum.Perfect);

			ttl74182.Cn.Add(cn);
			ttl74182.G0.Add(5);
			ttl74182.P0.Add(0);
			ttl74182.G1.Add(g1);
			ttl74182.P1.Add(p1);

			Assert.True(ttl74182.VerifyAllGateInputsConnected());
			Assert.True(ttl74182.VerifyNoShortedOutputs());

			Assert.Equal(cny, ttl74182.Cny(0));
		}

		[Theory]
		[InlineData(5, 5, 5, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5)]
		public void cnz_tests(int cn, int g2, int p2, int cnz)
		{
			var ttl74182 = new TTL74182(TTLGateTypeEnum.Perfect);

			ttl74182.Cn.Add(cn);
			ttl74182.G0.Add(5);
			ttl74182.P0.Add(0);
			ttl74182.G1.Add(5);
			ttl74182.P1.Add(0);
			ttl74182.G2.Add(g2);
			ttl74182.P2.Add(p2);

			Assert.True(ttl74182.VerifyAllGateInputsConnected());
			Assert.True(ttl74182.VerifyNoShortedOutputs());

			Assert.Equal(cnz, ttl74182.Cnz(0));
		}
	}
}
