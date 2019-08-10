using System;
using TheMoneyExampleTests;

namespace TheMoneyExample
{
    public class Money : Expression
    {
        public string Currency { get; }
        public int Amount { get; }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount/rate, to);
        }

        public Expression Plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public Expression Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
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
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
