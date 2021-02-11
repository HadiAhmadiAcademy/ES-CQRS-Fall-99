using System;
using Framework.Application;

namespace LoanApplications.Application.Contracts
{
    public class AcceptApplicationCommand : ICommand
    {
        public Guid LoanApplicationId { get; set; }
    }
}