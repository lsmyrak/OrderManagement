using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private IMapper _mapper;
        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task Add(OrderDto orderDto, CancellationToken cancellationToken)
        {            
            await _orderRepository.Insert(_mapper.Map<Order>(orderDto),cancellationToken);
        }

        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            await _orderRepository.Delete(id,cancellationToken);
        }

        public async Task<OrderDto> Get(int id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(id,cancellationToken);
            return _mapper.Map<OrderDto>(order);
        }
        public async Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll(cancellationToken);
            return orders.Select(x => _mapper.Map<OrderDto>(x));

        }

        public async Task<IEnumerable<OrderDto>> GetBy(Expression<Func<Order, bool>> predycate,CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetByFilter(predycate,cancellationToken);
            return orders.Select(x => _mapper.Map<OrderDto>(x));
        }

        public async Task Update(OrderDto orderDto,CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.Update(order,cancellationToken);
        }
    }
}
