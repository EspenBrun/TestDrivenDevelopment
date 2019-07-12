using TheMoneyExample;
using Xunit;

namespace TheMoneyExampleTests
{
    public class DollarTests
    {
        [Fact]
        public void Multiplication()
        {
            var five = new Dollar(5);

            var ten = five.Times(2);

            Assert.Equal(10, ten.Amount);
        }

        [Fact]
        public void ImmutableDollar()
        {
            var five = new Dollar(5);

            var fifteen = five.Times(3);

            Assert.Equal(5, five.Amount);
            Assert.Equal(15, fifteen.Amount);
        }

        [Fact]
        public void Equals_SameAmount_AreEqual()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5 )));
        }

        [Fact]
        public void Equals_DifferentAmount_AreNotEqual()
        {
            Assert.False(new Dollar(5).Equals(new Dollar(6)));
        }
    }
}