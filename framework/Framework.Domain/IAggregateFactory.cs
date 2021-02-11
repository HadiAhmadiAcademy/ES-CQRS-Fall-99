using System.Collections.Generic;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public interface IAggregateFactory
    {
        T Create<T>(List<DomainEvent> events, ISnapshot snapshot) where T : IAggregateRoot;
    }
}