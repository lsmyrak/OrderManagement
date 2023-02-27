using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<RegisterDto> _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly AuthenticationSetting _authenticationSetting;

        public AccountService(IMapper mapper,IPasswordHasher<RegisterDto> passwordHasher, IUserRepository userRepository,IRepository<Role> roleRepositroy)
        {
            _mapper= mapper; 
            _passwordHasher= passwordHasher;
            _userRepository= userRepository;
            _roleRepository= roleRepositroy;
        }

        public Task<RoleDto> GetRoleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleDto>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await  _userRepository.GetUserByEmail(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task Register(RegisterDto registerUserDto)
        {
            var hashPassword = _passwordHasher.HashPassword(registerUserDto, registerUserDto.Password);
            registerUserDto.Password = hashPassword;
            var user = _mapper.Map<User>(registerUserDto);
            await _userRepository.Insert(user);
        }

        public async Task Unregister(UserDto userDto)
        {
            await _userRepository.Delete(userDto.Id);
        }

        public Task UpdateAccount(UserDto userdto)
        {
            throw new NotImplementedException();
        }

        public Task<string> ValidateUser(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
