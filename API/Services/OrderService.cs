using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task Add(OrderDto orderDto)
        {            
            await _orderRepository.Insert(_mapper.Map<Order>(orderDto));
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<OrderDto> Get(int id)
        {
            var order = await _orderRepository.Get(id);
            return _mapper.Map<OrderDto>(order);
        }
        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders.Select(x => _mapper.Map<OrderDto>(x));

        }

        public async Task<IEnumerable<OrderDto>> GetBy(Expression<Func<Order, bool>> predycate)
        {
            var orders = await _orderRepository.GetByFilter(predycate);
            return orders.Select(x => _mapper.Map<OrderDto>(x));
        }

        public async Task Update(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.Update(order);
        }
    }
}
