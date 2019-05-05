using Autofac;
using Infrastructure.Interfaces;
using Infrastructure.Mapping;

namespace Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MappingService>().As<IMappingService>();
        }
    }
}
