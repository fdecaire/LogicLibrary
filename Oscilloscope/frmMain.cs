using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLibrary;

namespace Oscilloscope
{
	public partial class frmMain : Form
	{
		private FullAdder adder1Circuit = new FullAdder(TTLGateTypeEnum.LS);
		private SignalGenerator signalGenerator1 = new SignalGenerator();
		private SignalGenerator signalGenerator2 = new SignalGenerator();
		private SignalGenerator signalGenerator3 = new SignalGenerator();
		private FalstadCircuit falstadCircuit = new FalstadCircuit(TTLGateTypeEnum.Normal);
		private SRLatch srLatch = new SRLatch(TTLGateTypeEnum.Perfect);
		private JKMasterSlave jkFlipFlop = new JKMasterSlave(TTLGateTypeEnum.Normal);

		public frmMain()
		{
			InitializeComponent();

			//SimulateFalstadCircuit();
			//SimulateFullAdder();
			//SimulateSRLatch();
			SimulateJKFlipFlop();
		}

		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			//FullAdderPaint();
			//FalstadPaint();
			//SRLatchPaint();
			JKFlipFlopPaint();
		}

		private void SimulateJKFlipFlop()
		{
			bool signalHigh = true;

			for (int i = 0; i < 200; i++)
			{
				if (i % 40 == 0 && i > 0)
				{
					signalHigh = !signalHigh;
				}

				if (i > 2)
				{
					jkFlipFlop.J.Add(5);
					jkFlipFlop.K.Add(5);
				}
				else
				{
					// set jk flipflop
					jkFlipFlop.J.Add(5);
					jkFlipFlop.K.Add(0);
				}

				jkFlipFlop.Clk.Add(signalHigh ? 5 : 0);
			}

			jkFlipFlop.RunCircuit();
		}

		private void JKFlipFlopPaint()
		{
			Pen aPen = (Pen) Pens.Black;
			Graphics g = this.CreateGraphics();

			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			int leftOffset = 120;
			int topOffset = 100;
			int spacing = 80;
			int timingWidth = 4;

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);

			g.DrawString("J", font, Brushes.Black, 5, Height - 20 - (spacing*6 + topOffset));
			g.DrawString("K", font, Brushes.Black, 5, Height - 20 - (spacing*5 + topOffset));
			g.DrawString("CLK", font, Brushes.Red, 5, Height - 20 - (spacing*4 + topOffset));
			g.DrawString("Q", font, Brushes.Blue, 5, Height - 20 - (spacing*3 + topOffset));
			g.DrawString("QBar", font, Brushes.Blue, 5, Height - 20 - (spacing*2 + topOffset));

			//g.DrawString("G3", font, Brushes.BlueViolet, 5, Height - 20 - (spacing*1 + topOffset));
			//g.DrawString("G4", font, Brushes.BlueViolet, 5, Height - 20 - (spacing*0 + topOffset));

			for (int i = 1; i < jkFlipFlop.Count; i++)
			{
				// inputs
				g.DrawLine(Pens.Black,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.J.Output(i - 1)*5 + topOffset + spacing*6),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.J.Output(i)*5 + topOffset + spacing*6));

				g.DrawLine(Pens.Black,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.K.Output(i - 1)*5 + topOffset + spacing*5),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.K.Output(i)*5 + topOffset + spacing*5));

				g.DrawLine(Pens.Red,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Clk.Output(i - 1)*5 + topOffset + spacing*4),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Clk.Output(i)*5 + topOffset + spacing*4));

				// outputs
				g.DrawLine(Pens.Blue,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Q(i - 1)*5 + topOffset + spacing*3),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Q(i)*5 + topOffset + spacing*3));

				g.DrawLine(Pens.Blue,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.QNot(i - 1)*5 + topOffset + spacing*2),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.QNot(i)*5 + topOffset + spacing*2));

				// test outputs
				/*
				g.DrawLine(Pens.BlueViolet,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Gate3Output(i - 1)*5 + topOffset + spacing*1),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Gate3Output(i)*5 + topOffset + spacing*1));

				g.DrawLine(Pens.BlueViolet,
					i*timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Gate4Output(i - 1)*5 + topOffset + spacing*0),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) jkFlipFlop.Gate4Output(i)*5 + topOffset + spacing*0));
				// grid
				*/
				g.DrawLine(Pens.Gray,
					i*timingWidth + leftOffset,
					Height - 50 - (i%10 == 0 ? 30 : 0),
					i*timingWidth + leftOffset,
					Height);
				
			}
		}

		private void SimulateSRLatch()
		{
			bool carryInSignalHigh = true;
			for (int i = 0; i < 200; i++)
			{
				if (i % 30 == 0 && i > 0)
				{
					carryInSignalHigh = !carryInSignalHigh;
				}

				if (i < 100)
				{
					signalGenerator1.AddSample(carryInSignalHigh ? 5 : 0);
					signalGenerator2.AddSample(5);
				}
				else
				{
					signalGenerator1.AddSample(5);
					signalGenerator2.AddSample(carryInSignalHigh ? 5 : 0);
				}
			}

			for (int i = 0; i < 200; i++)
			{
				if (i == 0)
				{
					srLatch.S.Add(5);
					srLatch.R.Add(0);
				}
				else
				{
					srLatch.S.Add(signalGenerator1.Output(i));
					srLatch.R.Add(signalGenerator2.Output(i));
				}
			}

			srLatch.RunCircuit();
		}

		private void SRLatchPaint()
		{
			Pen aPen = (Pen) Pens.Black;
			Graphics g = this.CreateGraphics();

			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			int leftOffset = 120;
			int topOffset = 100;
			int spacing = 80;
			int timingWidth = 4;

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);

			g.DrawString("S", font, Brushes.Black, 5, Height - 20 -  (topOffset+ spacing * 3));
			g.DrawString("R", font, Brushes.Red, 5, Height - 20 -  (topOffset+ spacing * 2));
			g.DrawString("Q", font, Brushes.Blue, 5, Height - 20 - (topOffset + spacing*1));
			g.DrawString("QBar", font, Brushes.Green, 5, Height - 20 - topOffset);

			for (int i = 1; i < 200; i++)
			{
				// inputs
				g.DrawLine(Pens.Black,
					i*timingWidth + leftOffset,
					Height - ((float) srLatch.S.Output(i - 1)*5 + topOffset + spacing*3),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) srLatch.S.Output(i)*5 + topOffset + spacing*3));

				g.DrawLine(Pens.Red,
					i*timingWidth + leftOffset,
					Height - ((float) srLatch.R.Output(i - 1)*5 + topOffset + spacing*2),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) srLatch.R.Output(i)*5 + topOffset + spacing*2));

				// outputs
				g.DrawLine(Pens.Blue,
					i*timingWidth + leftOffset,
					Height - ((float) srLatch.Q(i - 1)*5 + topOffset + spacing*1),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) srLatch.Q(i)*5 + topOffset + spacing*1));

				g.DrawLine(Pens.Green,
					i*timingWidth + leftOffset,
					Height - ((float) srLatch.QBar(i - 1)*5 + topOffset + spacing*0),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) srLatch.QBar(i)*5 + topOffset + spacing*0));

				// grid
				/*
				g.DrawLine(Pens.Gray,
					i*timingWidth + leftOffset,
					Height - 50 - (i%10 == 0 ? 30 : 0),
					i*timingWidth + leftOffset,
					Height);
				*/
			}
		}

		private void SimulateFalstadCircuit()
		{
			bool carryInSignalHigh = false;
			for (int i = 0; i < 200; i++)
			{
				if (i % 30 == 0 && i > 0)
				{
					carryInSignalHigh = !carryInSignalHigh;
				}
				signalGenerator1.AddSample(carryInSignalHigh ? 5 : 0);
			}

			for (int i = 0; i < 200; i++)
			{
				falstadCircuit.Input.Add(signalGenerator1.Output(i));
			}

			falstadCircuit.RunCircuit();
		}

		private void FalstadPaint()
		{
			Pen aPen = (Pen)Pens.Black;
			Graphics g = this.CreateGraphics();

			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			int leftOffset = 120;
			int topOffset = 100;
			int spacing = 80;
			int timingWidth = 4;

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);

			g.DrawString("Input", font, Brushes.Black, 5, Height - 20 - (spacing * 1 + topOffset * 2));
			g.DrawString("Inverter Out", font, Brushes.Red, 5, Height - 20 - (spacing * 1 + topOffset));
			g.DrawString("Output", font, Brushes.Blue, 5, Height - 20 - topOffset);

			for (int i = 1; i < 200; i++)
			{
				// inputs
				g.DrawLine((Pen)Pens.Black,
					i * timingWidth + leftOffset,
					Height - ((float)signalGenerator1.Output(i - 1) * 5 + topOffset + spacing * 2),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)signalGenerator1.Output(i) * 5 + topOffset + spacing * 2));

				g.DrawLine((Pen)Pens.Red,
					i * timingWidth + leftOffset,
					Height - ((float)falstadCircuit.InverterOutput(i - 1) * 5 + topOffset + spacing),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)falstadCircuit.InverterOutput(i) * 5 + topOffset + spacing));

				// outputs
				g.DrawLine((Pen)Pens.Blue,
					i * timingWidth + leftOffset,
					Height - ((float)falstadCircuit.Output(i - 1) * 5 + topOffset),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)falstadCircuit.Output(i) * 5 + topOffset));
			}
		}

		private void SimulateFullAdder()
		{
			bool carryInSignalHigh = false;
			bool signalBHigh = false;
			bool signalAHigh = false;
			for (int i = 0; i < 300; i++)
			{
				if (i % 30 == 0 && i > 0)
				{
					carryInSignalHigh = !carryInSignalHigh;
				}

				if (i % 60 == 0 && i > 0)
				{
					signalBHigh = !signalBHigh;
				}

				if (i % 120 == 0 && i > 0)
				{
					signalAHigh = !signalAHigh;
				}

				signalGenerator1.AddSample(carryInSignalHigh ? 5 : 0);
				signalGenerator2.AddSample(signalBHigh ? 5 : 0);
				signalGenerator3.AddSample(signalAHigh ? 5 : 0);
			}

			for (int i = 0; i < 300; i++)
			{
				adder1Circuit.A.Add(signalGenerator3.Output(i));
				adder1Circuit.B.Add(signalGenerator2.Output(i));
				adder1Circuit.Cin.Add(signalGenerator1.Output(i));
			}

			adder1Circuit.RunCircuit();
		}

		private void FullAdderPaint()
		{

			Pen aPen = (Pen)Pens.Black;
			Graphics g = this.CreateGraphics();

			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			int leftOffset = 80;
			int topOffset = 100;
			int spacing = 80;
			int timingWidth = 4;

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);

			g.DrawString("A", font, Brushes.Black, 5, Height - 20 - topOffset);
			g.DrawString("B", font, Brushes.Red, 5, Height - 20 - (spacing * 1 + topOffset));
			g.DrawString("Cin", font, Brushes.Green, 5, Height - 20 - (spacing * 2 + topOffset));
			g.DrawString("S", font, Brushes.Blue, 5, Height - 20 - (spacing * 3 + topOffset));
			g.DrawString("Cout", font, Brushes.Purple, 5, Height - 20 - (spacing * 4 + topOffset));

			for (int i = 1; i < 300; i++)
			{
				// inputs
				g.DrawLine((Pen)Pens.Black,
					i * timingWidth + leftOffset,
					Height - ((float)signalGenerator3.Output(i - 1) * 5 + topOffset),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)signalGenerator3.Output(i) * 5 + topOffset));
				g.DrawLine((Pen)Pens.Red,
					i * timingWidth + leftOffset,
					Height - ((float)signalGenerator2.Output(i - 1) * 5 + topOffset + spacing),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)signalGenerator2.Output(i) * 5 + topOffset + spacing));
				g.DrawLine((Pen)Pens.Green,
					i * timingWidth + leftOffset,
					Height - ((float)signalGenerator1.Output(i - 1) * 5 + topOffset + spacing * 2),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)signalGenerator1.Output(i) * 5 + topOffset + spacing * 2));

				// outputs
				g.DrawLine((Pen)Pens.Blue,
					i * timingWidth + leftOffset,
					Height - ((float)adder1Circuit.S(i - 1) * 5 + topOffset + spacing * 3),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)adder1Circuit.S(i) * 5 + topOffset + spacing * 3));
				g.DrawLine((Pen)Pens.Purple,
					i * timingWidth + leftOffset,
					Height - ((float)adder1Circuit.Cout(i - 1) * 5 + topOffset + spacing * 4),
					i * timingWidth + timingWidth + leftOffset,
					Height - ((float)adder1Circuit.Cout(i) * 5 + topOffset + spacing * 4));
			}
		}
	}
}
