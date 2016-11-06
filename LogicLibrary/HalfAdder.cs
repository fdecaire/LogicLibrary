using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class HalfAdder : Circuit
	{
		public Wire A { get; set; } = new Wire();

		public Wire B { get; set; } = new Wire();

		public double S(int timing)
		{
			return Gates[0].Output(timing);
		}

		public double Cout(int timing)
		{
			return Gates[1].Output(timing);
		}

		public HalfAdder(TTLGateTypeEnum gateType)
		{
			var xorGate = new XorGate(gateType, 2);
			var andGate = new AndGate(gateType, 2);

			Gates.Add(xorGate);
			Gates.Add(andGate);

			Connections.Add(new Connection
			{
				Source = A,
				Termination = xorGate.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = xorGate.Inputs[1]
			});

			Connections.Add(new Connection
			{
				Source = A,
				Termination = andGate.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = B,
				Termination = andGate.Inputs[1]
			});
		}
	}
}
