using System;

namespace TheMoneyExample
{
    public abstract class Money
    {
        protected int Amount;

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
    }
}