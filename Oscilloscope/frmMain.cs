using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

		public frmMain()
		{
			InitializeComponent();

			bool carryInSignalHigh = false;
			bool signalBHigh = false;
			bool signalAHigh = false;
			for (int i = 0; i < 300; i++)
			{
				if (i%30 == 0 && i > 0)
				{
					carryInSignalHigh = !carryInSignalHigh;
				}

				if (i%60 == 0 && i > 0)
				{
					signalBHigh = !signalBHigh;
				}

				if (i%120 == 0 && i > 0)
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

		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			Pen aPen = (Pen) Pens.Black;
			Graphics g = this.CreateGraphics();

			g.FillRectangle(Brushes.White, 0, 0, Width, Height);

			int leftOffset = 80;
			int topOffset = 100;
			int spacing = 80;
			int timingWidth = 4;

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);

			g.DrawString("A", font, Brushes.Black, 5, Height -20 - topOffset);
			g.DrawString("B", font, Brushes.Red, 5, Height - 20 - (spacing*1 + topOffset));
			g.DrawString("Cin", font, Brushes.Green, 5, Height - 20 - (spacing*2 + topOffset));
			g.DrawString("S", font, Brushes.Blue, 5, Height - 20 - (spacing*3 + topOffset));
			g.DrawString("Cout", font, Brushes.Purple, 5, Height - 20 - (spacing*4 + topOffset));

			for (int i = 1; i < 300; i++)
			{
				// inputs
				g.DrawLine((Pen) Pens.Black,
					i*timingWidth + leftOffset,
					Height - ((float) signalGenerator3.Output(i - 1)*5 + topOffset),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) signalGenerator3.Output(i)*5 + topOffset));
				g.DrawLine((Pen) Pens.Red,
					i*timingWidth + leftOffset,
					Height - ((float) signalGenerator2.Output(i - 1)*5 + topOffset + spacing),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) signalGenerator2.Output(i)*5 + topOffset + spacing));
				g.DrawLine((Pen) Pens.Green,
					i*timingWidth + leftOffset,
					Height - ((float) signalGenerator1.Output(i - 1)*5 + topOffset + spacing*2),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) signalGenerator1.Output(i)*5 + topOffset + spacing*2));

				// outputs
				g.DrawLine((Pen) Pens.Blue,
					i*timingWidth + leftOffset,
					Height - ((float) adder1Circuit.S(i - 1)*5 + topOffset + spacing*3),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) adder1Circuit.S(i)*5 + topOffset + spacing*3));
				g.DrawLine((Pen) Pens.Purple,
					i*timingWidth + leftOffset,
					Height - ((float) adder1Circuit.C(i - 1)*5 + topOffset + spacing*4),
					i*timingWidth + timingWidth + leftOffset,
					Height - ((float) adder1Circuit.C(i)*5 + topOffset + spacing*4));
			}
		}
	}
}
