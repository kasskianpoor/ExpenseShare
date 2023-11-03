using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Controllers;

public class UsersController : AuthorizedOnlyControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<UsersDto>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return new UsersDto
        {
            PageNumber = 1,
            TotalNumOfPages = 10,
            Users = users
        };
    }


}
