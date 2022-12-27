using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.OrderDetalis
{
    public class GetOrderDetalisQuery:IRequest<IEnumerable<OrderDetalisDto>>
    {
    }
    public class GetOrderDetalisQueryHandler : IRequestHandler<GetOrderDetalisQuery, IEnumerable<OrderDetalisDto>>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public GetOrderDetalisQueryHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<IEnumerable<OrderDetalisDto>> Handle(GetOrderDetalisQuery request, CancellationToken cancellationToken)
        {
            return await _orderDetalisService.GetAll(cancellationToken);
        }
    }
}
