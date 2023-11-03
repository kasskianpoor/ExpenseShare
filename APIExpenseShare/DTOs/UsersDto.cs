using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;

namespace APIExpenseShare.DTOs;

public class UsersDto : IPaginatedDto
{
    public int PageNumber { get; set; }
    public int TotalNumOfPages { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
