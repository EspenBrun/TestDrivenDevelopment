using System;

namespace TheMoneyExample
{
    public class Franc
    {
        private readonly int Amount;

        public Franc(int amount)
        {
            Amount = amount;
        }

        public Franc Times(int multiplier)
        {
            return new Franc(Amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            Franc other;
            try
            {
                other = (Franc) obj;
            }
            catch (Exception)
            {
                return false;
            }
            return Amount == other.Amount;
        }
    }
}