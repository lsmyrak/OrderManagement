using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Contracts.Dtos;
using Domain.Model;

namespace API.Services
{
    interface  IAccountService
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
