using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Contractor
{
    public class UpdateContractorCommand:IRequest<int>
    {
        public ContractorDto ContractorDto { get; set; }

        public UpdateContractorCommand(ContractorDto contractorDto)
        {
            ContractorDto = contractorDto;
        }
    }
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, int>
    {
        private readonly IContractorService _contractorService;

        public UpdateContractorCommandHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<int> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
           await  _contractorService.Update(request.ContractorDto, cancellationToken);
            return 0;
        }
    }

}
