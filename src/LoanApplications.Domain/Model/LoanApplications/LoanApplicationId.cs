using System;
using Framework.Domain;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public class LoanApplicationId : Id<Guid>
    {
        public LoanApplicationId(Guid value) : base(value)
        {
        }
    }
}