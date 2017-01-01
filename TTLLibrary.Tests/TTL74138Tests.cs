using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74138Tests
	{
		[Fact]
		public void ttl_74138_disabled()
		{
			var multiplexer = new TTL74138(TTLGateTypeEnum.Perfect);

			multiplexer.G1.Add(0);
			multiplexer.G2A.Add(0);
			multiplexer.G2B.Add(0);
			multiplexer.A.Add(0);
			multiplexer.B.Add(0);
			multiplexer.C.Add(0);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.VerifyNoShortedOutputs());
			Assert.True(multiplexer.VerifyAllGateInputsConnected());
			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(5, multiplexer.Y0(0));
			Assert.Equal(5, multiplexer.Y1(0));
			Assert.Equal(5, multiplexer.Y2(0));
			Assert.Equal(5, multiplexer.Y3(0));
			Assert.Equal(5, multiplexer.Y4(0));
			Assert.Equal(5, multiplexer.Y5(0));
			Assert.Equal(5, multiplexer.Y6(0));
			Assert.Equal(5, multiplexer.Y7(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5)]
		[InlineData(0, 0, 5, 5, 0, 5, 5, 5, 5, 5, 5)]
		[InlineData(0, 5, 0, 5, 5, 0, 5, 5, 5, 5, 5)]
		[InlineData(0, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 5, 5, 5, 5, 0, 5, 5, 5)]
		[InlineData(5, 0, 5, 5, 5, 5, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 0, 5, 5, 5, 5, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0)]
		public void ttl_74138(int c, int b, int a, int y0, int y1, int y2, int y3, int y4, int y5, int y6, int y7)
		{
			var multiplexer = new TTL74138(TTLGateTypeEnum.Perfect);

			multiplexer.G1.Add(5);
			multiplexer.G2A.Add(0);
			multiplexer.G2B.Add(0);
			multiplexer.A.Add(a);
			multiplexer.B.Add(b);
			multiplexer.C.Add(c);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.VerifyAllGateInputsConnected());
			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(y0, multiplexer.Y0(0));
			Assert.Equal(y1, multiplexer.Y1(0));
			Assert.Equal(y2, multiplexer.Y2(0));
			Assert.Equal(y3, multiplexer.Y3(0));
			Assert.Equal(y4, multiplexer.Y4(0));
			Assert.Equal(y5, multiplexer.Y5(0));
			Assert.Equal(y6, multiplexer.Y6(0));
			Assert.Equal(y7, multiplexer.Y7(0));
		}
	}
}
