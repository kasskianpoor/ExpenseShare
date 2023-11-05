using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using APIExpenseShare.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Controllers;
public class GroupMembersController : AuthorizedOnlyControllerBase
{
    private readonly DataContext context;

    public GroupMembersController(DataContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Group>> AddGroupMember(GroupMemberInputDto groupMemberInputDto)
    {
        var group = await this.context.Groups
            .Where(group => group.Id == groupMemberInputDto.GroupId)
            .Include(group => group.Users)
            .FirstOrDefaultAsync();
        var user = await this.context.Users.Where(xUser => xUser.Email == groupMemberInputDto.UserEmail).FirstOrDefaultAsync();

        if (user != null && group != null)
        {
            group.Users.Add(user);
            await this.context.SaveChangesAsync();
            return group;
        }

        return BadRequest("The user or group with the specified ID do not exist!");
    }

    [HttpDelete]
    public async Task<ActionResult<Group>> DeleteGroupMember(GroupMemberRemoveInputDto groupMemberInputDto)
    {
        var group = await this.context.Groups
            .Where(group => group.Id == groupMemberInputDto.GroupId)
            .Include(group => group.Users)
            .FirstOrDefaultAsync();
        var user = await this.context.Users.FindAsync(groupMemberInputDto.UserId);

        if (user != null && group != null)
        {
            group.Users.Remove(user);
            await this.context.SaveChangesAsync();
            return group;
        }

        return BadRequest("The user or group with the specified ID do not exist!");
    }
}
