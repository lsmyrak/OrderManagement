using Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IAccountService
    {
        public Task Register(RegisterDto registerUserDto);
        public Task Unregister(UserDto userDto);
        public Task<string> ValidateUser(LoginDto loginDto);
        public Task UpdateAccount(UserDto userdto);
        public Task<UserDto> GetUserByEmail(string email);
        public Task<RoleDto> GetRoleById(Guid id);
        public Task<IEnumerable<RoleDto>> GetRoles();


    }
}
