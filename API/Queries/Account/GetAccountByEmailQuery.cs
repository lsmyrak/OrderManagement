using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetAccountByEmailQuery : IRequest<UserDto>
    {
        public string email { get; set; }
        public GetAccountByEmailQuery(string email)
        {
            this.email = email;
        }
    }

    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, UserDto>
    {
        private readonly IAccountService _accountService;
        public GetAccountByEmailQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<UserDto> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            var userDto = await _accountService.GetUserByEmail(request.email);
            return userDto;
        }
    }
}
