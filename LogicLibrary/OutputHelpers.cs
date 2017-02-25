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

		public static bool VoltageToBoolean(this double input)
		{
			if (input < 0.2)
			{
				return false;
			}
			return true;
		}

		public static int VoltageToOneZero(this double input)
		{
			if (input < 0.2)
			{
				return 0;
			}
			return 1;
		}
	}
}
