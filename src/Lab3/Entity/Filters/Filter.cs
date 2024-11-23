using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

public class Filter : IAddress
{
    private static List<IMessageFilter>? _filters;
    private readonly IAddress _address;
    private readonly int _requiredImportance;

    public Filter(IAddress address, int importance)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address cant be null.");
        _requiredImportance = importance;
        _filters = [];
    }

    public static void AddFilter(IMessageFilter filter)
    {
        _filters?.Add(filter);
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (_filters != null)
        {
            foreach (IMessageFilter filter in _filters)
            {
                FinalResult currentResult = filter.Filter(message, _address, _requiredImportance);
                if (currentResult != new FinalResult.Success())
                {
                    return currentResult;
                }
            }

            return new FinalResult.Success();
        }

        return new FinalResult.NoFilters();
    }
}