using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using LogicLibrary;

namespace GALCircuits
{
	// emulate a TIBPAL16L8-10C circuit
	public class GAL16V8 : Circuit
	{
		// this will be the list of fuse numbers that remain.  All others are blown.
		public List<int> Fuses { get; set; } = new List<int>();

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

		private double OutputResult(Wire input, int outputNumber, int startingFuse, int timing)
		{
			CheckForFeedbackInputs(startingFuse, startingFuse + 255, timing);

			// enable/disable line
			if (IsRowEnabled(startingFuse) && !GetResultsFromRow(startingFuse))
			{
				return ActiveLevel(outputNumber, 0);
			}

			// search for fuses 0-255
			for (int i = 1; i < 8; i++)
			{
				if (IsRowEnabled(i * 32 + startingFuse))
				{
					bool result = GetResultsFromRow(i * 32 + startingFuse);

					// row 0 (0 - 31)
					if (result)
					{
						// if any result is true, then the OR gate is true
						if (input != null)
						{
							UpdateInputFeedback(input, timing, ActiveLevel(outputNumber, 5));
						}
						return ActiveLevel(outputNumber, 5);
					}
				}
			}

			if (input != null)
			{
				UpdateInputFeedback(input, timing, ActiveLevel(outputNumber, 0));
			}
			return ActiveLevel(outputNumber, 0);
		}

		private bool IsRowEnabled(int rowNumber)
		{
			//2128 - 2191 PTD
			int fuseNumber = (rowNumber / 32) + 2128;

			// if the fuse is active, then the row is disabled
			return (!Fuses.Contains(fuseNumber));
		}

		private double ActiveLevel(int outputNumber, double outputVoltage)
		{
			int fuseNumber = 0;

			switch (outputNumber)
			{
				case 19:
					fuseNumber = 2048;
					break;
				case 18:
					fuseNumber = 2049;
					break;
				case 17:
					fuseNumber = 2050;
					break;
				case 16:
					fuseNumber = 2051;
					break;
				case 15:
					fuseNumber = 2052;
					break;
				case 14:
					fuseNumber = 2053;
					break;
				case 13:
					fuseNumber = 2054;
					break;
				case 12:
					fuseNumber = 2055;
					break;
			}

			if (Fuses.Contains(fuseNumber))
			{
				return outputVoltage.Inverted();
			}
			return outputVoltage;
		}

		private void UpdateInputFeedback(Wire input, int timing, double result)
		{
			if (input.Count <= timing)
			{
				while (input.Count <= timing)
				{
					input.Add(result);
				}
			}
			else
			{
				input.Inputs[0].InputSample[timing].Voltage = result;
			}
		}

		private void CheckForFeedbackInputs(int blockStart, int blockEnd, int timing)
		{
			// test if any inputs have fuses that connect to the OLMC outputs
			// columns 6 & 7, 10 & 11, 14 & 15, 18 & 19, 22 & 23, 26 & 27
			foreach (var f in Fuses)
			{
				if (f >= blockStart && f <= blockEnd)
				{
					switch (f % 32)
					{
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
						case 17:
							O13(timing);
							break;
					}
				}
			}
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
						// one false fuse causes the AND gate to be false
						return false;
					}
				}
			}

			return result;
		}

		private double GetInputForFuseNumber(int fuseNumber)
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

		//TODO: add logic to handle different OLMC configurations with bits 2192 and 2193
		//TODO: add logic to handle PTDs

		//TODO: move this method to a base class
		public void LoadJEDEC(string fileName)
		{
			var assembly = Assembly.GetCallingAssembly();
			using (var stream = assembly.GetManifestResourceStream(fileName))
			{
				if (stream == null)
				{
					throw new Exception("Cannot find JEDEC data file, make sure it is set to Embedded Resource!");
				}
				using (var reader = new StreamReader(stream))
				{
					// find *L
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						if (line != null && line.Contains("*L"))
						{
							int address = int.Parse(line.Substring(2, 5));
							for (int i = 0; i < 32 && i + 8 < line.Length; i++)
							{
								if (line.Substring(i + 8, 1) == "0")
								{
									Fuses.Add(address + i);
								}
							}
						}
					}
				}
			}
		}

		public void SaveJEDEC(string fileName)
		{
			//TODO: provide a save method to save the fuse map to an external file
		}

		public void LoadPDS(string fileName)
		{
			//TODO: parse a PDS file and translate into a fuse map
		}
	}
}
