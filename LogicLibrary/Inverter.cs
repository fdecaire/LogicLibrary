namespace LogicLibrary
{
	public class Inverter : LogicGate
	{
		public Inverter(TTLGateTypeEnum gateType) : base( 1)
		{
			GateName = "74";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 9; // max=15ns
					SignalDelayHighToLow = 10; // max=15ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 3; // max=4.5ns
					SignalDelayHighToLow = 3; // max=5ns
					GateName += "LS";
					break;
				case TTLGateTypeEnum.S:
					SignalDelayLowToHigh = 3; // max=4.5ns
					SignalDelayHighToLow = 3; // max=5ns
					GateName += "S";
					break;
				case TTLGateTypeEnum.Perfect:
					SignalDelayLowToHigh = 0;
					SignalDelayHighToLow = 0;
					GateName += "PERFECT";
					break;
			}
			GateName += "04";
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

			// only one input is actually allowed on this gate
			switch (ReadSignalBoolean(0, timing))
			{
				case TriLogic.False:
					return 5;
				case TriLogic.Unknown:
					UnknownLastOutput = true;
					break;
			}

			return 0;
		}
	}
}
