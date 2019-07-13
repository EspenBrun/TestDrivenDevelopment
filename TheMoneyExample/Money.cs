using System;

namespace TheMoneyExample
{
    public class Money
    {
        private readonly int _amount;
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
            return _amount == other._amount && _currency == other._currency;
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, _currency);
        }

        public string Currency()
        {
            return _currency;
        }

        public override string ToString()
        {
            return $"{_amount} {_currency}";
        }
    }
}