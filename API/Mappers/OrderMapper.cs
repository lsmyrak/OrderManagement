using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;

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
            CreateMap<ContractorDto, ContractorDto>();

            CreateMap<OrderDetalis, OrderDetalisDto>();
            CreateMap<OrderDetalisDto, OrderDetalis>();

        }
    }
}
