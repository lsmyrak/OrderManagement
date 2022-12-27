using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Order
{
    public class AddOrderCommand:IRequest<int>
    {
        public OrderDto order { get; set; }
        public AddOrderCommand(OrderDto orderDto)
        {
            order = orderDto;
        }
    }
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IOrderService _orderService;

        public AddOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.Add(request.order,cancellationToken);
            return 0;
        }
    }
}
