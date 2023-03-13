using API.Commands;
using API.Queries;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControiller : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountControiller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto dto)
        {
            await _mediator.Send(new RegisterCommand(dto));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginDto dto)
        {
            string token = await _mediator.Send(new LoginCommand(dto));
            return Ok(token);
        }

        [HttpPost("account-setting")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAccountSetting([FromBody] UserDto userDto)
        {

            await _mediator.Send(new UpdateAccountSettingCommand(userDto));
            return Ok();
        }
        [HttpGet("by-email/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            return Ok(await _mediator.Send(new GetAccountByEmailQuery(email)));
        }
    }

}
