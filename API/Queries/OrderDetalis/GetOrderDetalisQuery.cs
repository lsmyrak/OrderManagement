using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetOrderDetalisQuery : IRequest<IEnumerable<OrderDetalisDto>>
    {
    }
    public class GetOrderDetalisQueryHandler : IRequestHandler<GetOrderDetalisQuery, IEnumerable<OrderDetalisDto>>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        private IMapper _mapper;
        public GetOrderDetalisQueryHandler(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _orderDetalisRepository = orderDetalisRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetalisDto>> Handle(GetOrderDetalisQuery request, CancellationToken cancellationToken)
        {
            return (await _orderDetalisRepository.GetAll(cancellationToken)).Select(x => _mapper.Map<OrderDetalisDto>(x));
        }
    }
}
