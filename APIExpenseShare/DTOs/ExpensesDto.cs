namespace APIExpenseShare.DTOs;

public class CreateExpenseDto
{
    public double Amount { get; set; }
    public int GroupId { get; set; }
    public int? UserId { get; set; } = null!;
}

public class UpdateExpenseDto
{

    public int ExpenseId { get; set; }
    public double Amount { get; set; }
}
