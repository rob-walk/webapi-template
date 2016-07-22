using Autofac;
using WebApi.Common.DataAccess;

namespace WebApi.Modules
{
    public class DataAccessModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnyDbContext>().As<IAnyDbContext>()
                   .WithParameter(new NamedParameter("connectionString", ConnectionString))
                   .InstancePerRequest()
                   .AsImplementedInterfaces();
        }
    }
}