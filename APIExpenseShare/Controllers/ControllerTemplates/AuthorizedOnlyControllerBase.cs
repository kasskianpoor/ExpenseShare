using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIExpenseShare.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorizedOnlyControllerBase : ControllerBase
{

}
