using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApi.Modules;

namespace WebApi.Configuration
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new Config())
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterAllModules(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void RegisterAllModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());

            builder.RegisterModule(new DataAccessModule());

            builder.RegisterModule(new ServicesModule());
        }
    }
}