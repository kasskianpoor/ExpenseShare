using System.ComponentModel.DataAnnotations;

namespace APIExpenseShare.DTOs;
public class GroupMemberInputDto
{
    [Required]
    public required string UserEmail { get; set; }
    [Required]
    public int GroupId { get; set; }
}

public class GroupMemberRemoveInputDto
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int GroupId { get; set; }
}
