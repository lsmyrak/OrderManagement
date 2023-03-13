using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public AccountService(IMapper mapper, IPasswordHasher<RegisterDto> passwordHasher, IUserRepository userRepository, IRepository<Role> roleRepositroy,AuthenticationSetting authenticationSetting)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _roleRepository = roleRepositroy;
            _authenticationSetting = authenticationSetting;
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
            var user = await _userRepository.GetUserByEmail(email);
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

        public async Task UpdateAccount(UserDto userdto)
        {
            await _userRepository.Update(_mapper.Map<User>(userdto));
        }

        public async Task<string> ValidateUser(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            {
                if (user == null)
                {
                    throw new BadRequestException("Invalid user or password");
                }

                var registerUser = _mapper.Map<RegisterDto>(user);
                var result = _passwordHasher.VerifyHashedPassword(registerUser, registerUser.Password, loginDto.Password);

                if (result == PasswordVerificationResult.Failed)
                {
                    throw new BadRequestException("Invalid email or password");
                }
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,user.UserRole.Name)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSetting.JwtKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(_authenticationSetting.JwtExpireDays);
                var token = new JwtSecurityToken(
                    _authenticationSetting.JwtIssuer,
                    _authenticationSetting.JwtIssuer,
                    claims,
                    expires: expires, signingCredentials: cred);
                var tokenHandlewr = new JwtSecurityTokenHandler();

                return tokenHandlewr.WriteToken(token);
            }
        }
    }
}
