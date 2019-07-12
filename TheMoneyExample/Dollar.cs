namespace TheMoneyExample
{
    public class Dollar
    {
        public readonly int Amount;

        public Dollar(int amount)
        {
            Amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(Amount * multiplier);
        }

        public bool Equals(Dollar other)
        {
            return Amount == other.Amount;
        }
    }
}