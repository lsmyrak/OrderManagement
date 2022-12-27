using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Contractor
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
        private readonly IContractorService _contractorService;
        public GetContractorByFilterQueryHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<IEnumerable<ContractorDto>> Handle(GetContractorByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _contractorService.GetByFilter(request.Filtr, cancellationToken);
        }
    }
}
