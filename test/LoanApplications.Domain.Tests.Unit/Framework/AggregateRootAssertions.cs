using System.Linq;
using FluentAssertions;
using Framework.Core.Events;
using Framework.Domain;

namespace LoanApplications.Domain.Tests.Unit.Framework
{
    public static class AggregateRootAssertions
    {
        public static void ShouldOnlyContainDomainEvent<T>(this IAggregateRoot aggregateRoot, T domainEvent) 
                            where T : DomainEvent
        {
            var uncommittedEvents = aggregateRoot.GetUncommittedEvents();
            uncommittedEvents.Should().HaveCount(1);
            var targetEvent = uncommittedEvents.First();
            targetEvent.Should().BeEquivalentTo(domainEvent, 
                options => 
                            options.Excluding(a=> a.EventId)
                                   .Excluding(a=> a.PublishDateTime));
        }
    }
}