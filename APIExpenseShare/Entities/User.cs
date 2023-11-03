using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    [JsonIgnore]
    public List<Group>? Groups { get; set; }
    [JsonIgnore]
    public List<Expense>? Expenses { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
}
