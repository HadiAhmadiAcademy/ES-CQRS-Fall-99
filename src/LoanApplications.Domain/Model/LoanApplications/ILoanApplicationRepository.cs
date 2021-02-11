using System.Threading.Tasks;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public interface ILoanApplicationRepository
    {
        Task<LoanApplication> Get(LoanApplicationId id);
        Task Add(LoanApplication application);
        Task Update(LoanApplication application);
    }
}