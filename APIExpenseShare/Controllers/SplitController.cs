
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using APIExpenseShare.Data;
using APIExpenseShare.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Controllers;



public class CalculateSplitDto
{
    [Required]
    public required int GroupId { get; set; }
}

public class SplitController : AuthorizedOnlyControllerBase
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("http://localhost:7071"),
    };

    private readonly DataContext context;

    public SplitController(DataContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CalculateSplit(CalculateSplitDto calculateSplitDto)
    {
        var expenses = await context.Expenses.Where(x => x.GroupId == calculateSplitDto.GroupId).Include(expense => expense.PaidByUser).ToListAsync();
        var group = await context.Groups.Where(x => x.Id == calculateSplitDto.GroupId).Include(group => group.Users).ToListAsync();

        using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    expenses = expenses,
                    numberOfMembers = group[0].Users.Count
                }),
                Encoding.UTF8,
                "application/json");

        var resp = await sharedClient.PostAsync("api/split_function", jsonContent);
        return await resp.Content.ReadAsStringAsync();
    }
}
