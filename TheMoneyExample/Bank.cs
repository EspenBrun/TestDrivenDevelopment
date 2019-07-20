using TheMoneyExample;

namespace TheMoneyExampleTests
{
    public static class Bank
    {
        public static Expression Reduce(Expression expression, string to)
        {
            return expression.Reduce(to);
        }
    }
}