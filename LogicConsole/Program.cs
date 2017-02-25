using System;
using LogicLibrary;
using NLog;
using System.IO;
using GALCircuits;
using TTLLibrary;

namespace LogicConsole
{
	class Program
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args)
		{
		}

		private static void SaveJEDECFileTest()
		{
			var testgal = new GAL16V8();
			testgal.LoadPDS("LogicConsole.Data.hex_display.pds");
			testgal.SaveJEDEC(@"c:\temp\testjedecoutput.jed");
		}

		private static void TwoBitAdder()
		{
			// rough draft of two circuits.
			// this will need to be wrapped in a circuit that can process one circuit,
			// then process the next circuit where all inputs are complete, until all
			// circuits are complete.



			var signalGenerator1 = new SignalGenerator();
			var signalGenerator2 = new SignalGenerator();
			var ground = new Ground(200);

			bool signalHigh = true;
			bool longSignalHigh = true;
			for (int i = 0; i < 200; i++)
			{
				if (i % 20 == 0)
				{
					signalHigh = !signalHigh;
				}

				if (i % 40 == 0)
				{
					longSignalHigh = !longSignalHigh;
				}

				signalGenerator1.AddSample(signalHigh ? 5 : 0);
				signalGenerator2.AddSample(longSignalHigh ? 5 : 0);
			}

			var adder1Circuit = new FullAdder(TTLGateTypeEnum.Perfect);
			var adder2Circuit = new FullAdder(TTLGateTypeEnum.Perfect);
			for (int i = 0; i < 200; i++)
			{
				adder1Circuit.A.Add(signalGenerator1.Output(i));
				adder1Circuit.B.Add(signalGenerator2.Output(i));
				adder1Circuit.Cin.Add(ground.Output(i));

				adder2Circuit.A.Add(signalGenerator1.Output(i));
				adder2Circuit.B.Add(signalGenerator2.Output(i));
			}

			adder1Circuit.RunCircuit();
			for (int i = 0; i < 200; i++)
			{
				adder2Circuit.Cin.Add(adder1Circuit.Cout(i));
			}
			adder2Circuit.RunCircuit();

			for (int i = 0; i < 200; i++)
			{
				_logger.Debug($"T:{i:000} IN1:{signalGenerator1.Output(i)} IN2:{signalGenerator2.Output(i)}  S1:{adder1Circuit.S(i)} S2:{adder2Circuit.S(i)}  Cout:{adder1Circuit.Cout(i)}");
			}
		}

		private static void FullAdderTest()
		{
			var signalGenerator1 = new SignalGenerator();
			var signalGenerator2 = new SignalGenerator();
			var signalGenerator3 = new SignalGenerator();

			bool signalHigh = true;
			bool longSignalHigh = true;
			bool carrySignalHigh = true;
			for (int i = 0; i < 300; i++)
			{
				if (i % 20 == 0)
				{
					signalHigh = !signalHigh;
				}

				if (i % 40 == 0)
				{
					longSignalHigh = !longSignalHigh;
				}

				if (i % 80 == 0)
				{
					carrySignalHigh = !carrySignalHigh;
				}

				signalGenerator1.AddSample(signalHigh ? 5 : 0);
				signalGenerator2.AddSample(longSignalHigh ? 5 : 0);
				signalGenerator3.AddSample(carrySignalHigh ? 5 : 0);
			}

			var adder1Circuit = new FullAdder(TTLGateTypeEnum.LS);
			for (int i = 0; i < 200; i++)
			{
				adder1Circuit.A.Add(signalGenerator1.Output(i));
				adder1Circuit.B.Add(signalGenerator2.Output(i));
				adder1Circuit.Cin.Add(signalGenerator3.Output(i));
			}

			adder1Circuit.RunCircuit();


			for (int i = 0; i < 200; i++)
			{
				_logger.Debug($"T:{i:000} IN1:{signalGenerator1.Output(i)} IN2:{signalGenerator2.Output(i)} Cin:{signalGenerator3.Output(i)}  S:{adder1Circuit.S(i)}  Cout:{adder1Circuit.Cout(i)}");
			}
		}

		static void HalfAdderTest2()
		{
			var signalGenerator1 = new SignalGenerator();
			var signalGenerator2 = new SignalGenerator();

			bool signalHigh = true;
			bool longSignalHigh = true;
			for (int i = 0; i < 200; i++)
			{
				if (i % 20 == 0)
				{
					signalHigh = !signalHigh;
				}

				if (i % 40 == 0)
				{
					longSignalHigh = !longSignalHigh;
				}

				signalGenerator1.AddSample(signalHigh ? 5 : 0);
				signalGenerator2.AddSample(longSignalHigh ? 5 : 0);
			}

			var adder1Circuit = new HalfAdder(TTLGateTypeEnum.LS);
			for (int i = 0; i < 200; i++)
			{
				adder1Circuit.A.Add(signalGenerator1.Output(i));
				adder1Circuit.B.Add(signalGenerator2.Output(i));
			}

			adder1Circuit.RunCircuit();



			for (int i = 0; i < 200; i++)
			{
				_logger.Debug($"T:{i:000} IN1:{signalGenerator1.Output(i)} IN2:{signalGenerator2.Output(i)}  S:{adder1Circuit.S(i)}  C:{adder1Circuit.Cout(i)}");
			}
		}

		static void HalfAdderTest()
		{
			var signalGenerator1 = new SignalGenerator();
			var signalGenerator2 = new SignalGenerator();

			bool signalHigh = true;
			bool longSignalHigh = true;
			for (int i = 0; i < 200; i++)
			{
				if (i%20 == 0)
				{
					signalHigh = !signalHigh;
				}

				if (i%40 == 0)
				{
					longSignalHigh = !longSignalHigh;
				}

				signalGenerator1.AddSample(signalHigh ? 5 : 0);
				signalGenerator2.AddSample(longSignalHigh ? 5 : 0);
			}

			var xorGate = new XorGate(TTLGateTypeEnum.Normal, 2);
			var andGate = new AndGate(TTLGateTypeEnum.Normal, 2);

			var circuit = new Circuit();
			circuit.Gates.Add(xorGate);
			circuit.Gates.Add(andGate);
			circuit.Gates.Add(signalGenerator1);
			circuit.Gates.Add(signalGenerator2);

			circuit.Connections.Add(new Connection
			{
				Source = signalGenerator1,
				Termination = xorGate.Inputs[0]
			});

			circuit.Connections.Add(new Connection
			{
				Source = signalGenerator2,
				Termination = xorGate.Inputs[1]
			});

			circuit.Connections.Add(new Connection
			{
				Source = signalGenerator1,
				Termination = andGate.Inputs[0]
			});

			circuit.Connections.Add(new Connection
			{
				Source = signalGenerator2,
				Termination = andGate.Inputs[1]
			});

			circuit.RunCircuit();

			for (int i = 0; i < 200; i++)
			{
				_logger.Debug($"T:{i:000} IN1:{signalGenerator1.Output(i)} IN2:{signalGenerator2.Output(i)}  S:{xorGate.Output(i)}  C:{andGate.Output(i)}");
			}
		}

		static void AndGateTest()
		{
			var signalGenerator = new SignalGenerator();

			double voltage = 0;
			for (int i = 0; i < 50; i++)
			{
				signalGenerator.AddSample(voltage);

				if (voltage < 5)
				{
					voltage += 0.5;
				}
			}

			var ground = new Ground(50);

			var circuit = new Circuit();
			circuit.Gates.Add(new XorGate(TTLGateTypeEnum.Normal, 2));
			circuit.Gates.Add(signalGenerator);
			circuit.Gates.Add(ground);
			circuit.Connections.Add(new Connection
			{
				Source = signalGenerator,
				Termination = circuit.Gates[0].Inputs[0]
			});
			circuit.Connections.Add(new Connection
			{
				Source = ground,
				Termination = circuit.Gates[0].Inputs[1]
			});

			circuit.RunCircuit();

			for (int i = 0; i < 30; i++)
			{
				Console.WriteLine("T:" + i + " IN1:" + circuit.Gates[0].Inputs[0].InputSample[i].Voltage + " IN2:" + circuit.Gates[0].Inputs[1].InputSample[i].Voltage + " out:" + circuit.Gates[0].Output(i));
			}

			Console.ReadKey();
		}
	}
}
