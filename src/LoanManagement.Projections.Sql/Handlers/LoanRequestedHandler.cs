using System.Threading.Tasks;
using Framework.Core.Events;
using LoanApplications.Domain.Contracts;
using LoanManagement.Projections.Sql.Handlers.Model;

namespace LoanManagement.Projections.Sql.Handlers
{
    public class LoanRequestedHandler : IEventHandler<LoanRequested>
    {
        private readonly LoanApplicationContext _context;
        public LoanRequestedHandler(LoanApplicationContext context)
        {
            _context = context;
        }
        public async Task Handle(LoanRequested @event)
        {
            var application = new LoanApplication()
            {
                Id = @event.LoanApplicationId,
                Amount = @event.Amount,
                ApplicantId = @event.ApplicantId,
                Description = @event.Description,
                PaybackMonths = @event.PaybackMonths,
                State = LoanApplicationState.InProgress
            };
            await _context.LoanApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }
    }
}