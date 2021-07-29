namespace LoanApplications.Domain.Model.LoanApplications.States
{
    internal class InProgress : LoanApplicationState
    {
        public override bool CanReject() => true;
        public override bool CanAccept() => true;
    }
}