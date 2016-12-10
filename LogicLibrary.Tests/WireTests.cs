using Xunit;

namespace LogicLibrary.Tests
{
	public class WireTests
	{
		[Fact]
		public void count_input_samples()
		{
			var wire = new Wire();
			wire.Add(5);
			wire.Add(0);
			wire.Add(5);

			Assert.Equal(3,wire.Count);
		}

		[Fact]
		public void count_input_no_inputs()
		{
			var wire = new Wire();
			wire.Inputs.Clear();

			Assert.Equal(0, wire.Count);
		}

		[Fact]
		public void output_timing_less_than_zero()
		{
			var wire = new Wire();

			Assert.Equal(0, wire.Output(-2));
		}

		[Fact]
		public void output_timing_input_counts_zero()
		{
			var wire = new Wire();
			wire.Inputs.Clear();

			Assert.Equal(0, wire.Output(0));
		}

		[Fact]
		public void output_timing_greater_than_sample_count()
		{
			var wire = new Wire();
			wire.Add(5);
			wire.Add(0);

			Assert.Equal(0, wire.Output(3));
		}

		[Fact]
		public void output_input_sample_count_zero()
		{
			var wire = new Wire();

			Assert.Equal(0, wire.Output(0));
		}

		[Fact]
		public void output_normal()
		{
			var wire = new Wire();
			wire.Add(5);

			Assert.Equal(5, wire.Output(0));
		}
	}
}
