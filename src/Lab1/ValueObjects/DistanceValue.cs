namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class DistanceValue
{
    public sealed record Distance
    {
        public Distance(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Distance can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Distance distance)
        {
            return distance.Value;
        }

        public double Value { get; }
    }
}