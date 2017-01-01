using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74157Tests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(5, 0, 5, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0)]
		[InlineData(5, 5, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5)]
		public void TTL74157_test(double A1, double B1, double A2, double B2, double A3, double B3, double A4, double B4,
	double Y1, double Y2, double Y3, double Y4, double select)
		{
			var multiplexer = new TTL74157(TTLGateTypeEnum.Perfect);

			multiplexer.A1.Add(A1);
			multiplexer.B1.Add(B1);
			multiplexer.A2.Add(A2);
			multiplexer.B2.Add(B2);
			multiplexer.A3.Add(A3);
			multiplexer.B3.Add(B3);
			multiplexer.A4.Add(A4);
			multiplexer.B4.Add(B4);
			multiplexer.Select.Add(select);
			multiplexer.Strobe.Add(0);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.VerifyNoShortedOutputs());
			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(Y1, multiplexer.Y1(0));
			Assert.Equal(Y2, multiplexer.Y2(0));
			Assert.Equal(Y3, multiplexer.Y3(0));
			Assert.Equal(Y4, multiplexer.Y4(0));
		}

		[Fact]
		public void TTL74157_strobe_test()
		{
			var multiplexer = new TTL74157(TTLGateTypeEnum.Perfect);

			multiplexer.A1.Add(5);
			multiplexer.B1.Add(5);
			multiplexer.A2.Add(5);
			multiplexer.B2.Add(5);
			multiplexer.A3.Add(5);
			multiplexer.B3.Add(5);
			multiplexer.A4.Add(5);
			multiplexer.B4.Add(5);
			multiplexer.Select.Add(0);
			multiplexer.Strobe.Add(5);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.VerifyNoShortedOutputs());
			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(0, multiplexer.Y1(0));
			Assert.Equal(0, multiplexer.Y2(0));
			Assert.Equal(0, multiplexer.Y3(0));
			Assert.Equal(0, multiplexer.Y4(0));
		}
	}
}
