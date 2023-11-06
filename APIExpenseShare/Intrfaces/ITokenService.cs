using APIExpenseShare.Entities;
using Microsoft.AspNetCore.Authentication;

namespace APIExpenseShare.Interfaces;
public interface ITokenService
{
    string CreateToken(User user);
    int GetUserIdOfToken(AuthenticateResult resultToken);
}
