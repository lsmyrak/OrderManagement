using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.OrderDetalis
{
    public class UpdateOrderDetalisCommand:IRequest<int>
    {
        public OrderDetalisDto OrderDetalisDto { get; set; }

        public UpdateOrderDetalisCommand(OrderDetalisDto orderDetalisDto)
        {
            OrderDetalisDto = orderDetalisDto;
        }
    }

    public class UpdateOrderDetalisCommandHandler : IRequestHandler<UpdateOrderDetalisCommand, int>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public UpdateOrderDetalisCommandHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<int> Handle(UpdateOrderDetalisCommand request, CancellationToken cancellationToken)
        {
           await  _orderDetalisService.Update(request.OrderDetalisDto, cancellationToken);
            return 0;
        }
    }
}
