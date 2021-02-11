using System;
using Framework.Domain;

namespace LoanApplications.Domain.Contracts
{
    public class LoanApplicationAccepted : DomainEvent
    {
        public Guid ApplicationId { get; private set; }
        public LoanApplicationAccepted(Guid applicationId)
        {
            ApplicationId = applicationId;
        }
    }
}