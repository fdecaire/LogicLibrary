using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogicLibrary
{
	public class Circuit
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public List<LogicGate> Gates { get; set; } = new List<LogicGate>();
		public List<Connection> Connections { get; set; } = new List<Connection>();
		public bool CircuitCompletedSuccessfully { get; private set; }

		public void RunCircuit(int totalSamples)
		{
			for (int i = 0; i < totalSamples; i++)
			{
				int totalConnectionsCompleted = 0;
				int totalPasses = 0;
				while (totalConnectionsCompleted < Connections.Count && totalPasses < Connections.Count)
				{
					foreach (var c in Connections)
					{
						_logger.Debug($"transmit signal {i} " + c.Source.GateName);
						if (c.Source.GateName == "Signal" || c.Source.GateName == "Wire")
						{
							// propagate the signal to all the inputs
							c.TransmitSignal(i);
							totalConnectionsCompleted++;
						}
						else if (c.Source.AllInputsPropagated(i))
						{
							// search for all gates where all input signals have been completed
							c.TransmitSignal(i);
							totalConnectionsCompleted++;
						}
					}

					totalPasses++;
				}
			}

			CircuitCompletedSuccessfully = true;
		}
	}
}
