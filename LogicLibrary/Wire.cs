namespace LogicLibrary
{
	public class Wire : LogicGate
	{
		public Wire() : base(1)
		{
			GateName = "Wire";
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

		public void Add(double voltage)
		{
			Inputs[0].InputSample.Add(new InputSignal
			{
				Timing = Inputs[0].InputSample.Count,
				Voltage = voltage
			});
		}

		public override double Output(int timing)
		{
			if (timing < 0)
			{
				return 0;
			}

			if (Inputs.Count == 0 || timing > Inputs[0].InputSample.Count)
			{
				return 0;
			}

			if (Inputs[0].InputSample.Count == 0)
			{
				return 0;
			}

			return Inputs[0].InputSample[timing].Voltage;
		}
	}
}
