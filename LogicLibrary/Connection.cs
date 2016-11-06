using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class Connection
	{
		public LogicGate Source { get; set; }
		public InputData Termination { get; set; }
		public bool SignalCompleted { get; private set; } = false;

		public void TransmitSignal()
		{
			// read the source signal array and copy to the terminiation signal array
			for (int i = 0; i < Source.Count; i++)
			{
				Termination.InputSample.Add(new InputSignal
				{
					Timing = i,
					Voltage = Source.Output(i)
				});
			}

			SignalCompleted = true;
		}
	}
}
