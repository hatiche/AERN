namespace AERN.Api.Models;

/// <summary>Request body for login (e.g. email + password or passkey assertion).</summary>
public record LoginRequest(string Email, string? Password = null);

/// <summary>Response returned after successful login.</summary>
public record LoginResponse(string Token, string TokenType, DateTime ExpiresAt);
