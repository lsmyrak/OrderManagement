using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetContractorByIdQuery : IRequest<ContractorDto>
    {
        public int Id { get; set; }
        public GetContractorByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetContractorByIdQueryHandler : IRequestHandler<GetContractorByIdQuery, ContractorDto>
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;
        public GetContractorByIdQueryHandler(IRepository<Contractor> contractorREpository, IMapper mapper)
        {
            _contractorRepository = contractorREpository;
            _mapper = mapper;
        }

        public async Task<ContractorDto> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ContractorDto>(await _contractorRepository.Get(request.Id, cancellationToken));
        }
    }
}
