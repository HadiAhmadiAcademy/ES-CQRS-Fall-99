using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class Id<T> : ValueObject
    {
        public T Value { get; private set; }
        protected Id(T value)
        {
            Value = value;
        }
        protected bool Equals(Id<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Id<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }
    }
}