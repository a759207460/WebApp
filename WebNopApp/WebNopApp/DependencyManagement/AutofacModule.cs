using Autofac;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Customers;

namespace WebNopApp.DependencyManagement
{
    public class AutofacModule : Module
    {
        /// <summary>
        /// AutoFac注册类
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NopFileProvider>().As<INopFileProvider>().InstancePerLifetimeScope();
            builder.RegisterType<EfDataProviderManager>().As<IDataProviderManager>().InstancePerDependency();
            builder.Register(context => context.Resolve<IDataProviderManager>().DataProvider).As<IDataProvider>().InstancePerDependency();
            builder.Register(context => new NopObjectContext(context.Resolve<DbContextOptions<NopObjectContext>>()))
                .As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
        }
    }
}
