using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class FalstadCircuit : Circuit
	{
		public Wire Input { get; set; } = new Wire();

		public double Output(int timing)
		{
			return Gates[0].Output(timing);
		}

		public double InverterOutput(int timing)
		{
			return Gates[1].Output(timing);
		}

		public FalstadCircuit(TTLGateTypeEnum gateTypes)
		{
			var andGate = new AndGate(gateTypes, 2);
			var inverter = new Inverter(gateTypes);

			Gates.Add(andGate);
			Gates.Add(inverter);

			Connections.Add(new Connection
			{
				Source = Input,
				Termination = andGate.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = Input,
				Termination = inverter.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = inverter,
				Termination = andGate.Inputs[1]
			});
		}
	}
}
