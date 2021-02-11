using Framework.Application;

namespace LoanApplications.Application.Contracts
{
    public class PlaceLoanApplicationCommand : ICommand
    {
        public int ApplicantId { get;  set; }
        public int PaybackMonths { get;  set; }
        public int Amount { get;  set; }
        public string Description { get; set; }
    }
}
