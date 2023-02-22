using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetOrdersByFilterQuery : IRequest<IEnumerable<OrderDto>>
    {
        public string Filter { get; set; }
        public GetOrdersByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
    public class GetOrdersByFilterQueryHandler : IRequestHandler<GetOrdersByFilterQuery, IEnumerable<OrderDto>>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersByFilterQueryHandler(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetBy(x => x.OrderDate.ToString().Contains(request.Filter)
             || x.Contractor.Name.Contains(request.Filter) || x.Number.ToString().Contains(request.Filter), cancellationToken);

            return orders.Select(x => _mapper.Map<OrderDto>(x));
        }
    }
}
