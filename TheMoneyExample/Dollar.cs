using System;

namespace TheMoneyExample
{
    public class Dollar
    {
        private readonly int Amount;

        public Dollar(int amount)
        {
            Amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(Amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            Dollar other;
            try
            {
                other = (Dollar) obj;
            }
            catch (Exception)
            {
                return false;
            }
            return Amount == other.Amount;
        }
    }
}