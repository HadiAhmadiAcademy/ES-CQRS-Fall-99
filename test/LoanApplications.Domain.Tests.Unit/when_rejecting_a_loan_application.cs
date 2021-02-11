using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Domain.Tests.Unit.Framework;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class when_rejecting_a_loan_application
    {
        [Fact]
        public void loan_application_gets_rejected()
        {
            var loanApplication = new LoanApplication(1, 20, 2000, "for buying a new laptop");
            loanApplication.ClearUncommittedEvents();

            loanApplication.Reject("because i said so");

            var @event = new LoanApplicationRejected(loanApplication.Id.Value, "because i said so");
            loanApplication.ShouldOnlyContainDomainEvent(@event);
        }
    }
}