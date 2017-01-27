using Xunit;

namespace GALCircuits.Tests
{
    public class GAL16V8Tests
    {
	    [Theory]
	    [InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5)]
	    [InlineData(0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)]
	    [InlineData(0, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0)]
	    [InlineData(0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 0)]
	    [InlineData(0, 5, 0, 0, 5, 0, 0, 5, 5, 0, 0)]
	    [InlineData(0, 5, 0, 5, 0, 5, 0, 0, 5, 0, 0)]
	    [InlineData(0, 5, 5, 0, 0, 5, 0, 0, 0, 0, 0)]
	    [InlineData(0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5)]
	    [InlineData(5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
	    [InlineData(5, 0, 0, 5, 0, 0, 0, 5, 5, 0, 0)]
	    [InlineData(5, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0)]
	    [InlineData(5, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0)]
	    [InlineData(5, 5, 0, 0, 0, 5, 5, 0, 0, 0, 5)]
	    [InlineData(5, 5, 0, 5, 5, 0, 0, 0, 0, 5, 0)]
	    [InlineData(5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0)]
	    [InlineData(5, 5, 5, 5, 0, 5, 5, 5, 0, 0, 0)]
	    public void hex_display_test(int d3, int d2, int d1, int d0, int A, int B, int C, int D, int E, int F, int G)
	    {
		    var hexDisplay = new GAL16V8();
		    hexDisplay.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

		    hexDisplay.I1.Add(0); // RBI

		    hexDisplay.I2.Add(d0); // D0
		    hexDisplay.I3.Add(d1); // D1
		    hexDisplay.I4.Add(d2); // D2
		    hexDisplay.I5.Add(d3); // D3

		    hexDisplay.I6.Add(0); // IC
		    hexDisplay.I7.Add(0); // LT

		    Assert.Equal(A, hexDisplay.O19(0)); // A
		    Assert.Equal(B, hexDisplay.O18(0)); // B
		    Assert.Equal(C, hexDisplay.O17(0)); // C
		    Assert.Equal(D, hexDisplay.O16(0)); // D
		    Assert.Equal(E, hexDisplay.O15(0)); // E
		    Assert.Equal(F, hexDisplay.O14(0)); // F
			Assert.Equal(G, hexDisplay.O12(0)); // G
	    }
		
	    [Fact]
	    public void lamp_test()
	    {
			var hexDisplay = new GAL16V8();
			hexDisplay.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			hexDisplay.I1.Add(0); // RBI

			hexDisplay.I2.Add(5); // D0
			hexDisplay.I3.Add(0); // D1
			hexDisplay.I4.Add(0); // D2
			hexDisplay.I5.Add(0); // D3

			hexDisplay.I6.Add(0); // IC
			hexDisplay.I7.Add(5); // LT

			Assert.Equal(0, hexDisplay.O19(0)); // A
			Assert.Equal(0, hexDisplay.O18(0)); // B
			Assert.Equal(0, hexDisplay.O17(0)); // C
			Assert.Equal(0, hexDisplay.O16(0)); // D
			Assert.Equal(0, hexDisplay.O15(0)); // E
			Assert.Equal(0, hexDisplay.O14(0)); // F
			Assert.Equal(0, hexDisplay.O12(0)); // G
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5)]
		[InlineData(0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)]
		[InlineData(0, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0)]
		[InlineData(0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 5, 0, 0, 5, 5, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 5, 0, 0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0, 0, 5, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(5, 0, 0, 5, 0, 0, 0, 5, 5, 0, 0)]
		[InlineData(5, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0)]
		[InlineData(5, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0)]
		[InlineData(5, 5, 0, 0, 0, 5, 5, 0, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5, 0, 0, 0, 0, 5, 0)]
		[InlineData(5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0)]
		[InlineData(5, 5, 5, 5, 0, 5, 5, 5, 0, 0, 0)]
		public void rbi_test(int d3, int d2, int d1, int d0, int A, int B, int C, int D, int E, int F, int G)
		{
			var hexDisplay = new GAL16V8();
			hexDisplay.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			hexDisplay.I1.Add(5); // RBI

			hexDisplay.I2.Add(d0); // D0
			hexDisplay.I3.Add(d1); // D1
			hexDisplay.I4.Add(d2); // D2
			hexDisplay.I5.Add(d3); // D3

			hexDisplay.I6.Add(0); // IC
			hexDisplay.I7.Add(0); // LT

			Assert.Equal(A, hexDisplay.O19(0)); // A
			Assert.Equal(B, hexDisplay.O18(0)); // B
			Assert.Equal(C, hexDisplay.O17(0)); // C
			Assert.Equal(D, hexDisplay.O16(0)); // D
			Assert.Equal(E, hexDisplay.O15(0)); // E
			Assert.Equal(F, hexDisplay.O14(0)); // F
			Assert.Equal(G, hexDisplay.O12(0)); // G
		}
    }
}
