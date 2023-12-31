using APIExpenseShare.Data;
using APIExpenseShare.DTOs;
using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Controllers;
public class ExpensesController : AuthorizedOnlyControllerBase
{
    private readonly DataContext context;
    private readonly ITokenService tokenService;

    public ExpensesController(DataContext context, ITokenService tokenService)
    {
        this.context = context;
        this.tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense(CreateExpenseDto createExpenseDto)
    {
        var token = await HttpContext.AuthenticateAsync();
        if (token == null) return Unauthorized();
        var user_id = tokenService.GetUserIdOfToken(token);
        if (createExpenseDto.UserId != null)
        {
            user_id = (int)createExpenseDto.UserId;
        }

        var user = await context.Users.SingleAsync(xUser => xUser.Id == user_id);

        var expense = new Expense
        {
            Amount = createExpenseDto.Amount,
            GroupId = createExpenseDto.GroupId,
            PaidByUser = user
        };

        context.Expenses.Add(expense);
        await context.SaveChangesAsync();
        return expense;
    }
    [HttpDelete]
    public async Task<ActionResult<Expense>> RemoveExpense(DeleteIdInputDto deleteIdInputDto)
    {
        var expense = await context.Expenses.SingleAsync(xExpense => xExpense.Id == deleteIdInputDto.Id);

        context.Remove(expense);
        await context.SaveChangesAsync();
        return expense;
    }
    [HttpGet("{group_id}")]
    public async Task<ActionResult<IPaginatedDto<Expense>>> GetExpenses(int group_id)
    {
        var expenses = await context.Expenses.Where(x => x.GroupId == group_id).Include(expense => expense.PaidByUser).ToListAsync();

        return new PaginatedDto<Expense>
        {
            PageNumber = 0,
            TotalNumOfPages = 0,
            Data = expenses,
        };
    }
    [HttpPut]
    public async Task<ActionResult<Expense>> UpdateExpense(UpdateExpenseDto updateExpenseDto)
    {
        var expense = await context.Expenses.SingleAsync(xExpense => xExpense.Id == updateExpenseDto.ExpenseId);

        expense.Amount = updateExpenseDto.Amount;

        await context.SaveChangesAsync();
        return expense;
    }
}
