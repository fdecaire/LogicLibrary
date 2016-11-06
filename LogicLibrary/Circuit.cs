using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class Circuit
	{
		public List<LogicGate> Gates { get; set; } = new List<LogicGate>();
		public List<Connection> Connections { get; set; } = new List<Connection>();
		public bool CircuitCompletedSuccessfully { get; private set; }

		public void RunCircuit()
		{
			// look for a signal source type gate and propagate to the first inputs
			int totalConnectionsCompleted = 0;
			int totalPasses = 0;
			while (totalConnectionsCompleted < Connections.Count && totalPasses < Connections.Count)
			{
				foreach (Connection c in Connections)
				{
					if (c.Source.GateName == "Signal" || c.Source.GateName == "Wire")
					{
						// propagate the signal to all the inputs
						c.TransmitSignal();
						totalConnectionsCompleted++;
					}
					else if (c.Source.AllInputsPropagated)
					{
						// search for all gates where all input signals have been completed
						c.TransmitSignal();
						totalConnectionsCompleted++;
					}
				}

				totalPasses++;
			}

			// if loop broke out because we completed all circuit connections, then it was a success
			if (totalConnectionsCompleted == Connections.Count)
			{
				CircuitCompletedSuccessfully = true;
			}
		}
	}
}
