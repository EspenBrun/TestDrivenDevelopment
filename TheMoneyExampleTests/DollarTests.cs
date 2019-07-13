using TheMoneyExample;
using Xunit;

namespace TheMoneyExampleTests
{
    public class DollarTests
    {
        [Fact]
        public void Multiplication()
        {
            var five = Money.Dollar(5);

            var fifteen = five.Times(3);

            Assert.Equal(Money.Dollar(5), five);
            Assert.Equal(Money.Dollar(15), fifteen);
        }

        [Fact]
        public void Multiplication_Franc()
        {
            var five = Money.Franc(5);

            var fifteen = five.Times(3);

            Assert.Equal(Money.Franc(5), five);
            Assert.Equal(Money.Franc(15), fifteen);
        }

        [Fact]
        public void Equals_SameAmount_AreEqual()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5 )));
        }

        [Fact]
        public void Equals_DifferentAmount_AreNotEqual()
        {
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
        }

        [Fact]
        public void Equals_DollarAndFranc_NotEqual()
        {
            Assert.False(Money.Dollar(5).Equals(Money.Franc(5)));
        }

        [Fact]
        public void Currencies()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency());
            Assert.Equal("CHF", Money.Franc(1).Currency());
        }
    }
}