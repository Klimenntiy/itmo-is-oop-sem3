namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class PowerOnValue
{
    public sealed record PowerOn
    {
        public PowerOn(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("PowerOn can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(PowerOn powerOn)
        {
            return powerOn.Value;
        }

        public double Value { get; }
    }
}