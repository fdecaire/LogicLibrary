using System;
using System.Threading;
using LogicLibrary;
using TTLLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTLTests
	{
		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 0)]
		public void TTL7400_test(double input1, double input2, double expectedOutput)
		{
			var nandGate = new TTL7400(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 5)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 0)]
		public void TTL7402_test(double input1, double input2, double expectedOutput)
		{
			var norGate = new TTL7402(TTLGateTypeEnum.Perfect);

			norGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			norGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = norGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 5)]
		[InlineData(5, 0)]
		public void TTL7404_test(double input, double expectedOutput)
		{
			var inverter = new TTL7404(TTLGateTypeEnum.Perfect);

			inverter.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input, Unknown = false});

			var result = inverter.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 0)]
		[InlineData(5, 0, 0)]
		[InlineData(5, 5, 5)]
		public void TTL7408_test(double input1, double input2, double expectedOutput)
		{
			var nandGate = new TTL7408(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 5)]
		[InlineData(0, 5, 0, 5)]
		[InlineData(0, 5, 5, 5)]
		[InlineData(5, 0, 0, 5)]
		[InlineData(5, 0, 5, 5)]
		[InlineData(5, 5, 0, 5)]
		[InlineData(5, 5, 5, 0)]
		public void TTL7410_test(double input1, double input2, double input3, double expectedOutput)
		{
			var nandGate = new TTL7410(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5)]
		public void TTL7411_test(double input1, double input2, double input3, double expectedOutput)
		{
			var nandGate = new TTL7411(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5)]
		[InlineData(0, 0, 0, 5, 5)]
		[InlineData(0, 0, 5, 0, 5)]
		[InlineData(0, 0, 5, 5, 5)]
		[InlineData(0, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 5)]
		[InlineData(5, 0, 0, 5, 5)]
		[InlineData(5, 0, 5, 0, 5)]
		[InlineData(5, 0, 5, 5, 5)]
		[InlineData(5, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0)]
		public void TTL7420_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var nandGate = new TTL7420(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			nandGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(0, 0, 0, 5, 0)]
		[InlineData(0, 0, 5, 0, 0)]
		[InlineData(0, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0)]
		[InlineData(0, 5, 5, 0, 0)]
		[InlineData(0, 5, 5, 5, 0)]
		[InlineData(5, 0, 0, 0, 0)]
		[InlineData(5, 0, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 0)]
		[InlineData(5, 0, 5, 5, 0)]
		[InlineData(5, 5, 0, 0, 0)]
		[InlineData(5, 5, 0, 5, 0)]
		[InlineData(5, 5, 5, 0, 0)]
		[InlineData(5, 5, 5, 5, 5)]
		public void TTL7421_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var andGate = new TTL7421(TTLGateTypeEnum.Perfect);

			andGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			andGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			andGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			andGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			var result = andGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 5)]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0)]
		[InlineData(5, 0, 0, 0)]
		[InlineData(5, 0, 5, 0)]
		[InlineData(5, 5, 0, 0)]
		[InlineData(5, 5, 5, 0)]
		public void TTL7427_test(double input1, double input2, double input3, double expectedOutput)
		{
			var norGate = new TTL7427(TTLGateTypeEnum.Perfect);

			norGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			norGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			norGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});

			var result = norGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 5)]
		[InlineData(0, 0, 0, 5, 5)]
		[InlineData(0, 0, 5, 0, 5)]
		[InlineData(0, 0, 5, 5, 5)]
		[InlineData(0, 5, 0, 0, 5)]
		[InlineData(0, 5, 0, 5, 5)]
		[InlineData(0, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 5)]
		[InlineData(5, 0, 0, 5, 5)]
		[InlineData(5, 0, 5, 0, 5)]
		[InlineData(5, 0, 5, 5, 5)]
		[InlineData(5, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 5)]
		[InlineData(5, 5, 5, 5, 0)]
		public void TTL7430_test(double input1, double input2, double input3, double input4, double expectedOutput)
		{
			var nandGate = new TTL7430(TTLGateTypeEnum.Perfect);

			nandGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			nandGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});
			nandGate.Inputs[2].InputSample.Add(new InputSignal {Timing = 0, Voltage = input3, Unknown = false});
			nandGate.Inputs[3].InputSample.Add(new InputSignal {Timing = 0, Voltage = input4, Unknown = false});

			//TODO: need 4 more inputs to complete unit tests.

			var result = nandGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 5, 5)]
		[InlineData(5, 0, 5)]
		[InlineData(5, 5, 5)]
		public void TTL7432_test(double input1, double input2, double expectedOutput)
		{
			var orGate = new TTL7432(TTLGateTypeEnum.Perfect);

			orGate.Inputs[0].InputSample.Add(new InputSignal {Timing = 0, Voltage = input1, Unknown = false});
			orGate.Inputs[1].InputSample.Add(new InputSignal {Timing = 0, Voltage = input2, Unknown = false});

			var result = orGate.Output(0);

			Assert.Equal(expectedOutput, result);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5)] // 0
		[InlineData(0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)] // 1
		[InlineData(0, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0)] // 2
		[InlineData(0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 0)] // 3
		[InlineData(0, 5, 0, 0, 5, 0, 0, 5, 5, 0, 0)] // 4
		[InlineData(0, 5, 0, 5, 0, 5, 0, 0, 5, 0, 0)] // 5
		[InlineData(0, 5, 5, 0, 5, 5, 0, 0, 0, 0, 0)] // 6
		[InlineData(0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5)] // 7
		[InlineData(5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)] // 8
		[InlineData(5, 0, 0, 5, 0, 0, 0, 5, 5, 0, 0)] // 9
		[InlineData(5, 0, 5, 0, 5, 5, 5, 0, 0, 5, 0)] // 10
		[InlineData(5, 0, 5, 5, 5, 5, 0, 0, 5, 5, 0)] // 11
		[InlineData(5, 5, 0, 0, 5, 0, 5, 5, 5, 0, 0)] // 12
		[InlineData(5, 5, 0, 5, 0, 5, 5, 0, 5, 0, 0)] // 13
		[InlineData(5, 5, 5, 0, 5, 5, 5, 0, 0, 0, 0)] // 14
		[InlineData(5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)] // 15
		public void TTL7447_test(double D, double C, double B, double A, double outa, double outb, double outc,
			double outd, double oute, double outf, double outg)
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(A);
			decoder.B.Add(B);
			decoder.C.Add(C);
			decoder.D.Add(D);
			decoder.RBI.Add(5);
			decoder.LampTest.Add(5);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(outa, decoder.Segmenta(0));
			Assert.Equal(outb, decoder.Segmentb(0));
			Assert.Equal(outc, decoder.Segmentc(0));
			Assert.Equal(outd, decoder.Segmentd(0));
			Assert.Equal(oute, decoder.Segmente(0));
			Assert.Equal(outf, decoder.Segmentf(0));
			Assert.Equal(outg, decoder.Segmentg(0));
		}

		[Fact]
		public void TTL7447_rbi_test()
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(0);
			decoder.B.Add(0);
			decoder.C.Add(0);
			decoder.D.Add(0);
			decoder.RBI.Add(0);
			decoder.LampTest.Add(5);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(5, decoder.Segmenta(0));
			Assert.Equal(5, decoder.Segmentb(0));
			Assert.Equal(5, decoder.Segmentc(0));
			Assert.Equal(5, decoder.Segmentd(0));
			Assert.Equal(5, decoder.Segmente(0));
			Assert.Equal(5, decoder.Segmentf(0));
			Assert.Equal(5, decoder.Segmentg(0));
		}

		[Fact]
		public void TTL7447_lamp_test()
		{
			var decoder = new TTL7447(TTLGateTypeEnum.Perfect);

			decoder.A.Add(5);
			decoder.B.Add(0);
			decoder.C.Add(0);
			decoder.D.Add(0);
			decoder.RBI.Add(5);
			decoder.LampTest.Add(0);

			decoder.RunCircuit();

			Assert.True(decoder.CircuitCompletedSuccessfully);

			Assert.Equal(0, decoder.Segmenta(0));
			Assert.Equal(0, decoder.Segmentb(0));
			Assert.Equal(0, decoder.Segmentc(0));
			Assert.Equal(0, decoder.Segmentd(0));
			Assert.Equal(0, decoder.Segmente(0));
			Assert.Equal(0, decoder.Segmentf(0));
			Assert.Equal(0, decoder.Segmentg(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(5, 0, 5, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0)]
		[InlineData(5, 5, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5)]
		public void TTL74157_test(double A1, double B1, double A2, double B2, double A3, double B3, double A4, double B4,
			double Y1, double Y2, double Y3, double Y4, double select)
		{
			var multiplexer = new TTL74157(TTLGateTypeEnum.Perfect);

			multiplexer.A1.Add(A1);
			multiplexer.B1.Add(B1);
			multiplexer.A2.Add(A2);
			multiplexer.B2.Add(B2);
			multiplexer.A3.Add(A3);
			multiplexer.B3.Add(B3);
			multiplexer.A4.Add(A4);
			multiplexer.B4.Add(B4);
			multiplexer.Select.Add(select);
			multiplexer.Strobe.Add(0);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(Y1, multiplexer.Y1(0));
			Assert.Equal(Y2, multiplexer.Y2(0));
			Assert.Equal(Y3, multiplexer.Y3(0));
			Assert.Equal(Y4, multiplexer.Y4(0));
		}

		[Fact]
		public void TTL74157_strobe_test()
		{
			var multiplexer = new TTL74157(TTLGateTypeEnum.Perfect);

			multiplexer.A1.Add(5);
			multiplexer.B1.Add(5);
			multiplexer.A2.Add(5);
			multiplexer.B2.Add(5);
			multiplexer.A3.Add(5);
			multiplexer.B3.Add(5);
			multiplexer.A4.Add(5);
			multiplexer.B4.Add(5);
			multiplexer.Select.Add(0);
			multiplexer.Strobe.Add(5);

			multiplexer.RunCircuit();

			Assert.True(multiplexer.CircuitCompletedSuccessfully);

			Assert.Equal(0, multiplexer.Y1(0));
			Assert.Equal(0, multiplexer.Y2(0));
			Assert.Equal(0, multiplexer.Y3(0));
			Assert.Equal(0, multiplexer.Y4(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 5, 5, 5, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 5, 0, 5, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 0, 5, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 0, 5, 5, 5, 5, 0)]
		[InlineData(5, 0, 0, 0, 0, 5, 0, 5, 5, 5)]
		[InlineData(5, 0, 5, 5, 0, 0, 5, 5, 5, 0)]
		[InlineData(5, 5, 0, 5, 5, 0, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 0, 0, 5, 5, 5, 0)]
		public void TTL74381_function_selector(int s0, int s1, int s2, int g19, int g20, int g21, int g14, int g15, int g16,
			int g22)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(s0);
			alu.S1.Add(s1);
			alu.S2.Add(s2);
			alu.Cn.Add(0);
			alu.RunCircuit();

			Assert.Equal(g19, alu.GateOutput(19, 0));
			Assert.Equal(g20, alu.GateOutput(20, 0));
			Assert.Equal(g21, alu.GateOutput(21, 0));
			Assert.Equal(g14, alu.GateOutput(14, 0));
			Assert.Equal(g15, alu.GateOutput(15, 0));
			Assert.Equal(g16, alu.GateOutput(16, 0));
			Assert.Equal(g22, alu.GateOutput(22, 0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a0_b0(int a0, int b0, int g63, int g64, int f0, int f1)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(a0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(0);
			alu.B0.Add(b0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g63, alu.GateOutput(63, 0));
			Assert.Equal(g64, alu.GateOutput(64, 0));

			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F1(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a1_b1(int a1, int b1, int g65, int g66, int f1, int f2)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(a1);
			alu.A2.Add(0);
			alu.A3.Add(0);
			alu.B0.Add(0);
			alu.B1.Add(b1);
			alu.B2.Add(0);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g65, alu.GateOutput(65, 0));
			Assert.Equal(g66, alu.GateOutput(66, 0));

			Assert.Equal(f1, alu.F1(0));
			Assert.Equal(f2, alu.F2(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a2_b2(int a2, int b2, int g67, int g68, int f2, int f3)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(a2);
			alu.A3.Add(0);
			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(b2);
			alu.B3.Add(0);

			alu.RunCircuit();

			Assert.Equal(g67, alu.GateOutput(67, 0));
			Assert.Equal(g68, alu.GateOutput(68, 0));

			Assert.Equal(f2, alu.F2(0));
			Assert.Equal(f3, alu.F3(0));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a3_b3(int a3, int b3, int g69, int g70, int f3, int cn)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(0);
			alu.A1.Add(0);
			alu.A2.Add(0);
			alu.A3.Add(a3);
			alu.B0.Add(0);
			alu.B1.Add(0);
			alu.B2.Add(0);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.Equal(g69, alu.GateOutput(69, 0));
			Assert.Equal(g70, alu.GateOutput(70, 0));

			Assert.Equal(f3, alu.F3(0));
			Assert.Equal(cn, alu.Cn4(0));
		}

		[Theory]
		[InlineData(5, 0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)]
		public void TTL74381_add(int a0, int b0, int a1, int b1, int a2, int b2, int a3, int b3, int f0, int f1, int f2,
			int f3)
		{
			var alu = new TTL74381(TTLGateTypeEnum.Perfect);

			alu.S0.Add(5);
			alu.S1.Add(5);
			alu.S2.Add(0);
			alu.Cn.Add(0);
			alu.A0.Add(a0);
			alu.A1.Add(a1);
			alu.A2.Add(a2);
			alu.A3.Add(a3);
			alu.B0.Add(b0);
			alu.B1.Add(b1);
			alu.B2.Add(b2);
			alu.B3.Add(b3);

			alu.RunCircuit();

			Assert.True(alu.VerifyAllGateInputsConnected());
			Assert.True(alu.CircuitCompletedSuccessfully);


			Assert.Equal(f0, alu.F0(0));
			Assert.Equal(f1, alu.F0(0));
			Assert.Equal(f2, alu.F0(0));
			Assert.Equal(f3, alu.F0(0));
		}

	}
}
