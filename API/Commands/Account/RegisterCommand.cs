using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class RegisterCommand : IRequest
    {
        public RegisterDto model { get; set; }
        public RegisterCommand(RegisterDto model)
        {
            this.model = model;
        }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerUser = request.model;
            await _accountService.Register(registerUser);
            return Unit.Value;
        }
    }
}
