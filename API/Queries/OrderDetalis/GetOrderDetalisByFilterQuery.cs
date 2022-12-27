using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.OrderDetalis
{
    public class GetOrderDetalisByFilterQuery:IRequest<IEnumerable<OrderDetalisDto>>
    {
        public string Filtr { get; set; }
        public GetOrderDetalisByFilterQuery(string filtr)
        {
            Filtr = filtr;
        }
    }
    public class GetOrderDetalisByFilterQueryHandler : IRequestHandler<GetOrderDetalisByFilterQuery, IEnumerable<OrderDetalisDto>>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public GetOrderDetalisByFilterQueryHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<IEnumerable<OrderDetalisDto>> Handle(GetOrderDetalisByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _orderDetalisService.GetByFilter(request.Filtr, cancellationToken);
        }
    }
}
