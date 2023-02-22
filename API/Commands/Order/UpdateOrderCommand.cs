using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public OrderDto orderDto;
        public UpdateOrderCommand(OrderDto model)
        {
            orderDto = model;
        }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IRepository<Domain.Model.Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(request.orderDto.Id, cancellationToken);
            order.AddOrderDetalis(_mapper.Map<Domain.Model.OrderDetalis>(request.orderDto.OrderDetalis));
            await _orderRepository.Update(order, cancellationToken);
            return 0;
        }
    }
}
