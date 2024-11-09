namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public class ValueObjectId
{
    public sealed record Id : IEquatable<Id>
    {
        public Id(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Id can`t be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(Id id)
        {
            return id.Value;
        }

        public double Value { get; }
    }
}