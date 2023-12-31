﻿using System.Security.Cryptography;
using System.Text;
using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare;

public class AccountController : BasicApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<UserTokenDto>> Register(RegisterDto registerDto)
    {
        using var hmac = new HMACSHA512();

        var userExists = await _context.Users.AnyAsync(x => x.Email.ToLower() == registerDto.Email.ToLower());
        if (userExists) return BadRequest("User with this Email already exists");

        var user = new User
        {
            UserName = registerDto.Username,
            DateOfBirth = registerDto.DateOfBirth,
            Email = registerDto.Email.ToLower(),
            UserAccountDetail = new UserAccountDetail
            {
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
            }
        };


        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserTokenDto
        {
            Username = user.UserName ?? user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserTokenDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(xUser => xUser.Email.ToLower().Trim() == loginDto.Email.ToLower().Trim());
        if (user == null) return Unauthorized("Account with the combination of this email and passowrd does not exist!");

        var userAccount = await _context.UserAccountDetails.SingleOrDefaultAsync(xUser => xUser.UserId == user.Id);
        if (userAccount == null) return BadRequest("This user exists but has no password!");

        using var hmac = new HMACSHA512(userAccount.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != userAccount.PasswordHash[i])
            {
                return Unauthorized("Account with the combination of this email and passowrd does not exist!");
            }
        }

        return new UserTokenDto
        {
            Username = user.UserName ?? user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpDelete("purgeuser")]
    public async Task<ActionResult<User>> PurgeUser(PurgeUserDto purgeUserDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(xUser => xUser.Email == purgeUserDto.Email && xUser.Id == purgeUserDto.UserId);
        if (user == null) return BadRequest("User with this Email does not exist!");

        _context.Remove(user);
        _context.SaveChanges();
        return user;
    }
}
