using LogicLibrary;

namespace GALCircuits
{
	// emulate a TIBPAL16L8-10C circuit
	public class GAL16V8 : GateArrayLogic
	{
		public Wire I1 { get; set; } = new Wire {CircuitName = "I1"}; // input on pin 1
		public Wire I2 { get; set; } = new Wire {CircuitName = "I2"}; // input on pin 2
		public Wire I3 { get; set; } = new Wire {CircuitName = "I3"}; // input on pin 3
		public Wire I4 { get; set; } = new Wire {CircuitName = "I4"}; // input on pin 4
		public Wire I5 { get; set; } = new Wire {CircuitName = "I5"}; // input on pin 5
		public Wire I6 { get; set; } = new Wire {CircuitName = "I6"}; // input on pin 6
		public Wire I7 { get; set; } = new Wire {CircuitName = "I7"}; // input on pin 7
		public Wire I8 { get; set; } = new Wire {CircuitName = "I8"}; // input on pin 8
		public Wire I9 { get; set; } = new Wire {CircuitName = "I9"}; // input on pin 9
		public Wire I11 { get; set; } = new Wire {CircuitName = "I11"}; // input on pin 11

		// optional inputs (also output feedbacks from OLMC blocks)
		public Wire I13 { get; set; } = new Wire {CircuitName = "I13"}; // input on pin 13
		public Wire I14 { get; set; } = new Wire {CircuitName = "I14"}; // input on pin 14
		public Wire I15 { get; set; } = new Wire {CircuitName = "I15"}; // input on pin 15
		public Wire I16 { get; set; } = new Wire {CircuitName = "I16"}; // input on pin 16
		public Wire I17 { get; set; } = new Wire {CircuitName = "I17"}; // input on pin 17
		public Wire I18 { get; set; } = new Wire {CircuitName = "I18"}; // input on pin 18

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

		public double O13(int timing)
		{
			return OutputResult(I13, 13, 1536, timing);
		}

		public double O12(int timing)
		{
			return OutputResult(null, 12, 1792, timing);
		}

		public GAL16V8()
		{
			FusesPerRow = 32;
			RowEnableStartFuse = 2128;
			HasPtdFuses = true;

			for (int i = 0; i < 8; i++)
			{
				OlmcUnits.Add(new OLMC
				{
					TotalRows = 8,
					S0FuseNumber = i + 2048,
					S1FuseNumber = i + 2120,
					OutputPin = 19 - i
				});
			}
		}

		public override void CheckForFeedbackInputs(int blockStart, int blockEnd, int timing)
		{
			// test if any inputs have fuses that connect to the OLMC outputs
			// columns 6 & 7, 10 & 11, 14 & 15, 18 & 19, 22 & 23, 26 & 27
			foreach (var f in Fuses)
			{
				if (f >= blockStart && f <= blockEnd)
				{
					switch (f % 32)
					{
						// registered mode only
						case 2:
						case 3:
							//O19(timing);
							break;
						case 6:
						case 7:
							O18(timing);
							break;
						case 10:
						case 11:
							O17(timing);
							break;
						case 14:
						case 15:
							O16(timing);
							break;
						case 18:
						case 19:
							O15(timing);
							break;
						case 22:
						case 23:
							O14(timing);
							break;
						case 26:
						case 27:
							O13(timing);
							break;
						// registered mode only
						case 30:
						case 31:
							//O12(timing);
							break;

					}
				}
			}
		}

		public override double GetInputForFuseNumber(int fuseNumber)
		{
			switch (fuseNumber % 32)
			{
				case 0:
					return I2.Output(0);
				case 1:
					return I2.Output(0).Inverted();
				case 2:
					return I1.Output(0);
				case 3:
					return I1.Output(0).Inverted();
				case 4:
					return I3.Output(0);
				case 5:
					return I3.Output(0).Inverted();
				case 6:
					return I18.Output(0);
				case 7:
					return I18.Output(0).Inverted();
				case 8:
					return I4.Output(0);
				case 9:
					return I4.Output(0).Inverted();
				case 10:
					return I17.Output(0);
				case 11:
					return I17.Output(0).Inverted();
				case 12:
					return I5.Output(0);
				case 13:
					return I5.Output(0).Inverted();
				case 14:
					return I16.Output(0);
				case 15:
					return I16.Output(0).Inverted();
				case 16:
					return I6.Output(0);
				case 17:
					return I6.Output(0).Inverted();
				case 18:
					return I15.Output(0);
				case 19:
					return I15.Output(0).Inverted();
				case 20:
					return I7.Output(0);
				case 21:
					return I7.Output(0).Inverted();
				case 22:
					return I14.Output(0);
				case 23:
					return I14.Output(0).Inverted();
				case 24:
					return I8.Output(0);
				case 25:
					return I8.Output(0).Inverted();
				case 26:
					return I13.Output(0);
				case 27:
					return I13.Output(0).Inverted();
				case 28:
					return I9.Output(0);
				case 29:
					return I9.Output(0).Inverted();
				case 30:
					return I11.Output(0);
				case 31:
					return I11.Output(0).Inverted();
			}
			return 0;
		}
	}
}
