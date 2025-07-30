namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class StopTimeValue
{
    public sealed record StopTime
    {
        public StopTime(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("StopTime can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(StopTime stopTime)
        {
            return stopTime.Value;
        }

        public double Value { get; }
    }
}