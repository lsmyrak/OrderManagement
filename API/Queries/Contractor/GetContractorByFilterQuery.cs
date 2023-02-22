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
    public class GetContractorByFilterQuery : IRequest<IEnumerable<ContractorDto>>
    {
        public string Filtr { get; set; }
        public GetContractorByFilterQuery(string filtr)
        {
            Filtr = filtr;
        }
    }
    public class GetContractorByFilterQueryHandler : IRequestHandler<GetContractorByFilterQuery, IEnumerable<ContractorDto>>
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public GetContractorByFilterQueryHandler(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ContractorDto>> Handle(GetContractorByFilterQuery request, CancellationToken cancellationToken)
        {
            var contractors = await _contractorRepository.GetBy(x => x.City.Contains(request.Filtr) || x.Name.Contains(request.Filtr), cancellationToken);
            return contractors.Select(x => _mapper.Map<ContractorDto>(x));
        }
    }
}
