using System;

namespace TheMoneyExample
{
    public abstract class Money
    {
        protected readonly int _amount;
        private readonly string _currency;

        protected Money(int amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
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
            return _amount == other._amount && obj.GetType() == GetType();
        }

        public abstract Money Times(int i);

        public string Currency()
        {
            return _currency;
        }
    }
}