using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Framework.Domain;
using Newtonsoft.Json;

namespace Framework.Persistence.ES
{
    internal static class EventDataFactory
    {
        public static EventData CreateFromDomainEvent(DomainEvent domainEvent)
        {
            var data = JsonConvert.SerializeObject(domainEvent);
            return new EventData(
                eventId: domainEvent.EventId,
                type: domainEvent.GetType().Name,
                isJson: true,
                data: Encoding.UTF8.GetBytes(data),
                metadata: new byte[] {}
            );
        }

        public static List<EventData> CreateFromDomainEvents(IEnumerable<DomainEvent> domainEvent)
        {
            return domainEvent.Select(CreateFromDomainEvent).ToList();
        }
    }
}
