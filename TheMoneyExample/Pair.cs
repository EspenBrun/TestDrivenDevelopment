using System;

namespace TheMoneyExample
{
    public class Pair
    {
        private string From { get; }
        private string To { get; }

        public Pair(string from, string to)
        {
            From = from;
            To = to;
        }

        public override bool Equals(object obj)
        {

            Pair other;

            try
            {
                other = (Pair) obj;
            }
            catch (Exception)
            {
                return false;
            }

            return From.Equals(other.From) && To.Equals(other.To);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}