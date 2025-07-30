namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public class ValueObjectId
{
    public record Id : IEquatable<Id>
    {
        public Id(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Id can't be negative", nameof(value));
            }

            Value = value;
        }

        public double Value { get; }
    }
}