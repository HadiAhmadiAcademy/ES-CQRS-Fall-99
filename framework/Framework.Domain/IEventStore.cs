using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IEventStore
    {
        Task<List<DomainEvent>> GetEventsOfStream<T, TKey>(TKey id) where T : AggregateRoot<TKey>;
        Task<List<DomainEvent>> GetEventsOfStream<T, TKey>(TKey id, int fromIndex) where T : AggregateRoot<TKey>;
        Task AppendEvents<T,TKey>(T aggregateRoot) where T : AggregateRoot<TKey>;
    }
}