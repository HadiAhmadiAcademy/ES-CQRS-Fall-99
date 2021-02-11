using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Snapshots;

namespace Framework.Domain
{
    public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        private readonly IEventStore _eventStore;
        private readonly IAggregateFactory _aggregateFactory;
        private readonly ISnapshotStore _snapshotStore;
        public EventSourceRepository(IEventStore eventStore, IAggregateFactory aggregateFactory, ISnapshotStore snapshotStore)
        {
            _eventStore = eventStore;
            _aggregateFactory = aggregateFactory;
            _snapshotStore = snapshotStore;
        }
        public async Task<T> GetById(TKey id)
        {
            var snapshot = await _snapshotStore.GetLatestSnapshotOf<T, TKey>(id);
            var listOfEvents = await _eventStore.GetEventsOfStream<T,TKey>(id, snapshot.Version);
            return _aggregateFactory.Create<T>(listOfEvents, snapshot);
        }

        public async Task AppendEvents(T aggregate)
        {
            await _eventStore.AppendEvents<T,TKey>(aggregate);
            //TODO: clear uncommitted events after append
            //TODO: if (snapshot store == InMemory) then  1.GetSnapshotFromAggregate  2.AddOrUpdateSnapshot(aggregate)
        }
    }
}