using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.OrderDetalis
{
    public class GetOrderDetalisByIdQuery:IRequest<OrderDetalisDto>
    {
        public int Id { get; set; }
        public GetOrderDetalisByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetOrderDetalisByIdQueryHandler : IRequestHandler<GetOrderDetalisByIdQuery, OrderDetalisDto>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public GetOrderDetalisByIdQueryHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<OrderDetalisDto> Handle(GetOrderDetalisByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderDetalisService.Get(request.Id, cancellationToken);
        }
    }
}
