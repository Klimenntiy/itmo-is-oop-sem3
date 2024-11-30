using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

// Код добавляет новую функциональность (фильтрацию) к объекту (адресу), не изменяя при этом его интерфейс. Поэтому, да, декоратор тут есть и работает корректно.
public class FilterAddress : IAddress
{
    private readonly List<IMessageFilter> _filters = new List<IMessageFilter>();

    public IEnumerable<IMessageFilter> UserMessages => _filters;

    private readonly IAddress _address;
    private readonly int _importanceThreshold;

    public FilterAddress(IAddress address, int importance)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address cannot be null.");
        _importanceThreshold = importance;
    }

    public void AddFilter(IMessageFilter filter)
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
        _filters.Add(filter);
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (_filters.Count != 0)
        {
            foreach (IMessageFilter filter in _filters)
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