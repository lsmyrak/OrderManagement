using API.Mappers;
using API.Repositories;
using API.Services;
using Autofac;
using AutoMapper;
using Infrastructure;
using MediatR;

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

            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderDetalisService>().As<IOrderDetalisService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<ContractorService>().As<IContractorService>();
            builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
        }
    }
}
