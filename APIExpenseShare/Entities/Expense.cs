using System.ComponentModel.DataAnnotations.Schema;

namespace APIExpenseShare.Entities;
public class Expense
{
    public int Id { get; set; }
    public double Amount { get; set; }
    [ForeignKey("User")]
    public int PaidByUserId { get; set; }
}
