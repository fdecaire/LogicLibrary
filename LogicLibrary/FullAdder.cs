using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class FullAdder : Circuit
	{
		public Wire A { get; set; } = new Wire();

		public Wire B { get; set; } = new Wire();

		public Wire Cin { get; set; } = new Wire();

		public double S(int timing)
		{
			return Gates[2].Output(timing);
		}

		public double Cout(int timing)
		{
			return Gates[4].Output(timing);
		}

		public FullAdder(TTLGateTypeEnum gateTypes)
		{
			var xorGate = new XorGate(gateTypes, 2);
			var andGate = new AndGate(gateTypes, 2);

			var xorGate2 = new XorGate(gateTypes, 2);
			var andGate2 = new AndGate(gateTypes, 2);
			var orGate = new OrGate(gateTypes, 2);

			Gates.Add(xorGate);
			Gates.Add(andGate);
			Gates.Add(xorGate2);
			Gates.Add(andGate2);
			Gates.Add(orGate);

			// back xor gate
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

			// front xor gate
			Connections.Add(new Connection
			{
				Source = xorGate,
				Termination = xorGate2.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = Cin,
				Termination = xorGate2.Inputs[1]
			});


			// back and gate
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

			// front and gate
			Connections.Add(new Connection
			{
				Source = xorGate,
				Termination = andGate2.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = Cin,
				Termination = andGate2.Inputs[1]
			});

			// or gate, combining two and gate outputs
			Connections.Add(new Connection
			{
				Source = andGate,
				Termination = orGate.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = andGate2,
				Termination = orGate.Inputs[1]
			});
		}
	}
}
