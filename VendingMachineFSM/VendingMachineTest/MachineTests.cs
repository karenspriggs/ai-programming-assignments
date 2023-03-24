using System;
using Xunit;
using VendingMachineFSM;

namespace VendingMachineTest
{
    public class MachineTests
    {
        [Fact]
        public void VendingMachineTests()
        {
            VendingMachine vm = new VendingMachine();
            Assert.Equal(VendingMachineState.Active, vm.currentState);
            Assert.Equal(Output.Nothing, vm.currentOutput);
        }
    }
}
