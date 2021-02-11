using System.Threading.Tasks;

namespace Framework.Domain.Snapshots
{
    public interface ISnapshotStore
    {
        Task<ISnapshot> GetLatestSnapshotOf<T, TKey>(TKey id) where T : AggregateRoot<TKey>;
    }
}