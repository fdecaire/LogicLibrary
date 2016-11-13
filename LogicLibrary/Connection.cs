namespace LogicLibrary
{
	public class Connection
	{
		public LogicGate Source { get; set; }
		public InputData Termination { get; set; }

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

		public void TransmitSignal(int timing)
		{
			Termination.InputSample.Add(new InputSignal
			{
				Timing = timing,
				Voltage = Source.Output(timing)
			});
		}
	}
}
