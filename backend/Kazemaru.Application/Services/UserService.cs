using System.Security.Claims;
using AutoMapper;
using backend.DTO;
using backend.Entity.Postgres;
using backend.Helpers;
using backend.Kazemaru.Application.Interfaces.Services;
using backend.Kazemaru.Application.Models.Responses;
using backend.Repositories;

namespace backend.Kazemaru.Application.Services;

public class UserService(UserRepository userRepository, IConfiguration configuration, IMapper mapper) : IUserService
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly IMapper _mapper = mapper;

    public async Task<UserDTO?> FirstUser()
    {
        try
        {
            var usersCount = _userRepository.Queryable().Count();
            if (usersCount > 0) return null;

            var username = _configuration["FirstUser:Username"] ?? throw new NullReferenceException("First user 'Username' is not defined");
            var displayName = _configuration["FirstUser:DisplayName"] ?? throw new NullReferenceException("First user 'DisplayName' is not defined");
            var password = _configuration["FirstUser:Password"] ?? throw new NullReferenceException("First user password is not defined");
            var passwordHint = _configuration["FirstUser:Password"] ?? throw new NullReferenceException("First user password is not defined");

            var newUser = await _userRepository.Create(new User
            {
                Username = username,
                DisplayName = displayName,
                Password = Hasher.HashPassword(password),
                PasswordHint = passwordHint
            });

            Console.WriteLine("First user created correctly");

            return _mapper.Map<UserDTO>(newUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public GenericResponse<UserDTO> Me(Claim userId)
    {
        throw new NotImplementedException();
    }
}