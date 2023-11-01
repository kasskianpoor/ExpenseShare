using System.ComponentModel.DataAnnotations;

namespace APIExpenseShare.DTOs;

public class PurgeUserDto
{
    [Required]
    public int UserId { get; set; }
    public required string Email { get; set; }
}
