using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class JKFlipFlop : Circuit
	{
		public Wire J { get; set; } = new Wire();

		public Wire K { get; set; } = new Wire();

		public Wire Clk { get; set; } = new Wire();

		public double Q(int timing)
		{
			return Gates[0].Output(timing);
		}

		public double QNot(int timing)
		{
			return Gates[1].Output(timing);
		}

		public JKFlipFlop(TTLGateTypeEnum gateType)
		{
			var nandGate1 = new NandGate(gateType, 2);
			var nandGate2 = new NandGate(gateType, 2);

			var nandGate3 = new NandGate(gateType, 3);
			var nandGate4 = new NandGate(gateType, 3);

			Gates.Add(nandGate1);
			Gates.Add(nandGate2);
			Gates.Add(nandGate3);
			Gates.Add(nandGate4);

			Connections.Add(new Connection
			{
				Source = J,
				Termination = nandGate3.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate3.Inputs[1]
			});

			Connections.Add(new Connection
			{
				Source = nandGate2, // QNot
				Termination = nandGate3.Inputs[2]
			});
			

			Connections.Add(new Connection
			{
				Source = J,
				Termination = nandGate4.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = Clk,
				Termination = nandGate4.Inputs[1]
			});
			
			Connections.Add(new Connection
			{
				Source = nandGate1, // Q
				Termination = nandGate4.Inputs[2]
			});

			Connections.Add(new Connection
			{
				Source = nandGate1,
				Termination = nandGate2.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = nandGate3,
				Termination = nandGate1.Inputs[1]
			});

			Connections.Add(new Connection
			{
				Source = nandGate2,
				Termination = nandGate1.Inputs[0]
			});

			Connections.Add(new Connection
			{
				Source = nandGate4,
				Termination = nandGate2.Inputs[1]
			});
		}
	}
}
