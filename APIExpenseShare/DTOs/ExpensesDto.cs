using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;

namespace APIExpenseShare.DTOs;
public class ExpensesDto : IPaginatedDto
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
    public List<Expense>? Expenses { get; set; }
}

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
