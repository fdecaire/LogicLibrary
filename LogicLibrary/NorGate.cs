using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class NorGate : LogicGate
	{
		public NorGate(TTLGateTypeEnum gateType, int totalInputs) : base( totalInputs)
		{
			GateName = "74";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 12; // max=22ns
					SignalDelayHighToLow = 8; // max=15ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 10; // max=15ns
					SignalDelayHighToLow = 10; // max=15ns
					GateName += "LS";
					break;
				case TTLGateTypeEnum.S:
					SignalDelayLowToHigh = 4; //3.5; // max=5.5ns
					SignalDelayHighToLow = 4; //3.5 max=5.5ns
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
					GateName += "02";
					break;
				case 3:
					GateName += "27";
					break;
				case 4:
					GateName += "25";
					break;
				case 5:
					GateName += "260";
					break;
			}
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
			UnknownLastOutput = false;
			bool anyUnknownInputs = false;

			for (int i = 0; i < Inputs.Count; i++)
			{
				switch (ReadSignalBoolean(i, timing))
				{
					case TriLogic.True:
						return 0;
					case TriLogic.Unknown:
						anyUnknownInputs = true;
						break;
				}
			}

			if (anyUnknownInputs)
			{
				UnknownLastOutput = true;
			}

			return 5;
		}
	}
}
