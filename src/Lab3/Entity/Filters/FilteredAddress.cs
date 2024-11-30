using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

public class FilteredAddress : IAddress
{
    private readonly IAddress _decoratedAddress;
    private readonly List<IMessageFilter> _filters;

    public FilteredAddress(IAddress address)
    {
        _decoratedAddress = address ?? throw new ArgumentNullException(nameof(address), "Address cannot be null.");
        _filters = new List<IMessageFilter>();
    }

    public void AddFilter(IMessageFilter filter)
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
        _filters.Add(filter);
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        foreach (IMessageFilter filter in _filters)
        {
            FinalResult result = filter.Filter(message, _decoratedAddress, message.Priority);
            if (result is not FinalResult.Success)
            {
                return result;
            }
        }

        return _decoratedAddress.AcceptMessage(message);
    }
}
