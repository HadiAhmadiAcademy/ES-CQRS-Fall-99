using System.Collections.Generic;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public class EventStoreDb : IEventStore
    {
        private readonly IEventStoreConnection _connection;
        private readonly IEventTypeResolver _typeResolver;
        public EventStoreDb(IEventStoreConnection connection, IEventTypeResolver typeResolver)
        {
            _connection = connection;
            _typeResolver = typeResolver;
        }
        public async Task<List<DomainEvent>> GetEventsOfStream<T, TKey>(TKey id) where T : AggregateRoot<TKey>
        {
            return await GetEventsOfStream<T, TKey>(id, StreamPosition.Start);

        }
        public async Task<List<DomainEvent>> GetEventsOfStream<T, TKey>(TKey id, int fromIndex) where T : AggregateRoot<TKey>
        {
            var streamId = StreamNames.GetStreamName<T, TKey>(id);
            var streamEvents = await EventStreamReader.Read(_connection, streamId, fromIndex, 200); //TODO:remove this hard-coded '200' and real all events
            return DomainEventFactory.Create(streamEvents, _typeResolver);
        }

        public async Task AppendEvents<T, TKey>(T aggregateRoot) where T : AggregateRoot<TKey>
        {
            var events = aggregateRoot.GetUncommittedEvents();
            var streamId = StreamNames.GetStreamName<T, TKey>(aggregateRoot.Id);
            var expectedVersion = ExpectedVersionCalculator.GetExpectedVersionOfAggregate(aggregateRoot);
            var eventData = EventDataFactory.CreateFromDomainEvents(events);
            await _connection.AppendToStreamAsync(streamId, expectedVersion, eventData);
        }
    }
}