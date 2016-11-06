using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public abstract class LogicGate
	{
		public List<InputData> Inputs { get; set; } = new List<InputData>(); // voltage 0-5V
		public int SignalDelayLowToHigh { get; set; }
		public int SignalDelayHighToLow { get; set; }
		public string GateName { get; set; }

		public LogicGate(int totalInputs)
		{
			for (int i = 0; i < totalInputs; i++)
			{
				Inputs.Add(new InputData());
			}
		}

		public abstract int Count { get; }

		public abstract double Output(int timing);

		public bool AllInputsPropagated
		{
			get
			{
				for (int i = 0; i < Inputs.Count; i++)
				{
					if (Inputs[i].InputSample.Count == 0)
					{
						return false;
					}
				}

				return true;
			}
		}

		public bool ReadSignalBoolean(int inputNumber, int timing)
		{
			// 0-0.8v = low
			// 2-5v = hight
			//http://www.allaboutcircuits.com/textbook/digital/chpt-3/logic-signal-voltage-levels/
			//TODO: if the input is withing the high noise level, then use a random number to indicate the output

			if (Inputs[inputNumber].InputSample.Count < timing - SignalDelayHighToLow)
			{
				return false;
			}

			if (timing - SignalDelayHighToLow < 0)
			{
				return false;
			}

			if (Inputs[inputNumber].InputSample[timing - SignalDelayHighToLow].Voltage < 2.7)
			{
				return false;
			}

			return true;
		}
	}
}
