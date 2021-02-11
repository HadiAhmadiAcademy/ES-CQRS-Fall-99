using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Framework.Application;
using Framework.Domain;
using Framework.Domain.Snapshots;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace LoanApplications.Tests.Unit.Framework
{
    public abstract class Specification<TAggregate, TCommand>
        where TCommand : ICommand
        where TAggregate : IAggregateRoot
    {
        private readonly ITestOutputHelper _testOutput;
        private IAggregateFactory _aggregateFactory;
        protected TAggregate Sut;
        protected Specification(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _aggregateFactory = new AggregateFactory();
        }

        [Fact]
        public void Test()
        {
            _testOutput.WriteLine($"Scenario : {this.GetType().Name.Replace("_", " ")}");

            var givenEvents = Given().ToList();

            _testOutput.WriteLine($"Given : ");
            foreach (var @event in givenEvents)
                _testOutput.WriteLine($"\t{@event.GetType().Name} - {JsonConvert.SerializeObject(@event)}");

            Sut = _aggregateFactory.Create<TAggregate>(givenEvents, EmptySnapshot.Instance);

            var handler = CreateHandler();
            var command = When();
            _testOutput.WriteLine($"When : ");
            _testOutput.WriteLine($"\t{command.GetType().Name} - {JsonConvert.SerializeObject(command)}");
            //_testOutput.WriteLine($"\t{command.GetType().Name} - {command}");
            handler.Handle(command);

            var expectedEvents = Then().ToList();
            _testOutput.WriteLine($"Then : ");
            foreach (var @event in givenEvents)
                _testOutput.WriteLine($"\t{expectedEvents.GetType().Name} - {JsonConvert.SerializeObject(expectedEvents)}");

            var actualEvents = Sut.GetUncommittedEvents();
            actualEvents.Should().HaveCount(expectedEvents.Count);

            //expectedEvents.ForEach(a=> actualEvents.ShouldBeHaveEquivalentOfDomainEvent(a));      //TODO: check this out
        }

        protected abstract IEnumerable<DomainEvent> Given();
        protected abstract TCommand When();
        protected abstract IEnumerable<DomainEvent> Then();
        protected abstract ICommandHandler<TCommand> CreateHandler();
    }
}
