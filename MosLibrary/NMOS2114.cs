using System.Collections.Generic;
using LogicLibrary;

namespace MosLibrary
{
    public class NMOS2114 : Circuit
    {
		// 4k bit memory
		private List<double> memoryCells = new List<double>();

		public Wire A0 { get; set; } = new Wire { CircuitName = "A0" };
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire A2 { get; set; } = new Wire { CircuitName = "A2" };
		public Wire A3 { get; set; } = new Wire { CircuitName = "A3" };
		public Wire A4 { get; set; } = new Wire { CircuitName = "A4" };
		public Wire A5 { get; set; } = new Wire { CircuitName = "A5" };
		public Wire A6 { get; set; } = new Wire { CircuitName = "A6" };
		public Wire A7 { get; set; } = new Wire { CircuitName = "A7" };
		public Wire A8 { get; set; } = new Wire { CircuitName = "A8" };
		public Wire A9 { get; set; } = new Wire { CircuitName = "A9" };

	    public int W
	    {
		    set
		    {
			    if (value == 0)
			    {
				    //TODO: need to convert all this from input values into true/false one instance at a time
				    memoryCells[ComputeAddress(0)] = I0.Inputs[0].InputSample[0].Voltage;
				    memoryCells[ComputeAddress(0) + 1024] = I1.Inputs[0].InputSample[0].Voltage;
				    memoryCells[ComputeAddress(0) + 2048] = I2.Inputs[0].InputSample[0].Voltage;
				    memoryCells[ComputeAddress(0) + 3072] = I3.Inputs[0].InputSample[0].Voltage;
			    }
		    }
	    }
		public Wire S { get; set; } = new Wire { CircuitName = "S" };

		public Wire I0 { get; set; } = new Wire { CircuitName = "I0" };
		public Wire I1 { get; set; } = new Wire { CircuitName = "I1" };
		public Wire I2 { get; set; } = new Wire { CircuitName = "I2" };
		public Wire I3 { get; set; } = new Wire { CircuitName = "I3" };

		public double O0(int timing)
		{
			RunIteration(timing);

			return GetMemoryData(0,timing);
		}

	    public double O1(int timing)
		{
			RunIteration(timing);

			return GetMemoryData(1, timing);
		}

		public double O2(int timing)
		{
			RunIteration(timing);

			return GetMemoryData(2, timing);
		}

		public double O3(int timing)
		{
			RunIteration(timing);

			return GetMemoryData(3, timing);
		}

	    public NMOS2114()
	    {
		    for (int i = 0; i < 4096; i++)
		    {
			    memoryCells.Add(0);
		    }
	    }

	    private double GetMemoryData(int outputNumber, int timing)
	    {
		    return memoryCells[ComputeAddress(timing) + (outputNumber * 1024)];
	    }

	    private int ComputeAddress(int timing)
	    {
			int address = A0.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0;

			address += A1.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 2;
			address += A2.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 4;
			address += A3.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 8;
			address += A4.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 16;
			address += A5.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 32;
			address += A6.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 64;
			address += A7.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 128;
			address += A8.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 256;
			address += A9.Inputs[0].InputSample[timing].Voltage > 2.7 ? 1 : 0 * 512;

		    return address;
	    }
    }
}
