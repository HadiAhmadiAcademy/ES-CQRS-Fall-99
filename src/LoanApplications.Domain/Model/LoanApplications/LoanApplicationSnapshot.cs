using Framework.Domain.Snapshots;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public class LoanApplicationSnapshot : ISnapshot
    {
        public int ApplicantId { get;  set; }
        public int PaybackMonths { get;  set; }
        public int Amount { get;  set; }
        public string Description { get;  set; }
        public int Version { get;  set; }
        //public LoanApplicationState State { get; set; }     //TODO: this is just a test
    }
}