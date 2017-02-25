using LogicLibrary;
using Xunit;

namespace DigitalLogicExperiments.Tests
{
    public class TTL8BitALUCircuitTests
    {
	    [Fact]
	    public void f_equals_a()
	    {
		    var alu = new TTL8BitALUCircuit(TTLGateTypeEnum.Perfect);
		    alu.Cin.Add(0);
		    alu.S0.Add(5);
		    alu.S1.Add(5);
		    alu.S2.Add(5);
		    alu.S3.Add(5);

		    alu.A0.Add(0);
		    alu.A1.Add(0);
		    alu.A2.Add(0);
		    alu.A3.Add(5);
		    alu.A4.Add(5);
		    alu.A5.Add(0);
		    alu.A6.Add(0);
		    alu.A7.Add(0);

		    alu.B0.Add(0);
		    alu.B1.Add(0);
		    alu.B2.Add(0);
		    alu.B3.Add(0);
		    alu.B4.Add(0);
		    alu.B5.Add(0);
		    alu.B6.Add(0);
		    alu.B7.Add(0);

		    Assert.Equal(0, alu.F0(0));
		    Assert.Equal(0, alu.F1(0));
		    Assert.Equal(0, alu.F2(0));
		    Assert.Equal(5, alu.F3(0));
		    Assert.Equal(5, alu.F4(0));
		    Assert.Equal(0, alu.F5(0));
		    Assert.Equal(0, alu.F6(0));
		    Assert.Equal(0, alu.F7(0));
	    }

	    [Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void a_plus_b(int a0, int b0, int f0, int f1)
	    {
			var alu = new TTL8BitALUCircuit(TTLGateTypeEnum.Perfect);
			alu.Cin.Add(5);
			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);

			alu.A0.Add(a0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);
			alu.A4.Add(0);
			alu.A5.Add(0);
			alu.A6.Add(0);
			alu.A7.Add(0);

			alu.B0.Add(b0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(0);
			alu.B4.Add(0);
			alu.B5.Add(0);
			alu.B6.Add(0);
			alu.B7.Add(0);

			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(0, alu.F2(0));
			Assert.Equal(0, alu.F3(0));
			Assert.Equal(0, alu.F4(0));
			Assert.Equal(0, alu.F5(0));
			Assert.Equal(0, alu.F6(0));
			Assert.Equal(0, alu.F7(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5)]
		public void a_plus_b_carrythrough(int a3, int b3, int f3, int f4)
		{
			var alu = new TTL8BitALUCircuit(TTLGateTypeEnum.Perfect);
			alu.Cin.Add(5);
			alu.S0.Add(5);
			alu.S1.Add(0);
			alu.S2.Add(0);
			alu.S3.Add(5);

			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(a3);
			alu.A4.Add(0);
			alu.A5.Add(0);
			alu.A6.Add(0);
			alu.A7.Add(0);

			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(b3);
			alu.B4.Add(0);
			alu.B5.Add(0);
			alu.B6.Add(0);
			alu.B7.Add(0);

			Assert.Equal(0, alu.F0(0));
			Assert.Equal(0, alu.F1(0));
			Assert.Equal(0, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
			Assert.Equal(f4, alu.F4(0));
			Assert.Equal(0, alu.F5(0));
			Assert.Equal(0, alu.F6(0));
			Assert.Equal(0, alu.F7(0));
		}
	}
}
