namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class SpeedValue
{
    public sealed record Speed
    {
        public Speed(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Speed can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Speed speed)
        {
            return speed.Value;
        }

        public double Value { get; }
    }
}