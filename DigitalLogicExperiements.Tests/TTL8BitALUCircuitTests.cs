using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
