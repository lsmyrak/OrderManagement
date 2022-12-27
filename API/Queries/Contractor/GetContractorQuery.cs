using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Contractor
{
    public class GetContractorQuery : IRequest<IEnumerable<ContractorDto>>
    {

    }

    public class GetContractorQueryHandler : IRequestHandler<GetContractorQuery, IEnumerable<ContractorDto>>
    {
        private readonly IContractorService _contractorService;

        public GetContractorQueryHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async  Task<IEnumerable<ContractorDto>> Handle(GetContractorQuery request, CancellationToken cancellationToken)
        {
            return await _contractorService.GetAll(cancellationToken);
        }
    }
}
