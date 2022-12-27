using API.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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
        public async Task Add(OrderDetalisDto orderDetalisDto, CancellationToken cancellationToken)
        {
            await _orderDetalispository.Insert(_mapper.Map<OrderDetalis>(orderDetalisDto),cancellationToken );
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _orderDetalispository.Delete(id,cancellationToken);
        }

        public async Task<OrderDetalisDto> Get(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<OrderDetalisDto>(await _orderDetalispository.Get(id,cancellationToken));
        }

        public async Task<IEnumerable<OrderDetalisDto>> GetAll(CancellationToken cancellationToken)
        {
            var orderDetalis = await _orderDetalispository.GetAll(cancellationToken);
            return orderDetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }

        public async Task<IEnumerable<OrderDetalisDto>> GetBy(Expression<Func<OrderDetalis, bool>> predycate, CancellationToken cancellationToken)
        {
            var orderDetalis = await _orderDetalispository.GetBy(predycate,cancellationToken);
            return orderDetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }

        public async Task<IEnumerable<OrderDetalisDto>> GetByFilter(string filter, CancellationToken cancellationToken)
        {
            var orderdetalis = await  _orderDetalispository.GetAll(cancellationToken);
            var searchOrderDetalis = orderdetalis.Where(x => x.Count.ToString().Contains(filter)
            || x.Order.Number.ToString().Contains(filter)
            || x.Article.Name.Contains(filter));
            return searchOrderDetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }

        public async Task Update(OrderDetalisDto orderDetalisDto, CancellationToken cancellationToken)
        {
            var orderDetalisSrc =  await _orderDetalispository.Get(orderDetalisDto.Id,cancellationToken);
            var orderDetalis = _mapper.Map<OrderDetalisDto,OrderDetalis>(orderDetalisDto,orderDetalisSrc);
            await _orderDetalispository.Update(orderDetalis);
        }
    }
}
