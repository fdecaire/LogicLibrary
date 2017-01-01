using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL7447Tests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5)] // 0
		[InlineData(0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)] // 1
		[InlineData(0, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0)] // 2
		[InlineData(0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 0)] // 3
		[InlineData(0, 5, 0, 0, 5, 0, 0, 5, 5, 0, 0)] // 4
		[InlineData(0, 5, 0, 5, 0, 5, 0, 0, 5, 0, 0)] // 5
		[InlineData(0, 5, 5, 0, 5, 5, 0, 0, 0, 0, 0)] // 6
		[InlineData(0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5)] // 7
		[InlineData(5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)] // 8
		[InlineData(5, 0, 0, 5, 0, 0, 0, 5, 5, 0, 0)] // 9
		[InlineData(5, 0, 5, 0, 5, 5, 5, 0, 0, 5, 0)] // 10
		[InlineData(5, 0, 5, 5, 5, 5, 0, 0, 5, 5, 0)] // 11
		[InlineData(5, 5, 0, 0, 5, 0, 5, 5, 5, 0, 0)] // 12
		[InlineData(5, 5, 0, 5, 0, 5, 5, 0, 5, 0, 0)] // 13
		[InlineData(5, 5, 5, 0, 5, 5, 5, 0, 0, 0, 0)] // 14
		[InlineData(5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)] // 15
		public void TTL7447_test(double D, double C, double B, double A, double outa, double outb, double outc,
	double outd, double oute, double outf, double outg)
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(A);
			decoder.B.Add(B);
			decoder.C.Add(C);
			decoder.D.Add(D);
			decoder.RBI.Add(5);
			decoder.LampTest.Add(5);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(outa, decoder.Segmenta(0));
			Assert.Equal(outb, decoder.Segmentb(0));
			Assert.Equal(outc, decoder.Segmentc(0));
			Assert.Equal(outd, decoder.Segmentd(0));
			Assert.Equal(oute, decoder.Segmente(0));
			Assert.Equal(outf, decoder.Segmentf(0));
			Assert.Equal(outg, decoder.Segmentg(0));
		}

		[Fact]
		public void TTL7447_rbi_test()
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(0);
			decoder.B.Add(0);
			decoder.C.Add(0);
			decoder.D.Add(0);
			decoder.RBI.Add(0);
			decoder.LampTest.Add(5);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(5, decoder.Segmenta(0));
			Assert.Equal(5, decoder.Segmentb(0));
			Assert.Equal(5, decoder.Segmentc(0));
			Assert.Equal(5, decoder.Segmentd(0));
			Assert.Equal(5, decoder.Segmente(0));
			Assert.Equal(5, decoder.Segmentf(0));
			Assert.Equal(5, decoder.Segmentg(0));
		}

		[Fact]
		public void TTL7447_lamp_test()
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(5);
			decoder.B.Add(0);
			decoder.C.Add(0);
			decoder.D.Add(0);
			decoder.RBI.Add(5);
			decoder.LampTest.Add(0);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(0, decoder.Segmenta(0));
			Assert.Equal(0, decoder.Segmentb(0));
			Assert.Equal(0, decoder.Segmentc(0));
			Assert.Equal(0, decoder.Segmentd(0));
			Assert.Equal(0, decoder.Segmente(0));
			Assert.Equal(0, decoder.Segmentf(0));
			Assert.Equal(0, decoder.Segmentg(0));
		}
	}
}
