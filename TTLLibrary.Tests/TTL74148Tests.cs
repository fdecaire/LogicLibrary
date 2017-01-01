using LogicLibrary;
using Xunit;

namespace TTLLibrary.Tests
{
	public class TTL74148Tests
	{
		[Fact]
		public void ttl_74138_disable_inputs()
		{
			var priorityEncoder = new TTL74148(TTLGateTypeEnum.Perfect);

			priorityEncoder.I0.Add(5);
			priorityEncoder.I1.Add(5);
			priorityEncoder.I2.Add(0);
			priorityEncoder.I3.Add(0);
			priorityEncoder.I4.Add(0);
			priorityEncoder.I5.Add(0);
			priorityEncoder.I6.Add(0);
			priorityEncoder.I7.Add(0);
			priorityEncoder.EI.Add(5);

			priorityEncoder.RunCircuit();

			Assert.True(priorityEncoder.VerifyAllGateInputsConnected());
			Assert.True(priorityEncoder.CircuitCompletedSuccessfully);

			Assert.Equal(5, priorityEncoder.EO(0));
			Assert.Equal(5, priorityEncoder.GS(0));

			Assert.Equal(5, priorityEncoder.A0(0));
			Assert.Equal(5, priorityEncoder.A1(0));
			Assert.Equal(5, priorityEncoder.A2(0));
		}

		[Theory]
		[InlineData(5, 5, 0, 0, 5, 5, 5, 0, 0, 0, 0)]
		[InlineData(5, 5, 0, 0, 5, 5, 0, 5, 0, 0, 5)]
		[InlineData(5, 5, 0, 0, 5, 0, 5, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 0, 0, 5, 5, 5, 0, 5, 5)]
		[InlineData(5, 5, 0, 0, 5, 5, 5, 5, 5, 0, 0)]
		[InlineData(5, 5, 0, 5, 5, 5, 5, 5, 5, 0, 5)]
		[InlineData(5, 0, 5, 5, 5, 5, 5, 5, 5, 5, 0)]
		[InlineData(0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)]
		public void ttl_74138(int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int a2, int a1, int a0)
		{
			var priorityEncoder = new TTL74148(TTLGateTypeEnum.Perfect);

			priorityEncoder.I0.Add(i0);
			priorityEncoder.I1.Add(i1);
			priorityEncoder.I2.Add(i2);
			priorityEncoder.I3.Add(i3);
			priorityEncoder.I4.Add(i4);
			priorityEncoder.I5.Add(i5);
			priorityEncoder.I6.Add(i6);
			priorityEncoder.I7.Add(i7);
			priorityEncoder.EI.Add(0);

			priorityEncoder.RunCircuit();

			Assert.True(priorityEncoder.VerifyAllGateInputsConnected());
			Assert.True(priorityEncoder.CircuitCompletedSuccessfully);

			Assert.Equal(5, priorityEncoder.EO(0));
			Assert.Equal(0, priorityEncoder.GS(0));

			Assert.Equal(a0, priorityEncoder.A0(0));
			Assert.Equal(a1, priorityEncoder.A1(0));
			Assert.Equal(a2, priorityEncoder.A2(0));
		}
	}
}
