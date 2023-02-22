using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class AddOrderCommand : IRequest<int>
    {
        public OrderDto order { get; set; }
        public AddOrderCommand(OrderDto orderDto)
        {
            order = orderDto;
        }
    }
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Insert(_mapper.Map<Order>(request.order), cancellationToken);
            return 0;
        }
    }
}
