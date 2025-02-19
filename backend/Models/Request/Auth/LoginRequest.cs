using System.ComponentModel.DataAnnotations;

namespace backend.Models.Request.Auth;

public class LoginRequest
{
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string Username { get; set; } = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string Password { get; set; } = null!;
}