using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit.Framework
{
    public abstract class Specification<T> where T : IAggregateRoot
    {
        protected T sut;

        [Fact]
        public void Test()
        {
            sut = Given();
            sut.ClearUncommittedEvents();
            When();
            Then();
        }

        protected abstract T Given();
        protected abstract void When();
        protected abstract void Then();
    }
}
