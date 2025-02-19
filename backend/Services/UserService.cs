using System.Security.Claims;
using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models;
using backend.Repositories;
using backend.Services.Contract;

namespace backend.Services;

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

            var newUser = await _userRepository.Create(new User
            {
                Username = _configuration["FirstUser:Username"] ??
                           throw new NullReferenceException("First user 'Username' is not defined"),
                DisplayName = _configuration["FirstUser:DisplayName"] ??
                              throw new NullReferenceException("First user 'DisplayName' is not defined"),
                Password = _configuration["FirstUser:Password"] ??
                           throw new NullReferenceException("First user 'Password' is not defined"),
                PasswordHint = _configuration["FirstUser:PasswordHint"] ??
                               throw new NullReferenceException("First user 'PasswordHint' is not defined"),
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