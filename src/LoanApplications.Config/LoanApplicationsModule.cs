using System;
using System.Linq;
using Autofac;
using Framework.Application;
using LoanApplications.Application;
using LoanApplications.Application.Contracts;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Persistence.ES;

namespace LoanApplications.Config
{
    public class LoanApplicationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(LoanApplicationHandlers).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
                .InstancePerLifetimeScope();

            builder.RegisterType<LoanApplicationRepository>().As<ILoanApplicationRepository>().SingleInstance();
        }

    }
}
