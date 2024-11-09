namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public class ValueObjectSemestr
{
    public sealed record Semestr
    {
        public Semestr(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Id can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Semestr semestr)
        {
            return semestr.Value;
        }

        public double Value { get; }
    }
}