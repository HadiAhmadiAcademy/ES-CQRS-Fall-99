using Framework.Domain;

namespace Framework.Persistence.ES
{
    public static class ExpectedVersionCalculator
    {
        public static int GetExpectedVersionOfAggregate(IAggregateRoot aggregateRoot)
        {
            var version = aggregateRoot.Version - aggregateRoot.GetUncommittedEvents().Count;
            return version - 1;     //because index of event store starts from zero
        }
    }
}