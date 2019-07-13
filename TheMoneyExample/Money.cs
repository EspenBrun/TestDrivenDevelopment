using System;

namespace TheMoneyExample
{
    public abstract class Money
    {
        protected int Amount;

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }

        public override bool Equals(object obj)
        {
            Money other;

            try
            {
                other = (Money) obj;
            }
            catch (Exception)
            {
                return false;
            }
            return Amount == other.Amount && obj.GetType() == GetType();
        }

        public abstract Money Times(int i);
    }
}