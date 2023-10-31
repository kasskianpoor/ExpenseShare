namespace APIExpenseShare.Entities;

public class UserAccountInfo
{
    public int Id { get; set; }
    public int Email { get; set; }
    public int Password { get; set; }

    // This is only for when the Email is correct and Password is wrong many times. 
    // After the Email and Password is correct after three wrong attempts, we notify user that their account is suspended. (ONLY WHEN THEY INPUT CORRECT EMAIL AND PASSWORD)
    public int NumberOfFailedAttempts { get; set; }

    public required User User { get; set; }
    public int UserId { get; set; }
}
