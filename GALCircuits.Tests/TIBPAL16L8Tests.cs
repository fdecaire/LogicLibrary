using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GALCircuits.Tests
{
    public class TIBPAL16L8Tests
    {
	    [Fact]
	    public void test()
	    {
		    var circuitUnderTest = new TIBPAL16L8();

			circuitUnderTest.Fuses.Add(32);

			circuitUnderTest.I1.Add(0);
			circuitUnderTest.I2.Add(5);
			circuitUnderTest.I3.Add(0);
			circuitUnderTest.I4.Add(0);
			circuitUnderTest.I5.Add(0);
			circuitUnderTest.I6.Add(0);
			circuitUnderTest.I7.Add(0);
			circuitUnderTest.I8.Add(0);
			circuitUnderTest.I9.Add(0);
			circuitUnderTest.I11.Add(0);

			Assert.Equal(5, circuitUnderTest.O19(0));

	    }
    }
}
