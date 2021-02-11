using System;

namespace Framework.Persistence.ES.Mappings.Operation
{
    public class EventMappingException : Exception
    {
        public EventMappingException(string message) : base(message)
        {
        }
    }
}