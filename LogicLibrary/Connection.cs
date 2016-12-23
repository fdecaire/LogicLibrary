using System;

namespace LogicLibrary
{
	public class Connection
	{
		public LogicGate Source { get; set; }
		public InputData Termination { get; set; }
		public string Name { get; set; }

		public void TransmitSignal()
		{
			// read the source signal array and copy to the terminiation signal array
			for (int i = 0; i < Source.Count; i++)
			{
				Termination.InputSample.Add(new InputSignal
				{
					Timing = i,
					Voltage = Source.Output(i)
				});
			}
		}

		public void InitializeSignal(int timing)
		{
			Termination.InputSample.Add(new InputSignal
			{
				Timing = timing,
				Voltage = 0,
				Unknown = true
			});
		}

		public TransmitResult TransmitSignal(int timing)
		{
			// check to see if this signal has already been transmitted
			if (!Termination.InputSample[timing].Unknown)
			{
				return TransmitResult.Transmitted;
			}

			var signal = Source.Output(timing);
			if (Source.UnknownLastOutput)
			{
				// signal not transmitted, output of source was unknown
				return TransmitResult.Unknown;
			}

			Termination.InputSample[timing].Voltage = signal;
			Termination.InputSample[timing].Unknown = false;

			// signal was transmitted
			return TransmitResult.Success;
		}
	}
}
