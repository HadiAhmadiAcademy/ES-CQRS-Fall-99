using System;
using Framework.Core;
using Framework.Core.Events;

namespace Framework.Domain
{
    public abstract class DomainEvent : IEvent
    {
        public Guid EventId { get; private set; }
        public DateTime PublishDateTime { get; private set; }
        protected DomainEvent()
        {
            this.PublishDateTime = DateTime.Now;
            this.EventId  = Guid.NewGuid();    
        }
    }
}
