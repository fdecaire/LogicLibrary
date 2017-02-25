using System.Linq;
using Xunit;

namespace GALCircuits.Tests
{
	public class pds_file_parser_tests
	{
		[Fact]
		public void parse_for_inputs()
		{
			var circuit = new GAL16V8();
			circuit.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			Assert.Equal(17, circuit.Fuses[0]);
			Assert.Equal(33, circuit.Fuses[1]);
			Assert.Equal(41, circuit.Fuses[2]);
			Assert.Equal(58, circuit.Fuses[3]);
			Assert.Equal(65, circuit.Fuses[4]);
			Assert.Equal(76, circuit.Fuses[5]);
			Assert.Equal(90, circuit.Fuses[6]);
		}

		[Fact]
		public void parse_output_inverted()
		{
			var circuit = new GAL16V8();
			circuit.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			Assert.True(circuit.Fuses.Contains(2048));
			Assert.True(circuit.Fuses.Contains(2049));
			Assert.True(circuit.Fuses.Contains(2050));
			Assert.True(circuit.Fuses.Contains(2051));
			Assert.True(circuit.Fuses.Contains(2052));
			Assert.True(circuit.Fuses.Contains(2053));
			Assert.True(circuit.Fuses.Contains(2054));
			Assert.True(circuit.Fuses.Contains(2055));
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5)]
		[InlineData(0, 0, 0, 5, 5, 0, 0, 5, 5, 5, 5)]
		[InlineData(0, 0, 5, 0, 0, 0, 5, 0, 0, 5, 0)]
		[InlineData(0, 0, 5, 5, 0, 0, 0, 0, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 5, 0, 0, 5, 5, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 5, 0, 0, 5, 0, 0)]
		[InlineData(0, 5, 5, 0, 0, 5, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 5, 0, 0, 0, 5, 5, 5, 5)]
		[InlineData(5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(5, 0, 0, 5, 0, 0, 0, 5, 5, 0, 0)]
		[InlineData(5, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0)]
		[InlineData(5, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0)]
		[InlineData(5, 5, 0, 0, 0, 5, 5, 0, 0, 0, 5)]
		[InlineData(5, 5, 0, 5, 5, 0, 0, 0, 0, 5, 0)]
		[InlineData(5, 5, 5, 0, 0, 5, 5, 0, 0, 0, 0)]
		[InlineData(5, 5, 5, 5, 0, 5, 5, 5, 0, 0, 0)]
		public void hex_display_test_w_pds_file(int d3, int d2, int d1, int d0, int A, int B, int C, int D, int E, int F, int G)
		{
			var hexDisplay = new GAL16V8();
			hexDisplay.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			hexDisplay.I1.Add(0); // RBI

			hexDisplay.I2.Add(d0); // D0
			hexDisplay.I3.Add(d1); // D1
			hexDisplay.I4.Add(d2); // D2
			hexDisplay.I5.Add(d3); // D3

			hexDisplay.I6.Add(0); // IC
			hexDisplay.I7.Add(0); // LT

			Assert.Equal(A, hexDisplay.O19(0)); // A
			Assert.Equal(B, hexDisplay.O18(0)); // B
			Assert.Equal(C, hexDisplay.O17(0)); // C
			Assert.Equal(D, hexDisplay.O16(0)); // D
			Assert.Equal(E, hexDisplay.O15(0)); // E
			Assert.Equal(F, hexDisplay.O14(0)); // F
			Assert.Equal(G, hexDisplay.O12(0)); // G
		}

		[Fact]
		public void hex_display_pds_jed_compare_fuse_count()
		{
			var hexDisplayPds = new GAL16V8();
			hexDisplayPds.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			var hexDisplayJed = new GAL16V8();
			hexDisplayJed.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			// total matrix fuses
			int totalPdsMatrixFuses = (from a in hexDisplayPds.Fuses where a < 2048 select a).Count();
			int totalJedMatrixFuses = (from a in hexDisplayJed.Fuses where a < 2048 select a).Count();
			Assert.Equal(totalPdsMatrixFuses,totalJedMatrixFuses);

			// total fuses
			Assert.Equal(hexDisplayPds.Fuses.Count, hexDisplayJed.Fuses.Count);
		}

		[Fact]
		public void hex_display_pds_jed_compare_matrix_fuses()
		{
			var hexDisplayPds = new GAL16V8();
			hexDisplayPds.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			var hexDisplayJed = new GAL16V8();
			hexDisplayJed.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			// compare matrix fuses
			// 0 - 2047 matrix
			for (int i = 0; i < 2048; i++)
			{
				var pdsVersion = hexDisplayPds.Fuses.Contains(i);
				var jedVersion = hexDisplayJed.Fuses.Contains(i);
				Assert.Equal(pdsVersion,jedVersion);
			}
		}

		[Fact]
		public void hex_display_pds_jed_compare_xor_fuses()
		{
			var hexDisplayPds = new GAL16V8();
			hexDisplayPds.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			var hexDisplayJed = new GAL16V8();
			hexDisplayJed.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			// compare matrix fuses
			for (int i = 2048; i < 2056; i++)
			{
				var pdsVersion = hexDisplayPds.Fuses.Contains(i);
				var jedVersion = hexDisplayJed.Fuses.Contains(i);
				Assert.Equal(pdsVersion, jedVersion);
			}
		}

		[Fact]
		public void hex_display_pds_jed_compare_ac1_fuses()
		{
			var hexDisplayPds = new GAL16V8();
			hexDisplayPds.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			var hexDisplayJed = new GAL16V8();
			hexDisplayJed.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			// compare matrix fuses
			for (int i = 2120; i < 2128; i++)
			{
				var pdsVersion = hexDisplayPds.Fuses.Contains(i);
				var jedVersion = hexDisplayJed.Fuses.Contains(i);
				Assert.Equal(pdsVersion, jedVersion);
			}
		}

		[Fact]
		public void hex_display_pds_jed_compare_ptd_fuses()
		{
			var hexDisplayPds = new GAL16V8();
			hexDisplayPds.LoadPDS("GALCircuits.Tests.Data.hex_display.pds");

			var hexDisplayJed = new GAL16V8();
			hexDisplayJed.LoadJEDEC("GALCircuits.Tests.Data.hex_display.jed");

			// compare matrix fuses
			for (int i = 2128; i < 2192; i++)
			{
				var pdsVersion = hexDisplayPds.Fuses.Contains(i);
				var jedVersion = hexDisplayJed.Fuses.Contains(i);
				Assert.Equal(pdsVersion, jedVersion);
			}
		}
	}
}
