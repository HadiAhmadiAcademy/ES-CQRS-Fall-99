using System;
using Framework.Domain;
using Framework.Domain.Exceptions;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public partial class LoanApplication : AggregateRoot<LoanApplicationId>
    {
        private int _applicantId;
        private int _paybackMonths;
        private int _amount;
        private string _description;
        private string _rejectionReason;
        private LoanApplicationState _state;
        protected LoanApplication()  { }
        public LoanApplication(int applicantId, int payBackMonths, int amount, string description)
        {
            var id = Guid.NewGuid();
            Causes(new LoanRequested(id, applicantId, payBackMonths, amount, description));
        }
        public void Reject(string reason)
        {
            if (_state.CanReject())
                Causes(new LoanApplicationRejected(this.Id.Value, reason));
            else
                throw new InvalidStateException(_state, nameof(Reject));
        }
        public void Accept()
        {
            if (_state.CanAccept())
                Causes(new LoanApplicationAccepted(this.Id.Value));
            else
                throw new InvalidStateException(_state, nameof(Accept));
        }
    }
}