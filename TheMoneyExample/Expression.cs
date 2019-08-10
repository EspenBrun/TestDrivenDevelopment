using TheMoneyExampleTests;

namespace TheMoneyExample
{
    public interface Expression
    {
        Money Reduce(Bank bank, string to);
        Expression Plus(Expression tenFranc);
    }
}