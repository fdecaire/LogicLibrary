namespace LogicLibrary
{
	public class SignalGenerator : LogicGate
	{
		public SignalGenerator() : base( 1)
		{
			GateName = "Signal";
		}

		public override double Output(int timing)
		{
			if (timing > Inputs[0].InputSample.Count || timing < 0)
			{
				return 0;
			}

			return Inputs[0].InputSample[timing].Voltage;
		}

		public override int Count
		{
			get
			{
				if (Inputs.Count == 0)
				{
					return 0;
				}
				return Inputs[0].InputSample.Count;
			}
		}

		public void AddSample(double volts)
		{
			Inputs[0].InputSample.Add(new InputSignal
			{
				Timing = Inputs[0].InputSample.Count,
				Voltage = volts
			});
		}
	}
}
