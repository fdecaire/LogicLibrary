using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary;

namespace GALCircuits
{
	public class GAL22V10 : GateArrayLogic
	{
		public Wire I1 { get; set; } = new Wire { CircuitName = "I1" }; // input on pin 1
		public Wire I2 { get; set; } = new Wire { CircuitName = "I2" }; // input on pin 2
		public Wire I3 { get; set; } = new Wire { CircuitName = "I3" }; // input on pin 3
		public Wire I4 { get; set; } = new Wire { CircuitName = "I4" }; // input on pin 4
		public Wire I5 { get; set; } = new Wire { CircuitName = "I5" }; // input on pin 5
		public Wire I6 { get; set; } = new Wire { CircuitName = "I6" }; // input on pin 6
		public Wire I7 { get; set; } = new Wire { CircuitName = "I7" }; // input on pin 7
		public Wire I8 { get; set; } = new Wire { CircuitName = "I8" }; // input on pin 8
		public Wire I9 { get; set; } = new Wire { CircuitName = "I9" }; // input on pin 9
		public Wire I10 { get; set; } = new Wire { CircuitName = "I10" }; // input on pin 10
		public Wire I11 { get; set; } = new Wire { CircuitName = "I11" }; // input on pin 11
		public Wire I13 { get; set; } = new Wire { CircuitName = "I13" }; // input on pin 13

		// optional inputs (also output feedbacks from OLMC blocks)

		public Wire I14 { get; set; } = new Wire { CircuitName = "I14" }; // input on pin 14
		public Wire I15 { get; set; } = new Wire { CircuitName = "I15" }; // input on pin 15
		public Wire I16 { get; set; } = new Wire { CircuitName = "I16" }; // input on pin 16
		public Wire I17 { get; set; } = new Wire { CircuitName = "I17" }; // input on pin 17
		public Wire I18 { get; set; } = new Wire { CircuitName = "I18" }; // input on pin 18
		public Wire I19 { get; set; } = new Wire { CircuitName = "I19" }; // input on pin 19
		public Wire I20 { get; set; } = new Wire { CircuitName = "I20" }; // input on pin 20
		public Wire I21 { get; set; } = new Wire { CircuitName = "I21" }; // input on pin 21
		public Wire I22 { get; set; } = new Wire { CircuitName = "I22" }; // input on pin 22
		public Wire I23 { get; set; } = new Wire { CircuitName = "I23" }; // input on pin 23

		public double O23(int timing)
		{
			return OutputResult(null, 19, 0, timing);
		}

		public double O22(int timing)
		{
			return OutputResult(null, 19, 0, timing);
		}

		public double O21(int timing)
		{
			return OutputResult(null, 19, 0, timing);
		}

		public double O20(int timing)
		{
			return OutputResult(null, 19, 0, timing);
		}

		public double O19(int timing)
		{
			return OutputResult(null, 19, 0, timing);
		}

		public double O18(int timing)
		{
			return OutputResult(I18, 18, 256, timing);
		}

		public double O17(int timing)
		{
			return OutputResult(I17, 17, 512, timing);
		}

		public double O16(int timing)
		{
			return OutputResult(I16, 16, 768, timing);
		}

		public double O15(int timing)
		{
			return OutputResult(I15, 15, 1024, timing);
		}

		public double O14(int timing)
		{
			return OutputResult(I14, 14, 1280, timing);
		}

		public GAL22V10()
		{
			FusesPerRow = 44;
			HasPtdFuses = false;

			OlmcUnits.Add(new OLMC
			{
				TotalRows = 8,
				S0FuseNumber = 5808,
				S1FuseNumber = 5809,
				OutputPin = 23
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 10,
				S0FuseNumber = 5810,
				S1FuseNumber = 5811,
				OutputPin = 22
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 12,
				S0FuseNumber = 5812,
				S1FuseNumber = 5813,
				OutputPin = 21
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 14,
				S0FuseNumber = 5814,
				S1FuseNumber = 5815,
				OutputPin = 20
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 16,
				S0FuseNumber = 5816,
				S1FuseNumber = 5817,
				OutputPin = 19
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 16,
				S0FuseNumber = 5818,
				S1FuseNumber = 5819,
				OutputPin = 18
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 14,
				S0FuseNumber = 5820,
				S1FuseNumber = 5821,
				OutputPin = 17
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 12,
				S0FuseNumber = 5822,
				S1FuseNumber = 5823,
				OutputPin = 16
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 10,
				S0FuseNumber = 5824,
				S1FuseNumber = 5825,
				OutputPin = 15
			});
			OlmcUnits.Add(new OLMC
			{
				TotalRows = 8,
				S0FuseNumber = 5826,
				S1FuseNumber = 5827,
				OutputPin = 14
			});
		}

		public override void CheckForFeedbackInputs(int blockStart, int blockEnd, int timing)
		{
			// test if any inputs have fuses that connect to the OLMC outputs
			// columns 6 & 7, 10 & 11, 14 & 15, 18 & 19, 22 & 23, 26 & 27, 
			foreach (var f in Fuses)
			{
				if (f >= blockStart && f <= blockEnd)
				{
					switch (f % 44)
					{
						case 2:
						case 3:
							O23(timing);
							break;
						case 6:
						case 7:
							O22(timing);
							break;
						case 10:
						case 11:
							O21(timing);
							break;
						case 14:
						case 15:
							O20(timing);
							break;
						case 18:
						case 19:
							O19(timing);
							break;
						case 22:
						case 23:
							O18(timing);
							break;
						case 26:
						case 27:
							O17(timing);
							break;
						case 30:
						case 31:
							O16(timing);
							break;
						case 34:
						case 35:
							O15(timing);
							break;
						case 39:
						case 40:
							O14(timing);
							break;
					}
				}
			}
		}

		public override double GetInputForFuseNumber(int fuseNumber)
		{
			switch (fuseNumber % 44)
			{
				case 0:
					return I1.Output(0);
				case 1:
					return I1.Output(0).Inverted();
				case 2:
					return I23.Output(0);
				case 3:
					return I23.Output(0).Inverted();
				case 4:
					return I2.Output(0);
				case 5:
					return I2.Output(0).Inverted();
				case 6:
					return I22.Output(0);
				case 7:
					return I22.Output(0).Inverted();
				case 8:
					return I3.Output(0);
				case 9:
					return I3.Output(0).Inverted();
				case 10:
					return I21.Output(0);
				case 11:
					return I21.Output(0).Inverted();
				case 12:
					return I4.Output(0);
				case 13:
					return I4.Output(0).Inverted();
				case 14:
					return I20.Output(0);
				case 15:
					return I20.Output(0).Inverted();
				case 16:
					return I5.Output(0);
				case 17:
					return I5.Output(0).Inverted();
				case 18:
					return I19.Output(0);
				case 19:
					return I19.Output(0).Inverted();
				case 20:
					return I6.Output(0);
				case 21:
					return I6.Output(0).Inverted();
				case 22:
					return I18.Output(0);
				case 23:
					return I18.Output(0).Inverted();
				case 24:
					return I7.Output(0);
				case 25:
					return I7.Output(0).Inverted();
				case 26:
					return I17.Output(0);
				case 27:
					return I17.Output(0).Inverted();
				case 28:
					return I8.Output(0);
				case 29:
					return I8.Output(0).Inverted();
				case 30:
					return I16.Output(0);
				case 31:
					return I16.Output(0).Inverted();
				case 32:
					return I9.Output(0);
				case 33:
					return I9.Output(0).Inverted();
				case 34:
					return I15.Output(0);
				case 35:
					return I15.Output(0).Inverted();
				case 36:
					return I10.Output(0);
				case 37:
					return I10.Output(0).Inverted();
				case 38:
					return I14.Output(0);
				case 39:
					return I14.Output(0).Inverted();
				case 40:
					return I11.Output(0);
				case 41:
					return I11.Output(0).Inverted();
				case 42:
					return I13.Output(0);
				case 43:
					return I13.Output(0).Inverted();
			}
			return 0;
		}
	}
}
