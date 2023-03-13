using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class UpdateAccountSettingCommand : IRequest
    {
        public UserDto model { get; set; }
        public UpdateAccountSettingCommand(UserDto model)
        {
            this.model = model;
        }
    }

    public class UpdateAccountSettingCommandHandler : IRequestHandler<UpdateAccountSettingCommand>
    {
        private readonly IAccountService _accountService;
        public UpdateAccountSettingCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Unit> Handle(UpdateAccountSettingCommand request, CancellationToken cancellationToken)
        {
            await _accountService.UpdateAccount(request.model);
            return Unit.Value;
        }
    }

}
