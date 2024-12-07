namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class StopSpeedValue
{
    public sealed record StopSpeed
    {
        public StopSpeed(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("StopSpeed can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(StopSpeed stopSpeed)
        {
            return stopSpeed.Value;
        }

        public double Value { get; }
    }
}