namespace LogicLibrary
{
	public class InputSignal
	{
		public int Timing { get; set; } // number of ns from start of signal
		public double Voltage { get; set; } // volt reading at the time
		public bool Unknown { get; set; } = true;
	}
}
