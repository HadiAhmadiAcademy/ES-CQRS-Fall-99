using System;
using Framework.Domain;

namespace LoanApplications.Domain.Contracts
{
    public class LoanRequested : DomainEvent
    {
        public Guid LoanApplicationId { get; private set; }
        public int ApplicantId { get; private set; }
        public int PaybackMonths { get; private set; }
        public int Amount { get; private set; }
        public string Description { get; private set; }
        public LoanRequested(Guid loanApplicationId, int applicantId, int paybackMonths, 
            int amount, string description)
        {
            LoanApplicationId = loanApplicationId;
            ApplicantId = applicantId;
            PaybackMonths = paybackMonths;
            Amount = amount;
            Description = description;
        }
    }
}
