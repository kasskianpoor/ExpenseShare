using System.ComponentModel.DataAnnotations;

namespace APIExpenseShare.Entities;
public class Group
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required List<User> Users { get; set; } = new();
    public List<Expense>? Expenses { get; set; } = new();
}
