namespace APIExpenseShare.Entities;

public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public UserAccountDetail? UserAccountDetail { get; set; }
    public int? UserAccountDetailId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
