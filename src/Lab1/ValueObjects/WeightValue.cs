namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class WeightValue
{
    public sealed record Weight
    {
        public Weight(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Weight weight)
        {
            return weight.Value;
        }

        public double Value { get; }
    }
}