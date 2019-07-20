namespace TheMoneyExample
{
    public class Sum : Expression
    {
        private readonly Money Augend;
        private readonly Money Addend;

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string to)
        {
            return new Money(Augend.Amount + Addend.Amount, to);
        }
    }
}