using Autofac;
using Services.Interfaces;
using Services.Services;

namespace Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<TaskService>().As<ITaskService>();
        }
    }
}
