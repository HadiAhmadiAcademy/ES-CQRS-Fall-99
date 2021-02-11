using System.Threading.Tasks;
using Autofac;
using Framework.Core.Events;

namespace LoanManagement.Projections.Sql.Framework
{
    public class AutofacEventBus : IEventBus
    {
        private readonly ILifetimeScope _lifetimeScope;
        public AutofacEventBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Publish<T>(T eventToPublish) where T : IEvent
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var handler = scope.Resolve<IEventHandler<T>>();
                await handler.Handle(eventToPublish);
            }
        }
    }
}