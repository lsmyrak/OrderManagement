using API.Repositories;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class DeleteContractorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteContractorCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteContractorCommandHandler : IRequestHandler<DeleteContractorCommand, int>
    {
        private readonly IRepository<Contractor> _contractorRepository;

        public DeleteContractorCommandHandler(IRepository<Contractor> contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        public async Task<int> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {
            await _contractorRepository.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
