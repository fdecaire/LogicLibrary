using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace GALCircuits
{
	// emulate a TIBPAL16L8-10C circuit
    public class TIBPAL16L8 : Circuit
    {
		// this will be the list of fuse numbers that remain.  All others are blown.
		// 0 - 2047
		public List<int> Fuses { get; set; } = new List<int>();

		public Wire I1 { get; set; } = new Wire { CircuitName = "I1" }; // input on pin 1
		public Wire I2 { get; set; } = new Wire { CircuitName = "I2" }; // input on pin 2
		public Wire I3 { get; set; } = new Wire { CircuitName = "I3" }; // input on pin 3
		public Wire I4 { get; set; } = new Wire { CircuitName = "I4" }; // input on pin 4
		public Wire I5 { get; set; } = new Wire { CircuitName = "I5" }; // input on pin 5
		public Wire I6 { get; set; } = new Wire { CircuitName = "I6" }; // input on pin 6
		public Wire I7 { get; set; } = new Wire { CircuitName = "I7" }; // input on pin 7
		public Wire I8 { get; set; } = new Wire { CircuitName = "I8" }; // input on pin 8
		public Wire I9 { get; set; } = new Wire { CircuitName = "I9" }; // input on pin 9
		public Wire I11 { get; set; } = new Wire { CircuitName = "I11" }; // input on pin 11

		public double O19(int timing)
		{
			// TODO: search for fuses 0-255
			for (int i = 0; i < 8; i++)
			{
				bool result = GetResultsFromRow(i*32);

				// row 0 (0 - 31)
				if (result)
				{
					return 5;
				}
			}

			//TODO: need to handle the enable logic and the feedback logic
			return 0;
		}

	    public double O18(int timing)
		{
			return Gates[1].Output(timing);
		}

		//TODO: more outputs...

		public TIBPAL16L8()
	    {

		    // Output pin 19 = fuses 0 - 255
		    // Output pin 18 = fuses 256 - 511
		    // Output pin 17 = fuses 512 - 767
		    // Output pin 16 = fuses 768 - 1023
		    // Output pin 15 = fuses 1024 - 1279
		    // Output pin 14 = fuses 1280 - 1535
		    // Output pin 13 = fuses 1536 - 1791
		    // Output pin 12 = fuses 1792 - 2047


	    }

		private bool GetResultsFromRow(int rowStart)
		{
			bool result = false; // if there are no fuses, then this row doesn't count
			foreach (var f in Fuses)
			{
				if (f >= rowStart && f < rowStart + 32)
				{
					result = true; // if this row contains at least one fuse, then check the input signal
					if (GetInputForFuseNumber(f) < 0.2)
					{
						return false;
					}
				}
			}

			return result;
		}

		private double GetInputForFuseNumber(int fuseNumber)
		{
			// I2 = fuse % 0 & 1
			// I1 = fuse % 2 & 3
			// I3 = fuse % 4 & 5
			// I4 = fuse % 8 & 9
			// I5 = fuse % 12 & 13
			// I6 = fuse % 16 & 17
			// I7 = fuse % 20 & 21
			// I8 = fuse % 24 & 25
			// I9 = fuse % 28 & 29
			// I11 = fuse % 30 & 31

			switch (fuseNumber%32)
			{
				case 0:
					return I2.Output(0);
				case 1:
					if (I2.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 2:
					return I1.Output(0);
				case 3:
					if (I1.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 4:
					return I3.Output(0);
				case 5:
					if (I3.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 8:
					return I4.Output(0);
				case 9:
					if (I4.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 12:
					return I5.Output(0);
				case 13:
					if (I5.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 16:
					return I6.Output(0);
				case 17:
					if (I6.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 20:
					return I7.Output(0);
				case 21:
					if (I7.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 24:
					return I8.Output(0);
				case 25:
					if (I8.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 28:
					return I9.Output(0);
				case 29:
					if (I9.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
				case 30:
					return I11.Output(0);
				case 31:
					if (I11.Output(0) < 0.2)
					{
						return 5;
					}
					return 0;
			}
			return 0;
		}
	}
}
