using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Contractor
{
    public class GetContractorByIdQuery:IRequest<ContractorDto>
    {
        public int Id { get; set; }
        public GetContractorByIdQuery(int id)
        {
            Id=id;
        }
    }

    public class GetContractorByIdQueryHandler : IRequestHandler<GetContractorByIdQuery, ContractorDto>
    {
        private readonly IContractorService _contractorService;
        public GetContractorByIdQueryHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<ContractorDto> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contractorService.Get(request.Id, cancellationToken);
        }
    }
}
