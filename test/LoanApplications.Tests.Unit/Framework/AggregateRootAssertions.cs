using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Framework.Domain;

namespace LoanApplications.Tests.Unit.Framework
{
    public static class AggregateRootAssertions
    {
        public static void ShouldBeHaveEquivalentOfDomainEvent<T>(this IReadOnlyList<T> target, 
            T expectedDomainEvent)

            where T : DomainEvent
        {
            target.Should().ContainEquivalentOf(expectedDomainEvent,
                options =>
                    options.IncludingAllRuntimeProperties()
                        .Excluding(a => a.EventId)
                        .Excluding(a => a.PublishDateTime));
        }
    }
}
