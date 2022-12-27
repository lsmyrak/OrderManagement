using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Order
{
    public class GetOrdersByFilterQuery:IRequest<IEnumerable<OrderDto>>
    {
        public string  Filter { get; set; }
        public GetOrdersByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
    public class GetOrdersByFilterQueryHandler : IRequestHandler<GetOrdersByFilterQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderService _orderService;
        public GetOrdersByFilterQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)            
        {
            return null;
        }
    }
}
