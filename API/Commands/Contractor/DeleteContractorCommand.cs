using API.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Contractor
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
        private IContractorService _contractorService;
        public DeleteContractorCommandHandler(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<int> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {
            await _contractorService.Delete(request.Id, cancellationToken);
            return 0;
        }
    }
}
