namespace LogicLibrary
{
	public class NotOrGate : LogicGate
	{
		public NotOrGate(TTLGateTypeEnum gateType, int totalInputs) : base( totalInputs)
		{
			GateName = "NA";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 10; // max=15ns
					SignalDelayHighToLow = 14; // max=22ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 14; // max=2ns
					SignalDelayHighToLow = 14; // max=22ns
					GateName += "LS";
					break;
				case TTLGateTypeEnum.S:
					SignalDelayLowToHigh = 4; // max=7ns
					SignalDelayHighToLow = 4; // max=7ns
					GateName += "S";
					break;
				case TTLGateTypeEnum.Perfect:
					SignalDelayLowToHigh = 0;
					SignalDelayHighToLow = 0;
					GateName += "PERFECT";
					break;
			}
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

		public override double Output(int timing)
		{
			UnknownLastOutput = false;
			bool anyUnknownInputs = false;

			for (int i = 0; i < Inputs.Count; i++)
			{
				switch (ReadSignalBoolean(i, timing))
				{
					case TriLogic.False:
						return 5;
					case TriLogic.Unknown:
						anyUnknownInputs = true;
						break;
				}
			}

			if (anyUnknownInputs)
			{
				UnknownLastOutput = true;
			}

			return 0;
		}
	}
}
