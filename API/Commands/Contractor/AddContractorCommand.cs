using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class AddContractorCommand : IRequest<int>
    {
        public ContractorDto Model { get; set; }

        public AddContractorCommand(ContractorDto model)
        {
            Model = model;
        }
    }
    public class AddContractorCommandHandler : IRequestHandler<AddContractorCommand, int>
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public AddContractorCommandHandler(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddContractorCommand request, CancellationToken cancellationToken)
        {
            await _contractorRepository.Insert(_mapper.Map<Contractor>(request.Model), cancellationToken);
            return 0;
        }
    }

}
