namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class TimeValue
{
    public sealed record Time
    {
        public Time(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Time can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Time time)
        {
            return time.Value;
        }

        public double Value { get; }
    }
}