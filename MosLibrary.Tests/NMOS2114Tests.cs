using Xunit;
using MosLibrary;

namespace MosLibrary.Tests
{
    public class NMOS2114Tests
    {
	    [Fact]
	    public void store_and_read_data()
	    {
		    // store into one cell and read it back
		    var memory = new NMOS2114();

		    memory.A0.Add(0);
			memory.A1.Add(0);
			memory.A2.Add(0);
			memory.A3.Add(0);
			memory.A4.Add(0);
			memory.A5.Add(0);
			memory.A6.Add(0);
			memory.A7.Add(0);
			memory.A8.Add(0);
			memory.A9.Add(0);

			memory.I0.Add(5);
			memory.I1.Add(0);
			memory.I2.Add(0);
			memory.I3.Add(5);

		    memory.W = 0;
		    memory.S.Add(0);

		    Assert.Equal(5, memory.O0(0));
			Assert.Equal(0, memory.O1(0));
			Assert.Equal(0, memory.O2(0));
			Assert.Equal(5, memory.O3(0));

		    memory.A2.Inputs[0].InputSample[0].Voltage = 5;

			Assert.Equal(0, memory.O0(0));
			Assert.Equal(0, memory.O1(0));
			Assert.Equal(0, memory.O2(0));
			Assert.Equal(0, memory.O3(0));
		}
    }
}
