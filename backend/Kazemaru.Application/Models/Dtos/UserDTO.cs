namespace backend.Kazemaru.Application.Models.Dtos;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}