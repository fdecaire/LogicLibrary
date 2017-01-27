using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74283Tests
	{
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 0, 0, 0, 5, 0, 5, 0)]
		[InlineData(0, 0, 0, 5, 0, 0, 5, 0)]
		[InlineData(0, 0, 0, 5, 5, 5, 0, 0)]
		[InlineData(0, 0, 5, 0, 0, 5, 0, 0)]
		[InlineData(0, 0, 5, 0, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 0, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 0, 0, 5, 0, 0)]
		[InlineData(0, 5, 0, 0, 5, 5, 5, 0)]
		[InlineData(0, 5, 0, 5, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 5, 5, 0, 0, 5)]
		[InlineData(0, 5, 5, 0, 0, 0, 0, 5)]
		[InlineData(0, 5, 5, 0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 5, 0, 0, 5, 5)]
		[InlineData(0, 5, 5, 5, 5, 5, 0, 5)]
		[InlineData(5, 0, 0, 0, 0, 0, 5, 0)]
		[InlineData(5, 0, 0, 0, 5, 5, 0, 0)]
		[InlineData(5, 0, 0, 5, 0, 5, 0, 0)]
		[InlineData(5, 0, 0, 5, 5, 5, 5, 0)]
		[InlineData(5, 0, 5, 0, 0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0, 0, 5)]
		[InlineData(5, 0, 5, 5, 0, 0, 0, 5)]
		[InlineData(5, 0, 5, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0, 0, 5, 5, 0)]
		[InlineData(5, 5, 0, 0, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 0, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 0, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 5, 5, 5, 5)]
		public void ttl_74283(int Cin, int B2, int A2, int B1, int A1, int S2, int S1, int S3)
		{
			var adder = new TTL74283(TTLGateTypeEnum.Perfect);
			adder.A1.Add(A1);
			adder.B1.Add(B1);
			adder.A2.Add(A2);
			adder.B2.Add(B2);
			adder.Cin.Add(Cin);

			Assert.True(adder.VerifyAllGateInputsConnected());
			Assert.True(adder.VerifyNoShortedOutputs());

			Assert.Equal(S1, adder.S1(0));
			Assert.Equal(S2, adder.S2(0));
			Assert.Equal(S3, adder.S3(0));
		}
	}
}
