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
    public class GetContractorQuery : IRequest<IEnumerable<ContractorDto>>
    {

    }

    public class GetContractorQueryHandler : IRequestHandler<GetContractorQuery, IEnumerable<ContractorDto>>
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public GetContractorQueryHandler(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractorDto>> Handle(GetContractorQuery request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorRepository.GetAll(cancellationToken);
            return contractor.Select(x => _mapper.Map<ContractorDto>(x));
        }
    }
}
