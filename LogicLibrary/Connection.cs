using System;

namespace LogicLibrary
{
	public class Connection
	{
		public LogicGate Source { get; set; }
		public InputData Termination { get; set; }
		public Wire WireTermination { get; set; }
		public string Name { get; set; }

		public void InitializeSignal(int timing)
		{
			if (Termination != null)
			{
				Termination.InputSample.Add(new InputSignal
				{
					Timing = timing,
					Voltage = 0,
					Unknown = true
				});
			}

			if (WireTermination != null)
			{
				WireTermination.Inputs[0].InputSample.Add(new InputSignal
				{
					Timing = timing,
					Voltage = 0,
					Unknown = true
				});
			}
		}

		public TransmitResult TransmitSignal(int timing)
		{
			// check to see if this signal has already been transmitted
			if (WireTermination != null)
			{
				if (!WireTermination.Inputs[0].InputSample[timing].Unknown)
				{
					return TransmitResult.Transmitted;
				}
			}

			if (Termination != null && !Termination.InputSample[timing].Unknown)
			{
				return TransmitResult.Transmitted;
			}

			var signal = Source.Output(timing);
			if (Source.UnknownLastOutput)
			{
				// signal not transmitted, output of source was unknown
				return TransmitResult.Unknown;
			}

			if (WireTermination != null)
			{
				WireTermination.Inputs[0].InputSample[timing].Voltage = signal;
				WireTermination.Inputs[0].InputSample[timing].Unknown = false;
			}

			if (Termination != null)
			{
				Termination.InputSample[timing].Voltage = signal;
				Termination.InputSample[timing].Unknown = false;
			}

			// signal was transmitted
			return TransmitResult.Success;
		}
	}
}
