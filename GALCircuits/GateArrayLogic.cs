using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using LogicLibrary;

namespace GALCircuits
{
	public abstract class GateArrayLogic : Circuit
	{
		// this will be the list of fuse numbers that remain.  All others are blown.
		public List<int> Fuses { get; set; } = new List<int>();
		public int FusesPerRow { get; set; }
		public int RowEnableStartFuse { get; set; }
		public List<OLMC> OlmcUnits { get; set; } = new List<OLMC>();
		public bool HasPtdFuses { get; set; }

		private GalModeEnum _mode = GalModeEnum.Unknown;
		public GalModeEnum Mode
		{
			get
			{
				if (_mode == GalModeEnum.Unknown)
				{
					SetMode();
				}
				return _mode;
			}
		}

		private void SetMode()
		{
			if (Fuses.Contains(2192) && Fuses.Contains(2193))
			{
				// complex syn=1, ac0=1
				_mode = GalModeEnum.Complex;
			}
			else if (Fuses.Contains(2192))
			{
				// simple syn=1, ac0=0
				_mode = GalModeEnum.Simple;
			}
			else
			{
				// registered syn=0, ac0=1
				_mode = GalModeEnum.Registered;
			}
		}

		public double OutputResult(Wire input, int outputNumber, int startingFuse, int timing)
		{
			//TODO: need to account for a possible 44 fuses
			// need number of fuses per column * rows per olmc
			CheckForFeedbackInputs(startingFuse, startingFuse + 255, timing);

			//TODO: need to handle dedicated inputs (simple mode where ac1=1)

			// enable/disable line
			//TODO: mode only used by GAL16V8
			if (Mode != GalModeEnum.Simple)
			{
				if (IsRowEnabled(startingFuse) && !GetResultsFromRow(startingFuse))
				{
					return ActiveLevel(outputNumber, 0);
				}
			}

			int startingRow = 1;
			//TODO: mode only used by GAL16V8
			if (Mode == GalModeEnum.Simple)
			{
				startingRow = 0;
			}

			for (int i = startingRow; i < 8; i++)
			{
				if (IsRowEnabled(i * FusesPerRow + startingFuse))
				{
					bool result = GetResultsFromRow(i * FusesPerRow + startingFuse);

					// row 0 (0 - FusesPerRow)
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

		// handle PTD fuses (Product Term Disabled)
		private bool IsRowEnabled(int fuseNumber)
		{
			if (!HasPtdFuses)
			{
				return true;
			}

			//2128 - 2191 PTD (GAL16v8)
			int ptdFuseNumber = (fuseNumber / FusesPerRow) + RowEnableStartFuse;

			// if the fuse is active, then the row is disabled
			return !Fuses.Contains(ptdFuseNumber);
		}

		private double ActiveLevel(int outputNumber, double outputVoltage)
		{
			int fuseNumber = 0;

			foreach (var o in OlmcUnits)
			{
				if (o.OutputPin == outputNumber)
				{
					fuseNumber = o.S0FuseNumber;
					break;
				}
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

		private bool GetResultsFromRow(int rowStart)
		{
			bool result = false; // if there are no fuses, then this row doesn't count
			foreach (var f in Fuses)
			{
				if (f >= rowStart && f < rowStart + FusesPerRow)
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

		public abstract void CheckForFeedbackInputs(int blockStart, int blockEnd, int timing);
		public abstract double GetInputForFuseNumber(int fuseNumber);


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
							//TODO: need to account for a possible 44 fuses?
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
			var fileCreator = new JedecFileCreator();
			fileCreator.Save(fileName, Fuses);
		}

		public void LoadPDS(string fileName)
		{
			// parse a PDS file and translate into a fuse map
			var assembly = Assembly.GetCallingAssembly();
			using (var stream = assembly.GetManifestResourceStream(fileName))
			{
				if (stream == null)
				{
					throw new Exception("Cannot find PDS data file, make sure it is set to Embedded Resource!");
				}
				using (var reader = new StreamReader(stream))
				{
					string data = reader.ReadToEnd();

					var parser = new PdsFileParser(data);
					Fuses = parser.Parse();
				}
			}
		}
	}
}
