using APIExpenseShare.Entities;

namespace APIExpenseShare.Interfaces;
public interface ITokenService
{
    string CreateToken(User user);
}
