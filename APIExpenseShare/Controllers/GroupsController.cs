using System.Security.Claims;
using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Controllers;
public class GroupsController : AuthorizedOnlyControllerBase
{
    private readonly DataContext context;

    public GroupsController(DataContext context)
    {
        this.context = context;
    }

    // [HttpGet]
    // public async Task<ActionResult<>> GetGroups() 
    // {
    //     var groups = await this.context.Groups.Where(x => x.);
    // }

    [HttpPost]
    public async Task<ActionResult<Group>> CreateGroup(CreateGroupInputDto createGroupInputDto)
    {
        var token = await HttpContext.AuthenticateAsync();
        if (token == null) return Unauthorized();
        var user_id = Convert.ToInt32(token.Principal!.Claims.FirstOrDefault(x => x.Type == "user_id")!.Value);
        if (createGroupInputDto == null) return BadRequest();

        var user = await this.context.Users.SingleAsync(xUser => xUser.Id == user_id);
        User[] users = { user };
        var group = new Group
        {
            Name = createGroupInputDto.GroupName,
            Users = new List<User>(users)
        };


        this.context.Groups.Add(group);
        await this.context.SaveChangesAsync();

        return group;
    }

}
