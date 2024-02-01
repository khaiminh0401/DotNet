using System.Security.Claims;

namespace AccountService.InterfaceService;

public interface IJwtService{
    public string GenerateToken(string username, int expirationMinutes);
    public ClaimsPrincipal ValidateToken(string token);
}