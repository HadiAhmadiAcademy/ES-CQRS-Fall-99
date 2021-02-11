using System;

namespace LoanManagement.Projections.Sql.Handlers.Model
{
    public class LoanApplication
    {
        public Guid Id { get; set; }
        public int ApplicantId { get; set; }
        public int PaybackMonths { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public LoanApplicationState State { get; set; }
    }
    public enum LoanApplicationState
    {
        InProgress,
        Accepted,
        Rejected
    }
}