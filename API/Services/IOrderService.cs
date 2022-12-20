using API.Mappers;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IOrderService
    {
        public Task Add(OrderDto orderDto);
        public Task<OrderDto> Get(int id);
        public Task<IEnumerable<OrderDto>> GetAll();
        public Task Delete(int id);
        public Task Update(OrderDto orderDto);   
        
        public Task<IEnumerable<OrderDto>> GetBy(Expression<Func<Order,bool>> predycate);
    }
}
