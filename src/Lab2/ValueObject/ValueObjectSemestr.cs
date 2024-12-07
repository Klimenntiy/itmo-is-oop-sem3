namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public class ValueObjectSemestr
{
    public record Semestr
    {
        public Semestr(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Id can`t be negative", nameof(value));
            }

            Value = value;
        }

        public double Value { get; }
    }
}