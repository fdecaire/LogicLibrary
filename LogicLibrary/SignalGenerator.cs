using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class SignalGenerator : LogicGate
	{
		private InputData _outputData { get; set; } = new InputData();
		
		public SignalGenerator() : base( 0)
		{
			GateName = "Signal";
		}

		public override double Output(int timing)
		{
			if (timing > _outputData.InputSample.Count || timing < 0)
			{
				return 0;
			}

			return _outputData.InputSample[timing].Voltage;
		}

		public override int Count
		{
			get { return _outputData.InputSample.Count; }
		}

		public void AddSample(double volts)
		{
			_outputData.InputSample.Add(new InputSignal
			{
				Timing = _outputData.InputSample.Count,
				Voltage = volts
			});
		}
	}
}
