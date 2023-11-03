using System.ComponentModel.DataAnnotations;

namespace APIExpenseShare.DTOs;

public class CreateGroupInputDto
{
    [Required]
    public required string GroupName { get; set; }
}
