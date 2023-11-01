using System.ComponentModel.DataAnnotations;

namespace APIExpenseShare.DTOs;

public class RegisterDto
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Username { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}
