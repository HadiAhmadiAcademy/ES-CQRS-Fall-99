using System;
using Framework.Application;

namespace LoanApplications.Application.Contracts
{
    public class RejectApplicationCommand : ICommand
    {
        public Guid LoanApplicationId { get; set; }
        public string Reason { get; set; }
    }
}