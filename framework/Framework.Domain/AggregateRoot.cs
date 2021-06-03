using System.Collections.Generic;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot
    {
        private List<DomainEvent> _uncommittedEvents;
        protected AggregateRoot()
        {
            this._uncommittedEvents = new List<DomainEvent>();    
        }
        public int Version { get; protected set; }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();
        public void ClearUncommittedEvents()
        {
            this._uncommittedEvents.Clear();
        }

        public void Causes(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
            Apply(@event);
        }
        public virtual void Apply(DomainEvent @event)
        {
            Version++;
        }
        public virtual void Apply(ISnapshot snapshot) { }
    }
}