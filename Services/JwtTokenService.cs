using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AERN.Services;

/// <summary>Generates JWT tokens for API authentication.</summary>
public interface IJwtTokenService
{
    string GenerateToken(string userId, string email, IReadOnlyList<string>? roles = null);
}

public sealed class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _config;

    public JwtTokenService(IConfiguration config) => _config = config;

    public string GenerateToken(string userId, string email, IReadOnlyList<string>? roles = null)
    {
        var key = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is not set.");
        var issuer = _config["Jwt:Issuer"] ?? "AERN.Api";
        var audience = _config["Jwt:Audience"] ?? "AERN.Client";
        var expiryMinutes = int.TryParse(_config["Jwt:ExpiryMinutes"], out var m) ? m : 60;

        var keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
        var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        if (roles is { Count: > 0 })
        {
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(expiryMinutes),
            creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
