using backend.Entity;
using backend.Helpers;
using StackExchange.Redis;

namespace backend.Repositories;

public class TokenRepository(IConnectionMultiplexer redis)
{
    private const string AccessTokenKey = "access_token";
    private const string RefreshTokenKey = "refresh_token";
    private const string SessionKey = "session";
    private const string UserIdKey = "user_id";
    private readonly IDatabase _db = redis.GetDatabase();

    public HashEntry[] Create(Guid userId, string accessToken, string refreshToken, TimeSpan? accessTokenExpiration, TimeSpan? refreshTokenExpiration)
    {
        accessTokenExpiration ??= TimeSpan.FromDays(7);
        refreshTokenExpiration ??= TimeSpan.FromMinutes(5);
        
        // Create hash with access, refresh and user id
        var hash = new HashEntry[]
        {
            new($"{AccessTokenKey}", accessToken),
            new($"{RefreshTokenKey}", refreshToken),
            new($"{UserIdKey}", userId.ToString())
        };
        _db.HashSet($"{SessionKey}:{userId}", hash);
        
        // Create index for access token and expiration
        _db.StringSet($"{AccessTokenKey}:{accessToken}", userId.ToString());
        _db.KeyExpire($"{AccessTokenKey}:{accessToken}", accessTokenExpiration);
        
        // Create index for refresh token and expiration
        _db.StringSet($"{RefreshTokenKey}:{refreshToken}", userId.ToString());
        _db.KeyExpire($"{RefreshTokenKey}:{refreshToken}", refreshTokenExpiration);

        return _db.HashGetAll($"{SessionKey}:{userId}");
    }

    public HashEntry[]? GetAccess(string accessToken)
    {
        var userId = _db.StringGet($"{AccessTokenKey}:{accessToken}");
        return !userId.HasValue ? null : _db.HashGetAll($"{SessionKey}:${userId.ToString()}");
    }

    public HashEntry[]? RenewSession(string refreshToken)
    {
        var userId = _db.StringGet($"{RefreshTokenKey}:{refreshToken}");
        var userSession = _db.HashGetAll($"{SessionKey}:{userId}");

        var parseUserId = Parser.ToGuid(userId.ToString()) ?? throw new Exception("Incorrect user id");
        
        return Create(parseUserId, _db.HashGet($"{SessionKey}:{userId}", ""), "", null, null);
    }
}