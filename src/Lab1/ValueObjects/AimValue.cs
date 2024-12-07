namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class AimValue
{
    public sealed record Aim
    {
        public Aim(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Aim can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Aim aim)
        {
            return aim.Value;
        }

        public double Value { get; }
    }
}