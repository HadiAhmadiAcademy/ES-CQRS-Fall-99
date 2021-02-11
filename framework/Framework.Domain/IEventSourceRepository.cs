using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        Task<T> GetById(TKey id);
        Task AppendEvents(T aggregate);
    }
}