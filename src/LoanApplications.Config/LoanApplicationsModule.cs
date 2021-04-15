using System;
using Autofac;
using Framework.Application;

namespace LoanApplications.Config
{
    public class LoanApplicationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterApplicationDependencies(builder);
            RegisterFrameworkDependencies(builder);

        }

        //TODO: move this method to framework
        private void RegisterFrameworkDependencies(ContainerBuilder builder)
        {
            //CommandBus => Singleton
            //AggregateFactory => Singleton
            //ISnapshotStore => ?
            //IEventTypeResolver => Singleton
            //IEventStoreConnection => Singleton
            //IEventSourceRepository => Singleton
        }

        private void RegisterApplicationDependencies(ContainerBuilder builder)
        {
            //IRepositories => Singleton
            //CommandHandler => Singleton
        }
    }
}
