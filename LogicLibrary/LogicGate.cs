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
		public string CircuitName { get; set; }

		protected LogicGate(int totalInputs)
		{
			for (int i = 0; i < totalInputs; i++)
			{
				Inputs.Add(new InputData());
			}

			UnknownLastOutput = false; // this needs to be implemented for each gate
		}

		public abstract int Count { get; }

		public bool UnknownLastOutput { get; set; }

		public abstract double Output(int timing);

		public TriLogic ReadSignalBoolean(int inputNumber, int timing)
		{
			// 0-0.8v = low
			// 2-5v = hight
			//http://www.allaboutcircuits.com/textbook/digital/chpt-3/logic-signal-voltage-levels/
			//TODO: if the input is withing the high noise level, then use a random number to indicate the output
			if (Inputs[inputNumber].InputSample.Count == 0)
			{
				return TriLogic.Unknown;
			}

			int signalNumber = timing - SignalDelayHighToLow;

			if (signalNumber < 0)
			{
				signalNumber = 0;
			}
			
			if (Inputs[inputNumber].InputSample.Count <= timing - SignalDelayHighToLow)
			{
				signalNumber = 0;
			}

			if (Inputs[inputNumber].InputSample[signalNumber].Unknown)
			{
				// grab the prevously known signal
				if (signalNumber - 1 >= 0)
				{
					if (!Inputs[inputNumber].InputSample[signalNumber - 1].Unknown)
					{
						if (Inputs[inputNumber].InputSample[signalNumber - 1].Voltage < 2.7)
						{
							if (Inputs[inputNumber].InputInverted)
							{
								return TriLogic.True;
							}
							return TriLogic.False;
						}
						else
						{
							if (Inputs[inputNumber].InputInverted)
							{
								return TriLogic.False;
							}
							return TriLogic.True;
						}
					}
					else
					{
						string temp = "";
					}
				}

				return TriLogic.Unknown;
			}

			if (Inputs[inputNumber].InputSample[signalNumber].Voltage < 2.7)
			{
				if (Inputs[inputNumber].InputInverted)
				{
					return TriLogic.True;
				}
				return TriLogic.False;
			}

			if (Inputs[inputNumber].InputInverted)
			{
				return TriLogic.False;
			}
			return TriLogic.True;
		}
	}
}
