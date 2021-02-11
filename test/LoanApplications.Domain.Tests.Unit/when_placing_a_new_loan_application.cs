using System;
using System.Linq;
using FluentAssertions;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Domain.Model.LoanApplications.States;
using LoanApplications.Domain.Tests.Unit.Framework;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class when_placing_a_new_loan_application
    {
        [Fact]
        public void loan_gets_requested()
        {
            var loanApplication = new LoanApplication(1, 20, 2000, "for buying a new laptop");

            var expectedEvent = new LoanRequested(loanApplication.Id.Value, 1, 20, 2000, "for buying a new laptop");
            loanApplication.ShouldOnlyContainDomainEvent(expectedEvent);
        }
    }
}
