using API.Repositories;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteOrdercommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IRepository<Order> _orderRepository;
        public DeleteOrdercommandHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
