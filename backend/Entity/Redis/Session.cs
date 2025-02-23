namespace backend.Entity.Redis;

public class Session
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public Guid UserId { get; set; }
    public DateTime LastActivity { get; set; }
}