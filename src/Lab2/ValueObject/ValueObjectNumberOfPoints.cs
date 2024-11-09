namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public class ValueObjectNumberOfPoints
{
    public sealed record NumberOfPoints
    {
        public NumberOfPoints(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Number Of Points can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(NumberOfPoints numberOfPoints)
        {
            return numberOfPoints.Value;
        }

        public double Value { get; }
    }
}