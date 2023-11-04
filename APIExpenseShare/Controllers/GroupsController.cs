using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using APIExpenseShare.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet]
    public async Task<ActionResult<GroupsDto>> GetGroups()
    {
        var token = await HttpContext.AuthenticateAsync();
        if (token == null) return Unauthorized();
        var user_id = Convert.ToInt32(token.Principal!.Claims.FirstOrDefault(x => x.Type == "user_id")!.Value);
        var usersGroup = await this.context.Users
            .Where(xUser => xUser.Id == user_id)
            .Select(xUser => new
            {
                Groups = xUser.Groups
            })
            .ToListAsync();

        return new GroupsDto
        {
            PageNumber = 0,
            TotalNumOfPages = 0,
            Groups = usersGroup[0].Groups
        };
    }

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

    [HttpDelete]
    public async Task<ActionResult<Group>> DeleteGroup(DeleteIdInputDto deleteIdInputDto)
    {
        var group = await this.context.Groups.SingleOrDefaultAsync(xGroup => xGroup.Id == deleteIdInputDto.Id);
        if (group == null) return BadRequest();

        this.context.Groups.Remove(group);
        await this.context.SaveChangesAsync();
        return Ok(group);
    }

    [HttpGet("{id}/members")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        var token = await HttpContext.AuthenticateAsync();
        if (token == null) return Unauthorized();
        var user_id = Convert.ToInt32(token.Principal!.Claims.FirstOrDefault(x => x.Type == "user_id")!.Value);
        var group = await this.context.Groups
            .Where(group => group.Id == id)
            .Include(group => group.Users)
            .FirstOrDefaultAsync();

        if (group == null) return BadRequest("Group with this id was not found");
        return group;
    }
}
