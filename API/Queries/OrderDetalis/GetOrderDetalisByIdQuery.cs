using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetOrderDetalisByIdQuery : IRequest<OrderDetalisDto>
    {
        public int Id { get; set; }
        public GetOrderDetalisByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetOrderDetalisByIdQueryHandler : IRequestHandler<GetOrderDetalisByIdQuery, OrderDetalisDto>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        private IMapper _mapper;
        public GetOrderDetalisByIdQueryHandler(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _orderDetalisRepository = orderDetalisRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetalisDto> Handle(GetOrderDetalisByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<OrderDetalisDto>(await _orderDetalisRepository.Get(request.Id, cancellationToken));
        }
    }
}
