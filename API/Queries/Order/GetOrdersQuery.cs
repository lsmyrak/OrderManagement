using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {

    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IRepository<Contractor> _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderQueryHandler(IRepository<Contractor> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderRepository.GetAll(cancellationToken);
                return orders.Select(x => _mapper.Map<OrderDto>(x));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }

}
