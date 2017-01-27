namespace LogicLibrary
{
	public static class OutputHelpers
	{
		// invert an output
		public static double Inverted(this double input)
		{
			if (input < 0.2)
			{
				return 5;
			}
			return 0;
		}
	}
}
