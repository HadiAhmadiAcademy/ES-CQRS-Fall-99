namespace Framework.Domain.Snapshots
{
    public interface ISnapshot
    {
        int Version { get; }
    }
}