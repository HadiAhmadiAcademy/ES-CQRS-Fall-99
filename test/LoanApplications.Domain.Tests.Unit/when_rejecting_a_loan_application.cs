using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Domain.Tests.Unit.Framework;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class when_rejecting_a_loan_application : Specification<LoanApplication>
    {
        protected override LoanApplication Given()
        {
            return new LoanApplication(1, 20, 2000, "for buying a new laptop");
        }

        protected override void When()
        {
            sut.Reject("because i said so");
        }
        protected override void Then()
        {
            var @event = new LoanApplicationRejected(sut.Id.Value, "because i said so");
            sut.ShouldOnlyContainDomainEvent(@event);
        }
    }

    // Scenario : rejecting a loan application
    // Given
        //  Loan Requested with data ....
    //  When
        //  Reject
    //  Then
        //LoanApplicationRejected
}