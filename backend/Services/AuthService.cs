using AutoMapper;
using backend.Helpers;
using backend.Models;
using backend.Models.Request.Auth;
using backend.Models.Response.Auth;
using backend.Repositories;
using backend.Services.Contract;

namespace backend.Services;

public class AuthService(UserRepository userRepository, IMapper mapper, ITokenService tokenService) : IAuthService
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IMapper _mapper = mapper;
    
    public async Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Login(LoginRequest request)
    {
        try
        {
            var findUser = _userRepository.Get(request.Username) ?? throw new BadHttpRequestException("Username or password is incorrects");
        
            var comparePassword = Hasher.ComparePassword(request.Password, findUser.Password);
            if (!comparePassword) throw new BadHttpRequestException("Username or password is incorrect");
        
            return await _tokenService.CreateTokensAsync(findUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<(string AccessToken, DateTime ExpirationDate, string RefreshToken)> Refresh(string refreshToken)
    {
        try
        {
            var findSession = await _tokenService.GetRefreshTokenAsync(refreshToken) ?? throw new UnauthorizedAccessException("not allowed to refresh");
            var findUser = _userRepository.Get(findSession.UserId) ?? throw new UnauthorizedAccessException("not allowed to refresh");

            return await _tokenService.RefreshSessionAsync(findSession, findUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Logout(string refreshToken)
    {
        try
        {
            var findSession = await _tokenService.GetRefreshTokenAsync(refreshToken) ?? throw new UnauthorizedAccessException("not allowed to refresh");
            await _tokenService.RevokeSessionAsync(findSession);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}