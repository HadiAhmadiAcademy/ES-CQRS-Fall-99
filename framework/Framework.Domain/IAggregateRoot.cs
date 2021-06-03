using System.Collections.Generic;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        int Version { get; }
        IReadOnlyList<DomainEvent> GetUncommittedEvents();
        void ClearUncommittedEvents();
        void Apply(DomainEvent @event);
        void Apply(ISnapshot snapshot);
    }
}