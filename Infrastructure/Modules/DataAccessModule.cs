using Autofac;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(context =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    return new AppDbContext(optionsBuilder.Options);
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Client>>().As<IRepository<Client>>();
            builder.RegisterType<Repository<ClientTask>>().As<IRepository<ClientTask>>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
