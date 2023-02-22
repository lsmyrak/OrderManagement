using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class AddOrderDetalisCommand : IRequest<int>
    {
        public OrderDetalisDto OrderDetalisDto;
        public AddOrderDetalisCommand(OrderDetalisDto orderDetalisDto)
        {
            OrderDetalisDto = orderDetalisDto;
        }
    }
    public class AddOrderDetalisHandler : IRequestHandler<AddOrderDetalisCommand, int>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        private readonly IMapper _mapper;
        public AddOrderDetalisHandler(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _orderDetalisRepository = orderDetalisRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddOrderDetalisCommand request, CancellationToken cancellationToken)
        {
            await _orderDetalisRepository.Insert(_mapper.Map<OrderDetalis>(request.OrderDetalisDto), cancellationToken);
            return 0;
        }
    }
}
