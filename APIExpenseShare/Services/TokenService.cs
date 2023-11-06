using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIExpenseShare.Entities;
using APIExpenseShare.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace APIExpenseShare.Services;
public class TokenService : ITokenService
{

    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]!));
    }
    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new("user_id", user.Id.ToString()),
            new(JwtRegisteredClaimNames.NameId, user.Email),
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int GetUserIdOfToken(AuthenticateResult resultToken)
    {
        return Convert.ToInt32(resultToken.Principal!.Claims.FirstOrDefault(x => x.Type == "user_id")!.Value);
    }

}
