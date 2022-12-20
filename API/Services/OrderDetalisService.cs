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
    public class OrderDetalisService : IOrderDetalisService
    {
        private readonly IRepository<OrderDetalis> _orderDetalispository;
        private readonly IMapper _mapper;
        public OrderDetalisService(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderDetalispository = orderDetalisRepository;
        }
        public async Task Add(OrderDetalisDto orderDetalisDto)
        {
            await _orderDetalispository.Insert(_mapper.Map<OrderDetalis>(orderDetalisDto));
        }

        public async Task Delete(int id)
        {
            await _orderDetalispository.Delete(id);
        }

        public async Task<OrderDetalisDto> Get(int id)
        {
            return _mapper.Map<OrderDetalisDto>(await _orderDetalispository.Get(id));
        }

        public async Task<IEnumerable<OrderDetalisDto>> GetAll()
        {
            var orderDetalis = await _orderDetalispository.GetAll();
            return orderDetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }

        public async Task<IEnumerable<OrderDetalisDto>> GetBy(Expression<Func<OrderDetalis, bool>> predycate)
        {
            var orderDetalis = await _orderDetalispository.GetByFilter(predycate);
            return orderDetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }

        public async Task Update(OrderDetalisDto orderDetalisDto)
        {
            var orderdetalis = _mapper.Map<OrderDetalis>(orderDetalisDto);
            await _orderDetalispository.Update(orderdetalis);
        }
    }
}
