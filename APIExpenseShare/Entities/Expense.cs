using System.ComponentModel.DataAnnotations.Schema;

namespace APIExpenseShare.Entities;
public class Expense
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public required int GroupId { get; set; }
    public required User PaidByUser { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
