using System;
using Framework.Domain;
using Framework.Domain.Snapshots;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public partial class LoanApplication
    {
        //private LoanApplication(LoanApplicationSnapshot snapshot)
        //{
        //    this._amount = snapshot.Amount;
        //    //..............
        //}
        //public void Restore(LoanApplicationSnapshot snapshot) { }
        public LoanApplicationSnapshot GetSnapshot()
        {
            return new LoanApplicationSnapshot()
            {
                Version = this.Version,
                PaybackMonths = this._paybackMonths,
                Description = this._description,
                Amount = this._amount,
                ApplicantId = this._applicantId
            };
        }
        public override void Apply(ISnapshot snapshot)
        {
            Apply((dynamic)snapshot);
        }
        public void Apply(LoanApplicationSnapshot snapshot)     //TODO: you can use constructor for snapshots
        {
            this._amount = snapshot.Amount;
            //...
        }
    }
}