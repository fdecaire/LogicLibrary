using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogicLibrary
{
	//NOTE: TTL logic gate
	public class AndGate : LogicGate
	{
		public AndGate(TTLGateTypeEnum gateType,int totalInputs) : base(totalInputs)
		{
			GateName = "74";
			switch (gateType)
			{
				case TTLGateTypeEnum.Normal:
					SignalDelayLowToHigh = 18;//17.5; // max=27ns
					SignalDelayHighToLow = 12; // max=19ns
					break;
				case TTLGateTypeEnum.LS:
					SignalDelayLowToHigh = 8; // max=15ns
					SignalDelayHighToLow = 10; // max=20ns
					GateName += "LS";
					break;
				case TTLGateTypeEnum.S:
					SignalDelayLowToHigh = 5; //4.5; // max=7ns
					SignalDelayHighToLow = 5; // max=7.5ns
					GateName += "S";
					break;
				case TTLGateTypeEnum.Perfect:
					SignalDelayLowToHigh = 0;
					SignalDelayHighToLow = 0;
					GateName += "PERFECT";
					break;
			}
			GateName += "08";
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
					return 0;
				}
			}

			return 5;
		}
	}
}
