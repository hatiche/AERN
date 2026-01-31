using AERN.Api.Contracts;
using AERN.Api.Models;
using AERN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

/// <summary>Authentication: login and token refresh for Swagger / API clients.</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class AuthController(IJwtTokenService jwt, IUserService userService) : ControllerBase
{
    /// <summary>Login with email and password. Returns a JWT to use in the Authorize button in Swagger.</summary>
    /// <param name="request">Email and optional password (for demo, any email returns a token).</param>
    /// <param name="ct">Cancellation token.</param>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            return Unauthorized(new { message = "Email is required." });

        // Demo: accept any email and issue a token. Replace with real user lookup + password check.
        var user = await userService.GetByEmailAsync(request.Email, ct);
        var userId = user.Data?.Id.ToString() ?? Guid.NewGuid().ToString();
        var roles = new[] { "User", "Api" };
        var expiryMinutes = int.TryParse(HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Jwt:ExpiryMinutes"], out var m) ? m : 60;

        var token = jwt.GenerateToken(userId, request.Email, roles);
        return Ok(new LoginResponse(
            Token: token,
            TokenType: "Bearer",
            ExpiresAt: DateTime.UtcNow.AddMinutes(expiryMinutes)));
    }

    /// <summary>Returns current user info when called with a valid Bearer token (for testing auth).</summary>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Me()
    {
        var sub = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? User.FindFirst("email")?.Value;
        var roles = User.FindAll(System.Security.Claims.ClaimTypes.Role).Select(c => c.Value).ToList();
        return Ok(new { sub, email, roles });
    }
}
