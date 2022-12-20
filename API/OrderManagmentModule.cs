using API.Mappers;
using API.Repositories;
using API.Services;
using Autofac;
using Autofac.Core;
using AutoMapper;
using Domain.Model;

namespace API
{
    public class OrderManagmentModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(typeof(OrderMapper)))).SingleInstance();
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();
            
            builder.RegisterType<OrderRepository>().As<IRepository<Order>>();
            builder.RegisterType<OrderDetalisRepository>().As<IRepository<OrderDetalis>>();
            builder.RegisterType<ArticleRepository>().As<IRepository<Article>>();
            builder.RegisterType<ContractorRepository>().As<IRepository<Contractor>>();

            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderDetalisService>().As<IOrderDetalisService>();

            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<ContractorService>().As<IContractorService>();
        }           
    }
}
