using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class NandGate : LogicGate
	{
		public NandGate(TTLGateTypeEnum gateType, int totalInputs) : base( totalInputs)
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
			GateName += "00";
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
			for (int i = 0; i < Inputs.Count; i++)
			{
				if (!ReadSignalBoolean(i, timing))
				{
					return 5;
				}
			}
			return 0;
		}
	}
}
