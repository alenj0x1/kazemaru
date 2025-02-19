using AutoMapper;
using backend.Helpers;
using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;
using backend.Repositories;
using backend.Services.Contract;

namespace backend.Services;

public class AuthService(UserRepository userRepository, TokenRepository tokenRepository, IMapper mapper) : IAuthService
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly TokenRepository _tokenRepository = tokenRepository;
    private readonly IMapper _mapper = mapper;
    
    public GenericResponse<AuthResponse> Login(LoginRequest request)
    {
        var findUser = _userRepository.Get(request.Username) ?? throw new BadHttpRequestException("Username or password is incorrect");
        
        var comparePassword = Hasher.ComparePassword(request.Password, findUser.Password);
        if (!comparePassword) throw new BadHttpRequestException("Username or password is incorrect");
        
        Console.WriteLine(findUser.Username);

        return ManageResponse.Create(new AuthResponse { Token = "", RefreshToken = ""});
    }
}