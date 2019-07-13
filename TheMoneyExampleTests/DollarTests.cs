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

            var fifteen = five.Times(3);

            Assert.Equal(new Dollar(5), five);
            Assert.Equal(new Dollar(15), fifteen);
        }

        [Fact]
        public void Multiplication_Franc()
        {
            var five = new Franc(5);

            var fifteen = five.Times(3);

            Assert.Equal(new Franc(5), five);
            Assert.Equal(new Franc(15), fifteen);
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