namespace Framework.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }

        //TODO: implement equality & hashcode
    }
}