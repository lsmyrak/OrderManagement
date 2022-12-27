using API.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Order
{
    public class DeleteOrderCommand:IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteOrdercommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IOrderService _orderService;
        public DeleteOrdercommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
