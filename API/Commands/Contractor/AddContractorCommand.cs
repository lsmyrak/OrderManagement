using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Contractor
{
    public class AddContractorCommand:IRequest<int>
    {
        public ContractorDto Model { get; set; }

        public AddContractorCommand(ContractorDto model)
        {
            Model = model;
        }
    }
    public class AddContractorCommandHandler : IRequestHandler<AddContractorCommand, int>
    {
        private readonly IContractorService _contractorService;
        public AddContractorCommandHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<int> Handle(AddContractorCommand request, CancellationToken cancellationToken)
        {
            await _contractorService.Add(request.Model,cancellationToken);
            return 0;
        }
    }

}
