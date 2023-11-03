using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public required string Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    [Required]
    public required UserAccountDetail UserAccountDetail { get; set; }
    public List<Group>? Groups { get; set; }
    public List<Expense>? Expenses { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
}
