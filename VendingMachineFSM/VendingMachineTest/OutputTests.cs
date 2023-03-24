using System;
using Xunit;
using VendingMachineFSM;

namespace VendingMachineTest
{
    public class OutputTests
    {
        [Fact]
        public void GumTest()
        {
            Assert.Equal("Gum, which costs $0.50", Gum.Instance.Describe());
        }

        [Fact]
        public void GranolaTest()
        {
            Assert.Equal("Granola, which costs $0.75", Granola.Instance.Describe());
        }

        [Fact]
        public void QuarterTest()
        {
            Assert.Equal("You got a Quarter, which gave you back $0.25", Quarter.Instance.Describe());
        }

        [Fact]
        public void TransactionTest()
        {
            Transaction.Instance.ResetTransaction();
            Assert.Equal(0, Transaction.Instance.currentPrice);

            Transaction.Instance.AddQuarter();
            Assert.Equal(0.25M, Transaction.Instance.currentPrice);

            Transaction.Instance.AddQuarter();
            Assert.Equal(0.50M, Transaction.Instance.currentPrice);

            Transaction.Instance.ResetTransaction();
            Assert.Equal(0, Transaction.Instance.currentPrice);
        }
    }
}
