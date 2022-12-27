using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.OrderDetalis
{
    public class AddOrderDetalisCommand:IRequest<int>
    {
        public OrderDetalisDto OrderDetalisDto;
        public AddOrderDetalisCommand(OrderDetalisDto orderDetalisDto)
        {
            OrderDetalisDto = orderDetalisDto;
        }
    }
    public class AddOrderDetalisHandler : IRequestHandler<AddOrderDetalisCommand, int>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public AddOrderDetalisHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<int> Handle(AddOrderDetalisCommand request, CancellationToken cancellationToken)
        {
            await _orderDetalisService.Add(request.OrderDetalisDto, cancellationToken);
            return 0;
        }
    }
}
