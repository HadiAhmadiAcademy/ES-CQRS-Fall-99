using System;

namespace Framework.Domain.Exceptions
{
    public class InvalidStateException : Exception
    {
        public string Operation { get; private set; }
        public string State { get; private set; }
        public InvalidStateException(string state, string operation)
            : base($"Cannot '{operation}' in '{state}' State")
        {
            
        }

        public InvalidStateException(object state, string operation) : this(state.GetType().Name, operation)
        {

        }
    }
}