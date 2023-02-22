using API.Repositories;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class DeleteOrderDetalisCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteOrderDetalisCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteOrderDetalisCommandHandler : IRequestHandler<DeleteOrderDetalisCommand, int>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        public DeleteOrderDetalisCommandHandler(IRepository<OrderDetalis> orderDetalisREpository)
        {
            _orderDetalisRepository = orderDetalisREpository;
        }

        public async Task<int> Handle(DeleteOrderDetalisCommand request, CancellationToken cancellationToken)
        {
            await _orderDetalisRepository.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
