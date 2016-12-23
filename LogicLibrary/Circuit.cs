using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace LogicLibrary
{
	//TODO: create a verify method to check if two outputs are cross-circuited to the same input
	public class Circuit
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public List<LogicGate> Gates { get; set; } = new List<LogicGate>();
		public List<Connection> Connections { get; set; } = new List<Connection>();
		public bool CircuitCompletedSuccessfully { get; private set; }
		public List<Circuit> Circuits { get; set; } = new List<Circuit>();

		public double GateOutput(int gateNumber, int timing)
		{
			return Gates[gateNumber].Output(timing);
		}

		private int ? _count;
		public int Count
		{
			get
			{
				if (_count == null)
				{
					// find total samples by getting the total samples of one of the inputs
					foreach (var c in Connections.Where(x => x.Source.GateName == "Signal" || x.Source.GateName == "Wire"))
					{
						_count = c.Source.Count;
						break;
					}
				}
				return _count ?? 0;
			}
		}

		public void RunCircuit()
		{
			CircuitCompletedSuccessfully = true;

			for (int i = 0; i < Count; i++)
			{
				RunIteration(i);
			}
		}

		public void RunIteration(int iteration)
		{
			// first, populate a signal record to each connection and set it to unknown
			foreach (var c in Connections)
			{
				c.InitializeSignal(iteration);
			}

			_logger.Debug("");

			// do all wires and input signals first
			PropagateWires(iteration);

			bool success = false;
			for (int i = 0; i < 10; i++)
			{
				if (PropagateSignals(iteration))
				{
					success = true;
					break;
				}
			}

			if (!success)
			{
				FixInvalidConnections(iteration);

				ForceFirstUnknownOutputToZero(iteration);

				for (int i = 0; i < 10; i++)
				{
					if (PropagateSignals(iteration))
					{
						break;
					}
				}
			}

			FixInvalidConnections(iteration);
			CircuitCompletedSuccessfully = CheckValidConnections(iteration);

			//CircuitCompletedSuccessfully = CheckValidGateStates(iteration) && totalPasses < 100;
		}

		private void ForceFirstUnknownOutputToZero(int iteration)
		{
			foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
			{
				// use zero for the first unknown output
				if (c.Termination.InputSample[iteration].Unknown)
				{
					foreach (var tempC in Connections)
					{
						if (tempC.Source == c.Source)
						{
							tempC.Termination.InputSample[iteration].Voltage = 0;
							tempC.Termination.InputSample[iteration].Unknown = false;
						}
					}
					break;
				}
			}
		}

		private void FixInvalidConnections(int iteration)
		{
			foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
			{
				if (Math.Abs(c.Termination.InputSample[iteration].Voltage - c.Source.Output(iteration)) > 0.5)
				{
					//TODO: move the voltage up to the termination
					c.Termination.InputSample[iteration].Unknown = true;
					c.TransmitSignal(iteration);

					//TODO: re-evaluate the gate at the end of the wire
				}
			}
		}

		private bool PropagateSignals(int iteration)
		{
			_logger.Debug("propagate signals...");
			bool allSignalsCompleted = true;
			foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
			{
				switch (c.TransmitSignal(iteration))
				{
					case TransmitResult.Success:
					case TransmitResult.Transmitted:
						_logger.Debug(
							$"transmit signal {iteration}, Connection {c.Name}, Source {c.Source.CircuitName}, Voltage {c.Termination.InputSample[iteration].Voltage}");
						break;
					case TransmitResult.Unknown:
						_logger.Debug($"transmit signal {iteration}, Connection {c.Name}, Source {c.Source.CircuitName} bad");
						allSignalsCompleted = false;
						break;
				}
			}

			return allSignalsCompleted;
		}

		private int PropagateWires(int iteration)
		{
			int totalConnectionsCompleted = 0;

			foreach (var c in Connections.Where(x => x.Source.GateName == "Signal" || x.Source.GateName == "Wire"))
			{
				_logger.Debug($"transmit signal {iteration}, Connection {c.Name}, Source {c.Source.CircuitName}");

				// propagate the signal to all the inputs
				if (c.TransmitSignal(iteration) == TransmitResult.Success)
				{
					_logger.Debug($"Voltage {c.Termination.InputSample[iteration].Voltage}");
					totalConnectionsCompleted++;
				}
			}

			return totalConnectionsCompleted;
		}

		private bool CheckValidConnections(int iteration)
		{
			int totalInvalidConnections = 0;
			foreach (var c in Connections.Where(x => x.Source.GateName != "Signal" && x.Source.GateName != "Wire"))
			{
				if (Math.Abs(c.Termination.InputSample[iteration].Voltage - c.Source.Output(iteration)) > 0.5)
				{
					totalInvalidConnections++;
				}
			}

			if (totalInvalidConnections > 0)
			{
				_logger.Debug($"{totalInvalidConnections} Connections are not valid");
			}

			return totalInvalidConnections == 0;
		}

		private bool CheckValidGateStates(int iteration)
		{
			bool result = true;

			// gate check to see if there are any violations
			foreach (var g in Gates)
			{
				string message = $"Gate {g.CircuitName} Inputs:";

				//TODO: this is the expected output for a NAND gate
				bool expectedOutput = false;
				for (int j = 0; j < g.Inputs.Count; j++)
				{
					if (j > 0)
					{
						message += ",";
					}

					if (g.Inputs[j].InputSample[iteration].Voltage < 2.7)
					{
						message += "0";
						expectedOutput = true;
					}
					else
					{
						message += "1";
					}
				}

				if (g.Output(iteration) < 2.7)
				{
					message += " Output:0";
				}
				else
				{
					message += " Output:1";
				}

				if (g.Output(iteration) < 2.7 && expectedOutput == true)
				{
					_logger.Debug($"Gate {g.CircuitName} is violated");
					result = false;
				}
				else if (g.Output(iteration) > 2.7 && expectedOutput == false)
				{
					_logger.Debug($"Gate {g.CircuitName} is violated");
					result = false;
				}
				else
				{
					_logger.Debug(message);
				}
			}

			return result;
		}

		public bool VerifyAllGateInputsConnected()
		{
			foreach (var g in Gates)
			{
				for (int i = 0; i < g.Inputs.Count; i++)
				{
					bool connectionMade = false;
					foreach (var c in Connections)
					{
						if (c.Termination == g.Inputs[i])
						{
							connectionMade = true;
							break;
						}
					}


					if (!connectionMade)
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
