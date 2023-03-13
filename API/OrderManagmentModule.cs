using API.Mappers;
using API.Repositories;
using API.Services;
using Autofac;
using AutoMapper;
using Contracts.Dtos;
using Microsoft.AspNetCore.Identity;

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
            builder.RegisterType<RoleRepository>().AsImplementedInterfaces();
            builder.RegisterType<UserRepository>().AsImplementedInterfaces();
            builder.RegisterType<AccountService>().AsImplementedInterfaces();
            builder.RegisterType<PasswordHasher<RegisterDto>>().AsImplementedInterfaces();        
        }
    }
}