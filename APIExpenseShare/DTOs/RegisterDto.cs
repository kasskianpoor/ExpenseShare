namespace APIExpenseShare;

public class RegisterDto
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
