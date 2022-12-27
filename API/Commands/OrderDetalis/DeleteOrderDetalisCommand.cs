using API.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.OrderDetalis
{
    public class DeleteOrderDetalisCommand:IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderDetalisCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteOrderDetalisCommandHandler : IRequestHandler<DeleteOrderDetalisCommand, int>
    {
        private readonly IOrderDetalisService _orderDetalisService;
        public DeleteOrderDetalisCommandHandler(IOrderDetalisService orderDetalisService)
        {
            _orderDetalisService = orderDetalisService;
        }

        public async Task<int> Handle(DeleteOrderDetalisCommand request, CancellationToken cancellationToken)
        {
            await _orderDetalisService.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
