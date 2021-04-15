using System;
using Framework.Domain;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public partial class LoanApplication
    {
        public override void Apply(DomainEvent @event)
        {
            base.Apply(@event);
            When((dynamic)@event);
        }
        private void When(LoanRequested @event)
        {
            this.Id = new LoanApplicationId(@event.LoanApplicationId);
            this._applicantId = @event.ApplicantId;
            this._amount = @event.Amount;
            this._paybackMonths = @event.PaybackMonths;
            this._description = @event.Description;
            this._state = new InProgress();
        }

        private void When(LoanApplicationRejected @event)
        {
            this._state = new Rejected();
            this._rejectionReason = @event.Reason;
        }
    }
}