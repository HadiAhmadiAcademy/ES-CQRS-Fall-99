using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public class AggregateFactory : IAggregateFactory
    {
        public T Create<T>(List<DomainEvent> events, ISnapshot snapshot) where T : IAggregateRoot
        {
            var aggregate = (T)Activator.CreateInstance(typeof(T),true);

            //TODO: apply snapshot

            foreach (var domainEvent in events)
            {
                aggregate.Apply(domainEvent);
            }
            return aggregate;
        }
    }
}