using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using APIExpenseShare.Data;
using APIExpenseShare.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIExpenseShare;

public class AccountController : BasicApiController
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<User>> Register(RegisterDto registerDto)
    {
        using var hmac = new HMACSHA512();

        var user = new User
        {
            UserName = registerDto.Username,
            DateOfBirth = registerDto.DateOfBirth,
            Email = registerDto.Email
        };

        var userAccount = new UserAccountDetail
        {
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key,
            User = user
        };

        _context.Users.Add(user);
        _context.UserAccountDetails.Add(userAccount);
        await _context.SaveChangesAsync();

        return user;
    }
}
