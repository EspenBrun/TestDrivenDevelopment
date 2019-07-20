using TheMoneyExample;
using Xunit;

namespace TheMoneyExampleTests
{
    public class DollarTests
    {
        [Fact]
        public void EqualsTests()
        {
            Assert.Equal(Money.Dollar(5), Money.Dollar(5));
            Assert.NotEqual(Money.Dollar(5), Money.Dollar(6));
            Assert.NotEqual(Money.Dollar(5), Money.Franc(5));
        }

        [Fact]
        public void Multiplication()
        {

            Assert.Equal(Money.Dollar(15), Money.Dollar(5).Times(3));
        }

        [Fact]
        public void Currencies()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency());
            Assert.Equal("CHF", Money.Franc(1).Currency());
        }
    }
}