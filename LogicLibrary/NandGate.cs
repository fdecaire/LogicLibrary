using System.Xml.Serialization;

namespace LogicLibrary
{
	public class NandGate : LogicGate
	{
		public NandGate(TTLGateTypeEnum gateType, int totalInputs) : base(totalInputs)
		{
			GateName = "74";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 11; // max=22ns
					SignalDelayHighToLow = 7; // max=15ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 9; // max=15ns
					SignalDelayHighToLow = 10; // max=15ns
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

			switch (totalInputs)
			{
				case 2:
					GateName += "00";
					break;
				case 3:
					GateName += "10";
					break;
				case 4:
					GateName += "20";
					break;
				case 8:
					GateName += "30";
					break;
			}
		}

		public override int Count
		{
			// just count the number of samples for input 0
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
				// if any input if false, then return true
				switch (ReadSignalBoolean(i, timing))
				{
					case TriLogic.False:
					return 5;
					case TriLogic.Unknown:
						anyUnknownInputs = true;
						break;
				}
			}

			// if all inputs are true and there is at least one unknown, then the output is unknown
			if (anyUnknownInputs)
			{
				UnknownLastOutput = true;
			}

			// if all inputs are true, then the output is zero
			return 0;
		}
	}
}
