using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Entities;

[Index(nameof(Email), IsUnique = true)]
public class UserAccountDetail
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }

    // This is only for when the Email is correct and Password is wrong many times. 
    // After the Email and Password is correct after three wrong attempts, we notify user that their account is suspended. (ONLY WHEN THEY INPUT CORRECT EMAIL AND PASSWORD)
    public int NumberOfFailedAttempts { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; } = null!;
}
