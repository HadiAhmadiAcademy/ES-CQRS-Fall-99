using System.Threading.Tasks;
using Framework.Core.Events;

namespace LoanManagement.Projections.Sql.Framework
{
    public class CursorAwareHandler<T> : IEventHandler<T> where T : IEvent
    {
        private readonly IEventHandler<T> _handler;
        private readonly ICursor _cursor;
        public CursorAwareHandler(IEventHandler<T> handler, ICursor cursor)
        {
            _handler = handler;
            _cursor = cursor;
        }
        public async Task Handle(T @event)
        {
            //.. begin transaction
            await _handler.Handle(@event);
            //_cursor.MoveTo(current position);
            //.. commit transaction
        }
    }
}