using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;

namespace APIExpenseShare.DTOs;
public class GroupsDto : IPaginatedDto
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
    public List<Group>? Groups { get; set; }
}
