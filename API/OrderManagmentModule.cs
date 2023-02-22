using API.Mappers;
using API.Repositories;
using Autofac;
using AutoMapper;

namespace API
{
    public class OrderManagmentModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(typeof(OrderMapper)))).SingleInstance();
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();

            builder.RegisterType<OrderRepository>().AsImplementedInterfaces();
            builder.RegisterType<OrderDetalisRepository>().AsImplementedInterfaces();
            builder.RegisterType<ArticleRepository>().AsImplementedInterfaces();
            builder.RegisterType<ContractorRepository>().AsImplementedInterfaces();


        }
    }
}