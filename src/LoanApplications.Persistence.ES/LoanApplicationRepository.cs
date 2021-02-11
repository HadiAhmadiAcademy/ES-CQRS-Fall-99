using System;
using System.Threading.Tasks;
using Framework.Domain;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Persistence.ES
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly IEventSourceRepository<LoanApplication, LoanApplicationId> _repository;
        public LoanApplicationRepository(IEventSourceRepository<LoanApplication, LoanApplicationId> repository)
        {
            _repository = repository;
        }
        public Task<LoanApplication> Get(LoanApplicationId id)
        {
            return _repository.GetById(id);
        }
        public Task Add(LoanApplication application)
        {
            return _repository.AppendEvents(application);
        }
        public Task Update(LoanApplication application)
        {
            return _repository.AppendEvents(application);
        }
    }
}
