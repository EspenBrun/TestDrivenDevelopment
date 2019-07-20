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
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void SimpleAddition()
        {
            var sum = Money.Dollar(5).Plus(Money.Dollar(5));
            Assert.Equal(Money.Dollar(10), Bank.Reduce(sum, "USD"));
        }

        [Fact]
        public void ReduceToSameCurrency()
        {
            Assert.Equal(Money.Dollar(5), Bank.Reduce(Money.Dollar(5), "USD"));
            Assert.Equal(Money.Franc(5), Bank.Reduce(Money.Franc(5), "CHF"));
        }
    }
}