using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.LayoutRenderers.Wrappers;

namespace LogicLibrary
{
	public class Circuit
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public List<LogicGate> Gates { get; set; } = new List<LogicGate>();
		public List<Connection> Connections { get; set; } = new List<Connection>();
		public bool CircuitCompletedSuccessfully { get; private set; }
		public int Count { get; private set; }

		public void RunCircuit()
		{
			CircuitCompletedSuccessfully = true;
			int totalSamples = 0;

			// find total samples by getting the total samples of one of the inputs
			foreach (var c in Connections.Where(x => x.Source.GateName == "Signal" || x.Source.GateName == "Wire"))
			{
				totalSamples = c.Source.Count;
				break;
			}

			Count = totalSamples;

			for (int i = 0; i < totalSamples; i++)
			{
				// first, populate a signal record to each connection and set it to unknown
				foreach (var c in Connections)
				{
					c.InitializeSignal(i);
				}

				int totalConnectionsCompleted = 0;
				int totalPasses = 0;
				bool setConnection = true;

				_logger.Debug("");

				// do all wires and input signals first
				foreach (var c in Connections.Where(x => x.Source.GateName == "Signal" || x.Source.GateName == "Wire"))
				{
					_logger.Debug($"transmit signal {i}, Connection {c.Name}, Source {c.Source.CircuitName}");

					// propagate the signal to all the inputs
					if (c.TransmitSignal(i))
					{
						_logger.Debug($"Voltage {c.Termination.InputSample[i].Voltage}");
						totalConnectionsCompleted++;
					}
				}

				while (totalConnectionsCompleted < Connections.Count)
				{
					foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
					{
						_logger.Debug($"transmit signal {i}, Connection {c.Name}, Source {c.Source.CircuitName}");

						// search for all gates where all input signals have been completed
						if (c.TransmitSignal(i))
						{
							_logger.Debug($"Voltage {c.Termination.InputSample[i].Voltage}");
							totalConnectionsCompleted++;
						}
						else if (totalPasses > 0 && setConnection)
						{
							_logger.Debug("Voltage Unknown setting connection to zero");
							// use zero for the first unknown output
							if (c.Termination.InputSample[i].Unknown)
							{
								foreach (var tempC in Connections)
								{
									if (tempC.Source == c.Source)
									{
										tempC.Termination.InputSample[i].Voltage = 0;
										tempC.Termination.InputSample[i].Unknown = false;
										totalConnectionsCompleted++;
										setConnection = false;
									}
								}
							}
						}
						else if (totalPasses == 5 || totalPasses == 10)
						{
							setConnection = true;
						}
						else
						{
							_logger.Debug("Voltage Unknown");
						}
					}

					totalPasses++;

					if (totalPasses > 100)
					{
						CircuitCompletedSuccessfully = false;
						break;
					}
				}

				//TODO: re-verify that all connections are valid
				int totalInvalidConnections = 0;
				foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
				{
					if (Math.Abs(c.Termination.InputSample[i].Voltage - c.Source.Output(i)) > 0.5)
					{
						totalInvalidConnections++;
					}
				}

				if (totalInvalidConnections > 0)
				{
					_logger.Debug($"{totalInvalidConnections} Connections are not valid");
				}

				// gate check to see if there are any violations
				foreach (var g in Gates)
				{
					string message = $"Gate {g.CircuitName} Inputs:";

					bool expectedOutput = false;
					for (int j = 0; j < g.Inputs.Count; j++)
					{
						if (j > 0)
						{
							message += ",";
						}

						if (g.Inputs[j].InputSample[i].Voltage < 2.7)
						{
							message += "0";
							expectedOutput = true;
						}
						else
						{
							message += "1";
						}
					}

					if (g.Output(i) < 2.7)
					{
						message += " Output:0";
					}
					else
					{
						message += " Output:1";
					}

					if (g.Output(i) < 2.7 && expectedOutput == true)
					{
						_logger.Debug($"Gate {g.CircuitName} is violated");
						CircuitCompletedSuccessfully = false;
					}
					else if (g.Output(i) > 2.7 && expectedOutput == false)
					{
						_logger.Debug($"Gate {g.CircuitName} is violated");
						CircuitCompletedSuccessfully = false;
					}
					else
					{
						_logger.Debug(message);
					}
				}
			}
		}
	}
}
