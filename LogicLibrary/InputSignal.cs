using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
	public class InputSignal
	{
		public int Timing { get; set; } // number of ns from start of signal
		public double Voltage { get; set; } // volt reading at the time
	}
}
