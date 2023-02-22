using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class UpdateOrderDetalisCommand : IRequest<int>
    {
        public OrderDetalisDto OrderDetalisDto { get; set; }

        public UpdateOrderDetalisCommand(OrderDetalisDto orderDetalisDto)
        {
            OrderDetalisDto = orderDetalisDto;
        }
    }

    public class UpdateOrderDetalisCommandHandler : IRequestHandler<UpdateOrderDetalisCommand, int>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        private readonly IMapper _mapper;
        public UpdateOrderDetalisCommandHandler(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _orderDetalisRepository = orderDetalisRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderDetalisCommand request, CancellationToken cancellationToken)
        {
            await _orderDetalisRepository.Update(_mapper.Map<OrderDetalis>(request.OrderDetalisDto), cancellationToken);
            return 0;
        }
    }
}
