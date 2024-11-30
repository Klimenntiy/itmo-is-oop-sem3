using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

public class FilterDecorator : IMessageFilter
{
    private readonly IMessageFilter _innerFilter;

    public FilterDecorator(IMessageFilter innerFilter)
    {
        _innerFilter = innerFilter ?? throw new ArgumentNullException(nameof(innerFilter));
    }

    public FinalResult Filter(IMessage message, IAddress address, int importance)
    {
        FinalResult result = _innerFilter.Filter(message, address, importance);

        return result;
    }
}