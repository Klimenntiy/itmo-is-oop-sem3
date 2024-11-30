using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

public class FilterAddress : IAddress
{
    private static readonly List<IMessageFilter> Filters = new List<IMessageFilter>();
    private readonly IAddress _address;
    private readonly int _importanceThreshold;

    public FilterAddress(IAddress address, int importance)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address cannot be null.");
        _importanceThreshold = importance;
    }

    public static void AddFilter(IMessageFilter filter)
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
        Filters.Add(filter);
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (Filters.Count > 0)
        {
            foreach (IMessageFilter filter in Filters)
            {
                FinalResult result = filter.Filter(message, _address, _importanceThreshold);
                if (result is not FinalResult.Success)
                {
                    return result;
                }
            }

            return new FinalResult.Success();
        }

        return new FinalResult.NoFilters();
    }
}