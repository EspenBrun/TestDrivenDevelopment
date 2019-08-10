using TheMoneyExampleTests;

namespace TheMoneyExample
{
    public class Sum : Expression
    {
        private readonly Expression Augend;
        private readonly Expression Addend;

        public Sum(Expression augend, Expression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            var augendAmount = Augend.Reduce(bank, to).Amount;
            var addendAmount = Addend.Reduce(bank, to).Amount;
            return new Money(augendAmount + addendAmount, to);
        }

        public Expression Plus(Expression tenFranc)
        {
            throw new System.NotImplementedException();
        }
    }
}