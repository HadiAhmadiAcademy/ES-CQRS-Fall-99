using System;
using System.Reflection;
using Autofac;
using EventStore.ClientAPI;
using Framework.Application;
using Framework.Domain;
using Framework.Domain.Snapshots;
using Framework.Persistence.ES;
using Framework.Persistence.Sql;
using Module = Autofac.Module;

namespace Framework.Autofac
{
    public class FrameworkModule : Module
    {
        private readonly Assembly[] _eventTypeAssemblies;
        public FrameworkModule(params Assembly[] eventTypeAssemblies)
        {
            _eventTypeAssemblies = eventTypeAssemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacCommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
            builder.RegisterType<AggregateFactory>().As<IAggregateFactory>().SingleInstance();
            builder.RegisterType<SqlSnapshotStore>().As<ISnapshotStore>().SingleInstance();
            builder.Register(CreateEventTypeResolver).SingleInstance();
            builder.Register(CreateEventStoreConnection).SingleInstance();
            builder.RegisterType<EventStoreDb>().As<IEventStore>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EventSourceRepository<,>))
                .As(typeof(IEventSourceRepository<,>))
                .SingleInstance();
            
        }

        private IEventTypeResolver CreateEventTypeResolver(IComponentContext context)
        {
            var typeResolver = new EventTypeResolver();
            foreach (var assembly in _eventTypeAssemblies)
                typeResolver.AddTypesFromAssembly(assembly);
            return typeResolver;
        }
        private IEventStoreConnection CreateEventStoreConnection(IComponentContext context)
        {
            //TODO: remove the hard-coded connection string
            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@192.168.39.31:1113"));
            conn.ConnectAsync().Wait();
            return conn;
        }
    }
}