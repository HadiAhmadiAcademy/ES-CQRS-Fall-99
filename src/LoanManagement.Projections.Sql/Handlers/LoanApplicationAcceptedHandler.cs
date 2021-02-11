using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Events;
using LoanApplications.Domain.Contracts;
using LoanManagement.Projections.Sql.Handlers.Model;

namespace LoanManagement.Projections.Sql.Handlers
{
    public class LoanApplicationAcceptedHandler : IEventHandler<LoanApplicationAccepted>
    {
        private readonly LoanApplicationContext _context;
        public LoanApplicationAcceptedHandler(LoanApplicationContext context)
        {
            _context = context;
        }
        public async Task Handle(LoanApplicationAccepted @event)
        {
            var loanApplication = _context.LoanApplications.First(a => a.Id == @event.ApplicationId);
            loanApplication.State = LoanApplicationState.Accepted;
            await _context.SaveChangesAsync();
        }
    }
}