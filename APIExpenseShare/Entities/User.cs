namespace APIExpenseShare.Entities;

public class User
{
    public int Id { get; set; }
    public int UserName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public required UserAccountInfo UserAccountInfo { get; set; }
    public int UserAccountInfoId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
