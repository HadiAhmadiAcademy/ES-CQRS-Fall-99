using System;
using System.Threading.Tasks;
using Framework.Domain;
using Framework.Domain.Snapshots;

namespace Framework.Persistence.Sql
{
    public class SqlSnapshotStore : ISnapshotStore
    {
        public Task<ISnapshot> GetLatestSnapshotOf<T, TKey>(TKey id) where T : AggregateRoot<TKey>
        {
            //var streamId = "........";
            //.... Excute query return

            return Task.FromResult<ISnapshot>(EmptySnapshot.Instance);
        }

        public Task<TSnapshot> GetLatestSnapshotOf<T, TKey, TSnapshot>(TKey id) where T : AggregateRoot<TKey> where TSnapshot : ISnapshot
        {
            throw new NotImplementedException();
        }
    }
}
