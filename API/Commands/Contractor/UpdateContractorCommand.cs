using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class UpdateContractorCommand : IRequest<int>
    {
        public ContractorDto ContractorDto { get; set; }

        public UpdateContractorCommand(ContractorDto contractorDto)
        {
            ContractorDto = contractorDto;
        }
    }
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, int>
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public UpdateContractorCommandHandler(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            await _contractorRepository.Update(_mapper.Map<Contractor>(request.ContractorDto), cancellationToken);
            return 0;
        }
    }

}
