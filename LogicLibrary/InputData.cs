using System.Collections.Generic;

namespace LogicLibrary
{
	public class InputData
	{
		public List<InputSignal> InputSample = new List<InputSignal>();
		public bool InputInverted { get; set; } = false;
	}
}
