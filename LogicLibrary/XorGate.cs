using System.Collections.Generic;

namespace LogicLibrary
{
	public class XorGate : LogicGate
	{
		public XorGate(TTLGateTypeEnum gateType, int totalInputs) : base(totalInputs)
		{
			GateName = "74";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 15; // max=23ns
					SignalDelayHighToLow = 11; // max=17ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 12; // max=23ns
					SignalDelayHighToLow = 10; // max=17ns
					GateName += "LS";
					break;
				case TTLGateTypeEnum.S:
					SignalDelayLowToHigh = 7; // max=10.5ns
					SignalDelayHighToLow = 7; // 6.5 // max=10ns
					GateName += "S";
					break;
				case TTLGateTypeEnum.Perfect:
					SignalDelayLowToHigh = 0;
					SignalDelayHighToLow = 0;
					GateName += "PERFECT";
					break;
			}
			GateName += "86";
		}

		public override int Count
		{
			// just count the number of inputs for input 0
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
			List<bool> tempInputs = new List<bool>();

			for (int i = 0; i < Inputs.Count; i++)
			{
				if (Inputs[i].InputSample.Count < timing - SignalDelayHighToLow)
				{
					tempInputs.Add(false);
					continue;
				}

				if (timing - SignalDelayHighToLow < 0)
				{
					tempInputs.Add(false);
					continue;
				}

				if (ReadSignalBoolean(i, timing) == TriLogic.True)
				{
					tempInputs.Add(false);
				}
				else
				{
					tempInputs.Add(true);
				}
			}

			bool result = tempInputs[0] ^ tempInputs[1];

			for (int i = 2; i < tempInputs.Count; i++)
			{
				// this should be rare
				result = result ^ tempInputs[i];
			}

			if (result)
			{
				return 5;
			}
			return 0;
		}
	}
}
