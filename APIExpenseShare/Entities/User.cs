using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public required string Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public UserAccountDetail? UserAccountDetail { get; set; }
    public int? UserAccountDetailId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
