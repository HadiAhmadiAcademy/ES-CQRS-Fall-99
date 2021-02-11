using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Framework.Application;
using Framework.Domain;
using LoanApplications.Application;
using LoanApplications.Application.Contracts;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Tests.Unit.Framework;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace LoanApplications.Tests.Unit
{
    public class when_rejecting_a_loan_application : Specification<LoanApplication, RejectApplicationCommand>
    {

        public when_rejecting_a_loan_application(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        protected override IEnumerable<DomainEvent> Given()
        {
            yield return new LoanRequested(
                Guid.Parse("0CFAEB42-2A8E-40B6-AD43-907F45DCBD89"), 1, 10, 2000, "for buying a laptop");
        }

        protected override RejectApplicationCommand When()
        {
            return new RejectApplicationCommand()
            {
                Reason = "i said so",
                LoanApplicationId = Guid.Parse("0CFAEB42-2A8E-40B6-AD43-907F45DCBD89"),
            };
        }

        protected override IEnumerable<DomainEvent> Then()
        {
            yield return new LoanApplicationRejected(Guid.Parse("0CFAEB42-2A8E-40B6-AD43-907F45DCBD89"), "i said so");
        }

        protected override ICommandHandler<RejectApplicationCommand> CreateHandler()
        {
            var repository = Substitute.For<ILoanApplicationRepository>();
            repository
                .Get(new LoanApplicationId(Guid.Parse("0CFAEB42-2A8E-40B6-AD43-907F45DCBD89")))
                .Returns(Sut);
            return new LoanApplicationHandlers(repository);
        }

    }
}
