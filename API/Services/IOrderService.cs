using API.Mappers;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IOrderService
    {
        public Task Add(OrderDto orderDto, CancellationToken cancellationToken);
        public Task<OrderDto> Get(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
        public Task Update(OrderDto orderDto, CancellationToken cancellationToken);   
        
        public Task<IEnumerable<OrderDto>> GetBy(Expression<Func<Order,bool>> predycate, CancellationToken cancellationToken);
    }
}
