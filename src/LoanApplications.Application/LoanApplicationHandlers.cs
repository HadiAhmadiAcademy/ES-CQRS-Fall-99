using System.Threading.Tasks;
using Framework.Application;
using LoanApplications.Application.Contracts;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Application
{
    public class LoanApplicationHandlers : ICommandHandler<PlaceLoanApplicationCommand>,
                                           ICommandHandler<AcceptApplicationCommand>,
                                           ICommandHandler<RejectApplicationCommand>
    {
        private readonly ILoanApplicationRepository _repository;
        public LoanApplicationHandlers(ILoanApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(PlaceLoanApplicationCommand cmd)
        {
            var loanApplication = new LoanApplication(cmd.ApplicantId, cmd.PaybackMonths, cmd.Amount, cmd.Description);
            await _repository.Add(loanApplication);
        }

        public async Task Handle(AcceptApplicationCommand command)
        {
            var loanApplication = await _repository.Get(new LoanApplicationId(command.LoanApplicationId));
            loanApplication.Accept();
            await _repository.Update(loanApplication);
        }

        public async Task Handle(RejectApplicationCommand command)
        {
            var loanApplication = await _repository.Get(new LoanApplicationId(command.LoanApplicationId));
            loanApplication.Reject(command.Reason);
            await _repository.Update(loanApplication);
        }
    }
}