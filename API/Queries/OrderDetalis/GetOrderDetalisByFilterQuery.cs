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
    public class GetOrderDetalisByFilterQuery : IRequest<IEnumerable<OrderDetalisDto>>
    {
        public string Filtr { get; set; }
        public GetOrderDetalisByFilterQuery(string filtr)
        {
            Filtr = filtr;
        }
    }
    public class GetOrderDetalisByFilterQueryHandler : IRequestHandler<GetOrderDetalisByFilterQuery, IEnumerable<OrderDetalisDto>>
    {
        private readonly IRepository<OrderDetalis> _orderDetalisRepository;
        private readonly IMapper _mapper;
        public GetOrderDetalisByFilterQueryHandler(IRepository<OrderDetalis> orderDetalisRepository, IMapper mapper)
        {
            _orderDetalisRepository = orderDetalisRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetalisDto>> Handle(GetOrderDetalisByFilterQuery request, CancellationToken cancellationToken)
        {
            var orderdetalis = await _orderDetalisRepository.GetBy(x => x.Count.ToString().Contains(request.Filtr)
            || x.Order.Number.ToString().Contains(request.Filtr)
            || x.Article.Name.Contains(request.Filtr), cancellationToken);
            return orderdetalis.Select(x => _mapper.Map<OrderDetalisDto>(x));
        }
    }
}
