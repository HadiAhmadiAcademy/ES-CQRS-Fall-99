using System.Threading.Tasks;

namespace Framework.Domain.Snapshots
{
    public interface IInMemorySnapshotStore  : ISnapshotStore
    {
        Task AddOrUpdateSnapshot<T, TKey>(TKey id, ISnapshot snapshot) where T : AggregateRoot<TKey>;
    }
}