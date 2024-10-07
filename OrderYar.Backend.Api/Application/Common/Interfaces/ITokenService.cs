using System.Security.Claims;

namespace OrderYar.Backend.Api.Application.Common.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
    public ClaimsPrincipal ValidateToken(string token);
}
