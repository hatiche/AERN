using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>User sessions and tokens.</summary>
public interface ISessionService
{
    Task<ApiResult<SessionDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<SessionDto>> GetUserSessionsAsync(Guid userId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<bool>> RevokeAsync(Guid sessionId, CancellationToken ct = default);
    Task<ApiResult<bool>> RevokeAllUserSessionsAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<SessionDto>> RefreshAsync(Guid sessionId, CancellationToken ct = default);
    Task<ApiResult<bool>> ValidateTokenAsync(string token, CancellationToken ct = default);
}

public record SessionDto(Guid Id, Guid UserId, DateTime CreatedAt, DateTime? ExpiresAt, string? ClientInfo, bool IsActive);
