using System;
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
            var bank = new Bank();

            var sum = Money.Dollar(5).Plus(Money.Dollar(5));
            Assert.Equal(Money.Dollar(10), bank.Reduce(sum, "USD"));
        }

        [Fact]
        public void ReduceToSameCurrency()
        {
            var bank = new Bank();

            Assert.Equal(Money.Dollar(5), bank.Reduce(Money.Dollar(5), "USD"));
            Assert.Equal(Money.Franc(5), bank.Reduce(Money.Franc(5), "CHF"));
        }

        [Fact]
        public void ReduceToOtherCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Assert.Equal(Money.Dollar(1), bank.Reduce(Money.Franc(2), "USD"));
        }

        [Fact]
        public void BankRateSameCurrency()
        {
            var bank = new Bank();
            Assert.Equal(1, bank.Rate("USD", "USD"));
        }

        [Fact]
        public void BankRate()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var rate = bank.Rate("CHF", "USD");
            Assert.Equal(2, rate);
        }

        [Fact]
        public void TestMixedAddition()
        {
            var fiveDollar = Money.Dollar(5);
            var tenFranc = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            var mixedSum = fiveDollar.Plus(tenFranc);
            var result = bank.Reduce(mixedSum, "USD");

            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            var fiveDollars = new Money(5, "USD");
            var twentyFranc = new Money(20, "CHF");
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            var sum = new Sum(fiveDollars, twentyFranc).Plus(fiveDollars);
            var result = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(20), result);
        }

        [Fact]
        public void TestSumTimes()
        {
            var fiveDollars = new Money(5, "USD");
            var tenFranc = new Money(10, "CHF");
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Expression sum = new Sum(fiveDollars, tenFranc).Times(2);
            var result = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(20), result);
        }
    }
}