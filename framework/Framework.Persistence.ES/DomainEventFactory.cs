using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Framework.Domain;
using Framework.Persistence.ES.Mappings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES
{
    internal static class DomainEventFactory
    {
        public static List<DomainEvent> Create(List<ResolvedEvent> events, IEventTypeResolver typeResolver)
        {
            return events.Select(a=> Create(a, typeResolver)).ToList();
        }

        public static DomainEvent Create(ResolvedEvent @event, IEventTypeResolver typeResolver)
        {
            var type = typeResolver.GetType(@event.Event.EventType);
            var body = Encoding.UTF8.GetString(@event.Event.Data);
            body = ApplyMappings(body, type);
            return (DomainEvent)JsonConvert.DeserializeObject(body, type);
        }

        private static string ApplyMappings(string body, Type type)
        {
            var filter = SchemaMappingRegistration.GetFilterForType(type);
            if (filter == null) return body;
            var json = JObject.Parse(body);
            json = filter.Apply(json);
            return json.ToString();
        }
    }
}