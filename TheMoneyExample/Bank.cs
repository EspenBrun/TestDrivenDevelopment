using System.Collections;
using System.Threading.Tasks;
using TheMoneyExample;

namespace TheMoneyExampleTests
{
    public class Bank
    {
        private Hashtable rates = new Hashtable();
        public Expression Reduce(Expression expression, string to)
        {
            return expression.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;

            return (int) rates[new Pair(from, to)];
        }
    }
}