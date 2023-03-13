using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public LoginDto model { get; set; }
        public LoginCommand(LoginDto model)
        {
            this.model = model;
        }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAccountService _accountService;
        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.ValidateUser(request.model);
        }
    }
}
