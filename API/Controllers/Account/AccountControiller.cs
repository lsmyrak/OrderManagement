using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System;

namespace API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControiller:ControllerBase
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
        public async Task<ActionResult> AccountSetting([FromBody] UserDto userDto)
        {

            await _mediator.Send(new AccountSettingCommand(userDto));
            return Ok();
        }
        [HttpGet("by-email")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            return Ok(await _mediator.Send(new GetAccountQuery(email)));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(Guid id)
        {
            return Ok(await _mediator.Send(new GetRoleByIdQuery(id)));
        }

    }    
}
