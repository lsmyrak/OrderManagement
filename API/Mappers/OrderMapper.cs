using AutoMapper;
using Contracts.Dtos;
using Domain.Model;

namespace API.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<Contractor, ContractorDto>();
            CreateMap<ContractorDto, Contractor>();

            CreateMap<OrderDetalis, OrderDetalisDto>();
            CreateMap<OrderDetalisDto, OrderDetalis>();

        }
    }
}
